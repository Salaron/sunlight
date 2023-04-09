using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SunLight.Database.Server;
using SunLight.Dtos.Response.Login;
using SunLight.Services.Unit;

namespace SunLight.Services;

internal class LoginService : ILoginService
{
    private const int KeySize = 32;
    private readonly ICryptoService _cryptoService;
    private readonly IUserService _userService;
    private readonly IUnitService _unitService;
    private readonly ServerDbContext _dbContext;
    private readonly IConfiguration _configuration;

    public LoginService(ICryptoService cryptoService, IUserService userService, IUnitService unitService,
        ServerDbContext dbContext,
        IConfiguration configuration)
    {
        _cryptoService = cryptoService;
        _userService = userService;
        _unitService = unitService;
        _dbContext = dbContext;
        _configuration = configuration;
    }

    public async Task<AuthKey> StartSessionAsync(string dummyToken)
    {
        var clientKey = _cryptoService.DecryptRsa(dummyToken);
        var serverKey = RandomNumberGenerator.GetBytes(KeySize);

        var sessionKey = new byte[KeySize];
        for (var i = 0; i < KeySize; i++)
        {
            sessionKey[i] = (byte)(clientKey[i] ^ serverKey[i]);
        }

        var userAuthKey = new AuthKey
        {
            AuthorizeToken = Guid.NewGuid(),
            SessionKey = Convert.ToBase64String(sessionKey),
            ServerKey = Convert.ToBase64String(serverKey)
        };

        await _dbContext.AddAsync(userAuthKey);
        await _dbContext.SaveChangesAsync();

        return userAuthKey;
    }

    public async Task<User> LoginAsync(string encryptedLogin, string encryptedPassword, Guid authorizeToken)
    {
        var (login, password) = await DecryptCredentialsAsync(authorizeToken, encryptedLogin, encryptedPassword);
        var selectedUser = await _dbContext.Users.FirstOrDefaultAsync(user =>
            user.LoginKey == login && user.LoginPasswd == password);

        await _dbContext.AuthKeys.Where(key => key.AuthorizeToken == authorizeToken).ExecuteDeleteAsync();

        var newAuthorizeToken = Guid.NewGuid();
        selectedUser.AuthorizeToken = newAuthorizeToken;
        selectedUser.LastLogin = DateTime.UtcNow;
        _dbContext.Update(selectedUser);
        await _dbContext.SaveChangesAsync();

        return selectedUser;
    }

    public async Task<User> RegisterAsync(string encryptedLogin, string encryptedPassword, Guid authorizeToken)
    {
        var (login, password) = await DecryptCredentialsAsync(authorizeToken, encryptedLogin, encryptedPassword);
        await _dbContext.AuthKeys.Where(key => key.AuthorizeToken == authorizeToken).ExecuteDeleteAsync();

        var newUser = await _userService.CreateUserAsync(login, password);
        newUser.AuthorizeToken = Guid.NewGuid();
        newUser.LastLogin = DateTime.UtcNow;
        _dbContext.Update(newUser);
        await _dbContext.SaveChangesAsync();

        return newUser;
    }

    public async Task<User> GetUserByTokenAsync(Guid authorizeToken)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.AuthorizeToken == authorizeToken);
    }

    public LoginUnitListMemberCategory GetInitialUnitList(int memberCategory)
    {
        var initialSet = new List<LoginUnitListInitialSet>();

        int[] centerUnits;
        if (memberCategory == 1)
            centerUnits = _configuration.GetSection("Unit:MuseCenterUnitIds").Get<int[]>();
        else
            centerUnits = _configuration.GetSection("Unit:AqoursCenterUnitIds").Get<int[]>();

        foreach (var centerUnitId in centerUnits)
        {
            var deckUnitIds = GetDefaultDeckWithCenterUnit(centerUnitId);

            var unitList = deckUnitIds.Select(b => new LoginUnitListUnitInfo
            {
                UnitId = b,
                IsRankMax = false
            });

            var set = new LoginUnitListInitialSet
            {
                UnitInitialSetId = centerUnitId,
                CenterUnitId = centerUnitId,
                UnitList = unitList
            };

            initialSet.Add(set);
        }

        var result = new LoginUnitListMemberCategory
        {
            MemberCategory = memberCategory,
            UnitInitialSet = initialSet
        };

        return result;
    }

    public async Task<IEnumerable<int>> CreateDefaultDeckAsync(uint userId, int centerUnitId)
    {
        var deckUnitIds = GetDefaultDeckWithCenterUnit(centerUnitId);

        var ids = new List<int>();
        foreach (var unitId in deckUnitIds)
        {
            var unitOwningUserId = await _unitService.AddUnitToUserAsync(userId, unitId);
            ids.Add(unitOwningUserId);
        }

        return ids;
    }

    private IEnumerable<int> GetDefaultDeckWithCenterUnit(int centerUnitId)
    {
        var deckUnitIds = new List<int>
        {
            1391,
            1529,
            1527,
            1487,
            centerUnitId,
            1486,
            1488,
            1528,
            1390
        };

        return deckUnitIds;
    }

    private async Task<(string login, string password)> DecryptCredentialsAsync(Guid authorizeToken,
        string encryptedLogin, string encryptedPassword)
    {
        var userAuthKey = await _dbContext.AuthKeys.FirstAsync(key => key.AuthorizeToken == authorizeToken);

        var loginBytes = Convert.FromBase64String(encryptedLogin);
        var passwordBytes = Convert.FromBase64String(encryptedPassword);
        var sessionKeyBytes = Convert.FromBase64String(userAuthKey.SessionKey);

        var key = new byte[16];
        Array.Copy(sessionKeyBytes, 0, key, 0, 16);

        var decryptedLogin = Encoding.UTF8.GetString(_cryptoService.DecryptAes(key, loginBytes));
        var decryptedPassword = Encoding.UTF8.GetString(_cryptoService.DecryptAes(key, passwordBytes));

        return (decryptedLogin, decryptedPassword);
    }
}
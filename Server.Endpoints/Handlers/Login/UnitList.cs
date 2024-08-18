using Server.Common;

namespace Server.Endpoints.Main.Login;

internal record UnitListInfo(int UnitId, bool IsRankMax);

internal record UnitInitialSet(int UnitInitialSetId, IEnumerable<UnitListInfo> UnitList, int CenterUnitId);

internal record UnitListByMemberCategory(int MemberCategory, List<UnitInitialSet> UnitInitialSet);

internal record UnitListResponse(List<UnitListByMemberCategory> MemberCategoryList);

[Endpoint("login/unitList")]
internal class UnitListEndpoint : Action<EmptyObject, UnitListResponse>
{
    private readonly int[] _museCenters = [338, 746, 728, 415, 272, 456, 735, 763, 514];
    private readonly int[] _aqoursCenters = [1287, 1399, 1425, 1104, 1298, 1169, 1526, 1203, 1265];

    private readonly int[] _defaultUnitSet = [1391, 1529, 1527, 1487, 0, 1486, 1488, 1528, 1390];

    public override Task<UnitListResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new UnitListResponse([
            GetInitialUnitListByMemberCategory(memberCategory: 1),
            GetInitialUnitListByMemberCategory(memberCategory: 2)
        ]));
    }

    private UnitListByMemberCategory GetInitialUnitListByMemberCategory(int memberCategory)
    {
        var centerUnitIds = memberCategory == 1 ? _museCenters : _aqoursCenters;

        var sets = new List<UnitInitialSet>();
        foreach (var centerUnit in centerUnitIds)
        {
            var unitIds = _defaultUnitSet;
            unitIds[4] = centerUnit;

            var unitList = unitIds.Select(unitId => new UnitListInfo(unitId, false));

            var unitSet = new UnitInitialSet(centerUnit, unitList, centerUnit);
            sets.Add(unitSet);
        }

        return new UnitListByMemberCategory(memberCategory, sets);
    }
}
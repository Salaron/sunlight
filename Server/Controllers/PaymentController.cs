using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Payment;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/payment")]
public class PaymentController : LlsifController
{
    [HttpPost("productList")]
    [Produces(typeof(ServerResponse<ProductListResponse>))]
    public IActionResult ProductList([FromBody] ClientRequest requestData)
    {
        var response = new ProductListResponse
        {
            RestrictionInfo = new ProductListRestrictionInfo(),
            UnderAgeInfo = new ProductListUnderAgeInfo(),
            SnsProductList = Enumerable.Empty<object>(),
            ProductList = Enumerable.Empty<object>(),
            SubscriptionList = Enumerable.Empty<object>(),
            ShowPointShop = false // TODO
        };

        return SendResponse(response);
    }
}
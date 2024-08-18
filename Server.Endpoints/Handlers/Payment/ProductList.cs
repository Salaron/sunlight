using Server.Common;

namespace Server.Endpoints.Main.Payment;

internal record PaymentRestrictionInfo(bool Restricted);

internal record PaymentUnderAgeInfo(bool BirthSet, bool HasLimit, int? LimitAmount, int MonthUsed);

internal record ProductListResponse(
    PaymentRestrictionInfo RestrictionInfo,
    PaymentUnderAgeInfo UnderAgeInfo,
    List<object> SnsProductList,
    List<object> ProductList,
    List<object> SubscriptionList,
    bool ShowPointShop);

[Endpoint("payment/productList", usedInApi: true)]
internal class ProductListEndpoint : Action<EmptyObject, ProductListResponse>
{
    public override Task<ProductListResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new ProductListResponse(new PaymentRestrictionInfo(true),
            new PaymentUnderAgeInfo(false, false, 0, 0),
            [],
            [],
            [],
            true));
    }
}
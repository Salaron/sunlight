namespace SunLight.Dtos.Response.Payment;

[Serializable]
public class ProductListResponse
{
    public ProductListRestrictionInfo RestrictionInfo { get; set; }
    public ProductListUnderAgeInfo UnderAgeInfo { get; set; }
    public IEnumerable<object> SnsProductList { get; set; }
    public IEnumerable<object> ProductList { get; set; }
    public IEnumerable<object> SubscriptionList { get; set; }
    public bool ShowPointShop { get; set; }
}
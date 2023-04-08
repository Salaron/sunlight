namespace SunLight.Dtos.Response.Payment;

[Serializable]
public class ProductListUnderAgeInfo
{
    public bool BirthSet { get; set; }
    public bool HasLimit { get; set; }
    public int? LimitAmount { get; set; }
    public int MonthUsed { get; set; }
}
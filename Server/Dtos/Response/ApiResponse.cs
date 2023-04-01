namespace SunLight.Dtos.Response;

[Serializable]
public class ApiResponse : BaseResponse
{
    public object Result { get; set; }
    public int Status { get; set; }
    public bool CommandNum { get; set; }
    public long TimeStamp { get; set; }

    public ApiResponse(object result, int status = 200)
    {
        Result = result;
        Status = status;
        CommandNum = false;
        TimeStamp = DateTimeUtils.CurrentUnixTimeStamp();
    }
}
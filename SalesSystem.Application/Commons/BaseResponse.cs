namespace SalesSystem.Application.Commons;
public class BaseResponse
{
    public StatusType StatusType { get; set; } = StatusType.Validation;
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }  
}
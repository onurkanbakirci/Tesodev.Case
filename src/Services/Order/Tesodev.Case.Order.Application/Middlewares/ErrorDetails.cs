using Newtonsoft.Json;

namespace Tesodev.Case.Order.Application.Middlewares;
public class ErrorDetails
{
    public string Message { get; set; }
    public int StatusCode { get; set; }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
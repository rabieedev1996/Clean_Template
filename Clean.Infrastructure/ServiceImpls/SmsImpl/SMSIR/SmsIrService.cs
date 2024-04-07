using Clean.Infrastructure.ServiceImpls.SmsImpl;
using RestSharp;

namespace Clean.Infrastructure.ServiceImpls.SMSImpl.SMSIR;

public class SmsIrService : ISmsImpl
{
    private string Token = "****";
    private string BaseUrl = "https://api.sms.ir/v1/send";
    private long TemplateId = 100000;
    private string Sender = "30007732003736";
    private string PositionVariable = "code";
    
    public async Task Send(List<string> dest, string message)
    {
        var client = new RestClient();
        var request = new RestRequest($"{BaseUrl}/bulk", Method.Post);
        request.AddHeader("x-api-key", Token);
        request.AddHeader("Content-Type", "application/json");
        var body = new SMSIRSendRequest
        {
            LineNumber = Sender,
            MessageText = message,
            Mobiles = dest.ToArray()
        };
        request.AddBody(body, ContentType.Json);
        RestResponse response = await client.ExecuteAsync(request);
    }

    public async Task SendCode(string dest, string code)
    {
     
        var client = new RestClient();
        var request = new RestRequest($"{BaseUrl}/verify", Method.Post);
        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("Accept", "text/plain");
        request.AddHeader("x-api-key", Token);
        var body = new SMSIRSendTemplateRequest
        {
            Mobile = dest,
            TemplateId = TemplateId,
            Parameters = new SMSIRSendTemplateParameter[]
            {
                new SMSIRSendTemplateParameter()
                {
                    Name = PositionVariable,
                    Value = code
                }
            }
        };
        request.AddBody(body, ContentType.Json);
        RestResponse response = await client.ExecuteAsync(request);
    }
}
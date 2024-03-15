namespace ACME.School.Core.Models
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string>? ValidationErrors { get; set; }
        public BaseResponse()
        {
            Success = true;
        }

        public BaseResponse(string messege)
        {
            Success = true;
            Message = messege;
        }
        public BaseResponse(string messege, bool success)
        {
            Success = success;
            Message = messege;
        }

    }
}

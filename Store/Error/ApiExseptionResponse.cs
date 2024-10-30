namespace Store.Error
{
    public class ApiExseptionResponse:APIErrorResponse
    {
        public ApiExseptionResponse(int statusCode,string? massage=null,string? details=null):base(statusCode,massage)
        {
            Details = details;
        }

        public string? Details { get; set; }
    }
}

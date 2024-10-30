namespace Store.Error
{
    public class APIErrorResponse
    {
        public APIErrorResponse(int statusCode, string? message=null)
        {
            StatusCode = statusCode;
            Message = message?? GetDefultMessageForStatusCode(StatusCode);
        }

        public int StatusCode { get; set; }
        public string? Message { get; set; }=null;
        private string? GetDefultMessageForStatusCode(int statusCode) 
        {
            var message = statusCode switch { 
            400=>"a bad request, you have made",
            401=>"Authorized , you are not",
            404=>"Resource was not found",
            500=>"Server Error"
            };
            return message;
        }

    }
}

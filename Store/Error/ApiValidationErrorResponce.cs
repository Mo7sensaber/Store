namespace Store.Error
{
    public class ApiValidationErrorResponce:APIErrorResponse
    {
        public ApiValidationErrorResponce() : base(400)
        {
        }

        public IEnumerable<string> Errors { get; set; }= new List<string>();
    }
}

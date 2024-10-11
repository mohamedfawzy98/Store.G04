namespace Store.G04.APIs.Error
{
    public class ApiValdiationErrorResponse : ApiErrorResponse
    {
        public IEnumerable<string> Errors { get; set; } = new List<string>();

        public ApiValdiationErrorResponse():base(400)
        {

        }
    }
}

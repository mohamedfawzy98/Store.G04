namespace Store.G04.APIs.Error
{
    public class ApiExpectionResponse : ApiErrorResponse
    {
        public string ? Details { get; set; }

        public ApiExpectionResponse(int stutascode , string ? message = null ,string? detalis = null)
         :base(StatusCodes.Status500InternalServerError , message)
        {
            Details = detalis;
        }
    }
}

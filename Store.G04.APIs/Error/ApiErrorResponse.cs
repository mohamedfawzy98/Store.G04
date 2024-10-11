namespace Store.G04.APIs.Error
{
    public class ApiErrorResponse
    {
        public ApiErrorResponse(int stutasCode, string? message = null)
        {
            Message = message ?? GetDefaultMessageForStautsCod(stutasCode);
            StutasCode = stutasCode;
        }

        public string? Message { get; set; }
        public int StutasCode { get; set; }

        private string? GetDefaultMessageForStautsCod(int stutascode)
        {
            var message = stutascode switch
            {
                400 => "a bad Requset , you have made",
                401 => "Authorize You have not",
                404 => "Resource , Not Found",
                500 => "Server Error",
                _ => null
            };



            return message;
        }
    }
}

using System;

namespace SanalSatis.API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            this.StatusCode = statusCode;
            this.Message = message ?? GetDefaultMessageForStatusCode(statusCode);

        }


        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Suanda 404 hatası almaktasınız.",
                500 => "Buraya uzun bir hata mesajı yazmak istiyorum. Bu yüzden uzun mesaj olması için uzun uzun yazıyorum.",
                _=> null
            };
        }
    }
}
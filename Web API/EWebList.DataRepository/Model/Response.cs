using DemoDotNet.DataRepository.Model;
using System.Net;

namespace DemoDotNet.DataRepository.Model
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public dynamic Result { get; set; }

        public string Token { get; set; }

        public Response(HttpStatusCode statusCode, object result = null, string message = null, string token = null)
        {
            StatusCode = (int)statusCode;
            Message = message;
            Result = result;
            Token = token;
        }

        public static object GenerateResponce(HttpStatusCode Code, object data, bool success, string token)
        {
            DataResponce dataresponce = new DataResponce
            {
                StatusCode = Code,
                isSuccess = success,
                Message = getErrorFromCode(Code),
                Token = token,
                Data = data,
            };
            return dataresponce;
        }


        // Get message by using error code
        public static string getErrorFromCode(HttpStatusCode code)
        {

            string errorMsg = null;
            switch (code)
            {
                case HttpStatusCode.OK:
                    errorMsg = "Success";
                    break;
                case HttpStatusCode.NotFound:
                    errorMsg = "Not Found";
                    break;
                case HttpStatusCode.InternalServerError:
                    errorMsg = "Internal Server Error";
                    break;
                case HttpStatusCode.Conflict:
                    errorMsg = "Record Exist";
                    break;
                case HttpStatusCode.BadRequest:
                    errorMsg = "Bad Request";
                    break;
                case HttpStatusCode.NoContent:
                    errorMsg = "No Content";
                    break;
                default:
                    errorMsg = "Something went wrong";
                    break;
            }
            return errorMsg;
        }
    }
}
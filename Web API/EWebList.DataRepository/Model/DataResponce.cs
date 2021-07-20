using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DemoDotNet.DataRepository.Model
{
    //Used for set json type response
    public class DataResponce
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool isSuccess = false;
        public string Message { get; set; }
        public object Data { get; set; }      
        public string Token { get; set; }
    }
}

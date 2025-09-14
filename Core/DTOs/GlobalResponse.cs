using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class SimpleResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
    public class GlobalResponse : SimpleResponse
    {
        public bool IsSuccess { get; set; }
        //public HttpStatusCode StatusCode { get; set; }
        //public string Message { get; set; }

    }

    public class GlobalResponse<T> : GlobalResponse
    {
        public T Data { get; set; }
    }

    public class PaginationGlobalResponse<T> : GlobalResponse<T>
    {
        public int Count { get; set; }
    }
    
}

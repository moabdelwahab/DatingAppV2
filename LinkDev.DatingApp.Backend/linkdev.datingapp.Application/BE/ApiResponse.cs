using System.Collections.Generic;
using System.Net;

namespace LinkDev.DatingApp.Application.BE
{
    public class ApiResponse
    {
      public HttpStatusCode Status { get; set; }

      public List<string> Messages { get; set; }
      
      public object Data { get; set; }

        public ApiResponse(HttpStatusCode status, List<string> messages, object data)
        {
            Status = status;
            Messages = messages;
            Data = data;
        }

    }
}
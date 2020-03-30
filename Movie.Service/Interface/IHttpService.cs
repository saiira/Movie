using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Service.Interface
{
    public interface IHttpService
    {
        string GetHttpResponse(string url);
    }
}

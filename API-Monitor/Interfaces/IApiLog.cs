using System;
using System.Collections.Generic;

namespace API_Monitor.Models
{
    public interface IApiLog
    {
        string api_name { get; set; }
        string id { get; set; }
        object JSON_obj { get; set; }
        string timeStamp { get; set; }

        List<ApiLog> GetApiLogs();
    }
}
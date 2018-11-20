using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace API_Monitor.Models
{
    public class ApiLog : IApiLog
    {
        [DisplayName("Log ID")]
        public string id { get; set; }
        [DisplayName("Time Stamp")]
        public string timeStamp { get; set; }
        [DisplayName("API Name")]
        public string api_name { get; set; }
        [DisplayName("JSON Data")]
        public object JSON_obj { get; set; }

        public ApiLog()
        {

        }

        public List<ApiLog> GetApiLogs()
        {
            return new List<ApiLog>(); 
        }
    }
    
}

using API_Monitor.Models;
using Microsoft.Azure.Documents.Client;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Monitor.Repositories
{
    public class Repository : IRepository
    {
        private List<ApiLog> object_list; 

        private void setup_Mongo()
        {
            var client = new MongoClient();
             
            var database = client.GetDatabase("_apilog");

            var collection = database.GetCollection<ApiLog>("_logs");

            object_list = collection.Find<ApiLog>(x => x.api_name != null).ToList(); 
        }

        public List<ApiLog> getAllApiLogs()
        {
            setup_Mongo();
            return object_list;
        }
        
        public ApiLog getSingleLog(string id)
        {
            return object_list.FirstOrDefault(x => x.id == id); 
        }

        public List<ApiLog> getAPIspecificLog(string api)
        {
            return new List<ApiLog>(); 
        }

        public List<string> getUniqueAPIList(List<ApiLog> logList)
        {
            return logList.Select(x => x.api_name).Distinct().ToList();
        }
    }
}

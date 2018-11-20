using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Monitor.Models
{
    public class MongoTracker
    {
        private List<ApiLog> object_list;

        private void setup_Mongo()
        {
            var client = new MongoClient();

            var database = client.GetDatabase("_apilog");

            var collection = database.GetCollection<ApiLog>("_logs");

            object_list = collection.Find<ApiLog>(x => x.api_name != null).ToList();
        }
    }
}

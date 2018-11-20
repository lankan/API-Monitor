using System;
using MongoDB.Driver;

namespace API_Monitor.Models
{
    public class MongoService
    {
        public MongoService(string id, string timestamp, string api_name, object JSON_obj)
        {
            var obj = new ApiLog
            {
                id = id,
                timeStamp = timestamp,
                api_name = api_name,
                JSON_obj = JSON_obj
            };

            InsertMongos(obj); 
        }

        public void InsertMongos(ApiLog obj)
        {
            var client = new MongoClient();

            var database = client.GetDatabase("_apilog");
            
            var collection = database.GetCollection<ApiLog>("_logs");

         //   collection.InsertOne(obj);
        }
    }
       
}

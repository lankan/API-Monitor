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
            MongoUrl url = new MongoUrl("mongodb://192.168.91.137"); 

            var client = new MongoClient(url);

            var database = client.GetDatabase("_apilog");
            
            var collection = database.GetCollection<ApiLog>("_logs");

         //   collection.InsertOne(obj);
        }
    }
       
}

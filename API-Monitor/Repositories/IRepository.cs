using System;
using System.Collections.Generic;
using API_Monitor.Models;

namespace API_Monitor.Repositories
{
    public interface IRepository
    {
        List<ApiLog> getAllApiLogs();
        List<ApiLog> getAPIspecificLog(string api);
        ApiLog getSingleLog(string id);
        List<string> getUniqueAPIList(List<ApiLog> logList);
    }
}
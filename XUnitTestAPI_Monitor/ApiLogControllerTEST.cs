using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using FluentAssertions;
using API_Monitor.Models;
using API_Monitor.Controllers;
using API_Monitor.Repositories;
using System.Linq; 

namespace XUnitTestAPI_Monitor
{
    public class ApiLogControllerTEST
    {
        private List<ApiLog> object_list { get; set; } = new List<ApiLog>()
                {
                    new ApiLog { api_name = "EE", id = "8b9d503e-b3f0-4950-bf67-720d95d1ece1", JSON_obj = "", timeStamp = DateTime.Now.ToString()},
                    new ApiLog { api_name = "Giffgaff", id = "8b9d503e-b3f0-4950-bf67-720d95d1ece1", JSON_obj = "", timeStamp = DateTime.Now.ToString()},
                    new ApiLog { api_name = "O2", id = "8b9d503e-b3f0-4950-bf67-720d95d1ece2", JSON_obj = "", timeStamp = DateTime.Now.ToString()},
                    new ApiLog { api_name = "Esure", id = "8b9d503e-b3f0-4950-bf67-720d95d1ece4", JSON_obj = "", timeStamp = DateTime.Now.ToString()}
                };


        [Fact]
        private void getAllApiLogs()
        {
            //Setup
            Mock<IRepository> repository = new Mock<IRepository>();
            repository.Setup(s => s.getAllApiLogs()).Returns(object_list);

            ApiLogController testingClass = new ApiLogController(repository.Object); 
            List<ApiLog> myLogs = new List<ApiLog>();

            //Result
            var result = testingClass.getAllApiLogs(); 

            //Assertion
            Assert.Equal(myLogs.GetType(), result.GetType()); 
        }

        [Fact]
        private void getAllApiLogs_usingFluent()
        {

            //Setup
            Mock<IRepository> repository = new Mock<IRepository>();
            repository.Setup(s => s.getAllApiLogs()).Returns(object_list);

            ApiLogController testingClass = new ApiLogController(repository.Object);
            List<ApiLog> myLogs = new List<ApiLog>();

            //Result
            var result = testingClass.getAllApiLogs();

            //Assertion
            result.Should().BeOfType<List<ApiLog>>(); 
        }

        [Fact]
        private void getAllApiLogs_Realdata_usingFluent()
        {
            //Setup
            Mock<IRepository> repository = new Mock<IRepository>();
            repository.Setup(s => s.getAllApiLogs()).Returns(object_list); 

            ApiLogController testingClass = new ApiLogController(repository.Object);
            List<ApiLog> myLogs = new List<ApiLog>();

            //Result
            var result = testingClass.getAllApiLogs();

            //Assertion
            Assert.Equal(object_list, result);
        }

        [Theory]
        [InlineData("5b9d503e-b3f0-4950-bf67-720d95d1eczx")]
        [InlineData("5b9d503e-b3f0-4950-bf67-720d95d1ece2")]
        [InlineData("8b9d503e-b3f0-4950-bf67-720d95d1ece1")]
        private void getSingleLog_Realdata(string id)
        {
            //Setup
            ApiLog apiLogs = object_list.Where(x => x.id == id).Select(x => x).FirstOrDefault();

            Mock<IRepository> repository = new Mock<IRepository>();
            repository.Setup(s => s.getSingleLog(id)).Returns(apiLogs);

            ApiLogController testingClass = new ApiLogController(repository.Object);
            List<ApiLog> myLogs = new List<ApiLog>();

            //Result
            var result = testingClass.getSingleLog(id);

            //Assertion
            Assert.Equal(object_list.Where(x => x.id == id).FirstOrDefault(), result);
        }

        [Theory]
        [InlineData("EE")]
        [InlineData("O2")]
        [InlineData("Esure")]
        private void getAPIspecificLog(string api)
        {
            //Setup
            List<ApiLog> apiLogs = object_list.Where(x => x.api_name == api).Select(x => x).ToList();

            Mock<IRepository> repository = new Mock<IRepository>();

            repository.Setup(s => s.getAPIspecificLog("EE")).Returns(apiLogs);

            ApiLogController testingClass = new ApiLogController(repository.Object);

            //Assign
            List<ApiLog> result = testingClass.getAPIspecificLog("EE");


            //Assert
            Assert.Equal(object_list.Where(x => x.api_name == api), result);

            //Fluent 
            //result.Should().Equals(object_list.Where(x => x.API == api)); 
        }

        [Fact]
        private void getUniqueAPIList()
        {
            //Setup 
            List<string> uniqueAPIList = object_list.Select(x => x.api_name).Distinct().ToList();
            Mock<IRepository> _repository = new Mock<IRepository>();

            _repository.Setup(x => x.getUniqueAPIList(object_list)).Returns(uniqueAPIList);

            var testingclass = new ApiLogController(_repository.Object);

            //Assign
            var result = testingclass.getUniqueAPIList(object_list);

            //Assert
            Assert.Equal(uniqueAPIList, result); 
        }
    }
}

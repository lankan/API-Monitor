(function () {
    'use strict';

    angular
        .module('App_Monitor')
        .controller('ApiLogController', ApiLogController);

    function ApiLogController($scope, $http, $interval) {

       //$http({
       //     method: 'GET',
       //     url: '/apilog/getUpdates'
       // }).then(function successCallback(response) {
       //     // this callback will be called asynchronously
       //     // when the response is available
       //     $scope.api = response.data;

       // }, function errorCallback(response) {
       //     // called asynchronously if an error occurs
       //     // or server returns response with an error status.
       //     });

        var data = function () {
            $.ajax({
                url: '/apilog/getUpdates',
                type: "GET",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    console.log("success");
                    $scope.api = response;
                    console.log(response);
                },
                error: function (response) {
                    console.log("failed");
                }
            })
        };

        $interval(data, 1000); 
        //data(); 
    }
})();


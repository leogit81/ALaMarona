var app = angular.module("app", ['ngRoute']);

angular.module("app").controller('mainCtrl', ['$scope', function($scope){
    $scope.user = {
        name: "Leonardo Sbaraglia",
        address: {
            street: 'Corrientes',
            city: 'CABA',
            planet: 'Earth'
        },
        friends: [
            'Han',
            'Leia',
            'Chewbacca'
          ]
    };
}]);

angular.module("app").directive('userInfoCard', function(){
   return{
        templateUrl: '/views/templates/userInfoCard.html',
        restrict: "E",
        controller: function($scope) {
          $scope.knightMe = function(user) {
            user.rank = "knight";
          }
        }
   };
});

app.config(function($routeProvider){
    $routeProvider
    .when("/", {
        templateUrl : "index.html"
    })
    .otherwise("/");
});
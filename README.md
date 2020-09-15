# BranchEval

I completed this assignment using Visual Studio 2019. In order to run it, please have Visual Studio 2019 installed, and open the BrancEval solution after downloading the files from this repository.

I chose to use ASP.NET to finish this assignment. I chose this because C# is my preferred language, and this allows you to create a Web API project with minimal effort. The only file I had to add myself was UserController.cs, the rest was created by default when I chose the project type. Aside from the default ASP.NET packages, I only had to add a couple packages on my own, which I will explain here:

RestSharp - This is a great way to make RESTful API calls through your code. I used RestSharp many times during my previous employment. Setting up a REST request is very straightforward and easy to implement. Since the main portion of the assignmentw was to query the GitHub API, I knew that RestShart would be very valuable.

JSON.NET - This is another framework that I have used reguarly. It provides you with simple ways of managing/formatting/serializing JSON objects. Since the API responses I receive from GitHub are in JSON format, this would be the perfect framework to help manage that data.

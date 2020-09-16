# BranchEval

I completed this assignment using Visual Studio 2019.
NOTE: The only part of the assignment that is not fully completed is formatting of the JSON data so that it is easily readable (JSON 

How to Run *
I would recommend having Visual Studio 2019 installed. I tried running it with Visual Studio 2017 as well. The API calls work fine, but the unit tests would not run.
Once you compile and run the code, your browser should open a new window and navigate to your localhost port. The three endpoints that you can use are 'api/user', 'api/user/{username}', and 'api/user/{username}/repos.' If you go to 'api/user', you will simply receive a message telling you to add a username to the API call. If you input an invalid username (for either the username or repos endpoints), you will receive an error message telling you so.


Coding Choices *
I chose to use ASP.NET to finish this assignment. I chose this because C# is my preferred language, and this allows you to create a Web API project with minimal effort. The only file I had to add myself was UserController.cs, the rest was created by default when I chose the project type. Aside from the default ASP.NET packages, I only had to add a couple packages/frameworks on my own, which I will explain here:

RestSharp - This is a great way to make RESTful API calls through your code. I used RestSharp many times during my previous employment. Setting up a REST request is very straightforward and easy to implement. Since the main portion of the assignmentw was to query the GitHub API, I knew that RestShart would be very valuable.

JSON.NET - This is another framework that I have used reguarly. It provides you with simple ways of managing/formatting/serializing JSON objects. Since the API responses I receive from GitHub are in JSON format, this is a perfect framework to help manage that data.

Finally, I decided against using MVC as a design pattern for this project. Since the only data that needs to be displayed is in a simple JSON format, I felt it was unnecessary to have a model/view/controller setup. If I had to do any more complicated screens (with grids, buttons, fields to fill in, etc.) I would probably use MVC, but not in this case.


Architecture *
The project that I have submitted is very straightforward. Most of the files present are added by default when you create a Web API Project in Visual Studio. I will discuss the one file that I created completely on my own, 'UserController.cs'. This file is what creates the api endpoints and determines what each of them do. The three endpoints that I have created are 'api/user', 'api/user/{username}', and 'api/user/{username}/endpoint.' All of the API calls to GitHub are made using RestSharp, which I have described earlier in this README. Once I have received the data back from the GitHub API, I convert it into a JSON object (using JSON.NET) and return it to be displayed on the screen. 


Unit Tests *
I have created five simple unit tests. In order to run them in Visual Studio 2019, click on the 'Test' tab up top, then 'Run All Tests.' The tests should all pass.
Here is a short description of each of the five tests:
1. Go to the 'api/user' endpoint and verify that the "Please add the username..." message is displayed.
2. Go to 'api/user/octocat2' and verify that the "No Github user..." error message is displayed
3. Go to 'api/user/octocat' and verify that octocat's information is being displayed correctly
4. Go to 'api/user/octocat2/repos' and verify that the "No GitHub user..." error message is displayed
5. To to 'api/user/octocat/repos' and verify that octocat's repo information is displayed correctly

﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BranchEval.Controllers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BranchEval.Tests
{
    [TestClass]
    public class UnitTests
    {

        //Test if "api/user" endpoint with no actual username sends the user to the correct page
        [TestMethod]
        public void Get_ShouldReturnDefaultPage()
        {
            var controller = new UserController();
            string result = controller.Get();
            StringAssert.Equals(result, "Please add the username to the endpoint to get information for a specific GitHub user.");
        }

        //Test if "api/user/octocat2" correctly returns the "no user found" error message
        [TestMethod]
        public void GetUser_ShouldReturnErrorForInvalidUser()
        {
            var controller = new UserController();
            JToken result = controller.GetUser("octocat2").Result;
            StringAssert.Equals(result.ToString(), "No GitHub user found with the username 'octocat2'.");
        }

        //Test if "api/user/octocat" correctly returns octocat's user info (octocat's id) and does NOT have the "No GitHub user..." error displayed
        [TestMethod]
        public void GetUser_ShouldReturnValidUser()
        {
            var controller = new UserController();
            JToken result = controller.GetUser("octocat").Result;
            Assert.IsFalse(result.ToString().Contains("No GitHub user found with the username 'octocat2'."));
            Assert.IsTrue(result.ToString().Contains("583231"));
        }

        //Test if "api/user/repos/octocat2" correctly returns the "no user found" error message
        [TestMethod]
        public void GetUserRepo_ShouldReturnErrorForInvalidUser()
        {
            var controller = new UserController();
            JToken result = controller.GetUserRepo("octocat2").Result;
            StringAssert.Equals(result.ToString(), "No GitHub user found with the username 'octocat2'.");
        }

        //Test if "api/user/repos/octocat" correctly returns octocat's repo info (both octocat's id and one of the repo ids) and does NOT have the "No GitHub user..." error displayed
        [TestMethod]
        public void GetUserRepo_ShouldReturnValidUser()
        {
            var controller = new UserController();
            JToken result = controller.GetUserRepo("octocat").Result;
            Assert.IsFalse(result.ToString().Contains("No GitHub user found with the username 'octocat2'."));
            Assert.IsTrue(result.ToString().Contains("583231"));
            Assert.IsTrue(result.ToString().Contains("132935648"));
        }
    }
}

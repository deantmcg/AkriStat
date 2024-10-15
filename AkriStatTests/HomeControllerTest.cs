using AkriStat.Constants;
using AkriStat.Controllers;
using AkriStat.Models;
using AkriStatTests.Helper;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AkriStatTests
{
    [TestClass]
    public class HomeControllerTest
    {
        private AkriStatDbContext _context;
        private Mock<IMapper> _mapper;
        private HomeController _controller;
        private string _userId = Guid.NewGuid().ToString();

        [TestInitialize]
        public async Task SetUp()
        {
            var dbFactory = new DatabaseFactory();
            _context = await dbFactory.CreateDatabase();

            _mapper = new Mock<IMapper>();

            _controller = new HomeController(_context, _mapper.Object);
        }

        [TestMethod]
        public async Task UnauthenticatedDashboard()
        {
            var userFactory = new UserFactory();
            var user = await userFactory.CreateUser("unauthenticated", _userId, _context);

            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext { User = user };

            var actionResult = await _controller.Dashboard();
            var viewResult = actionResult as ViewResult;
            var leaguesSelect = (List<SelectListItem>)viewResult.ViewData.Values.ToList()[0];
            var playersSelect = (List<SelectListItem>)viewResult.ViewData.Values.ToList()[1];

            Assert.AreEqual(await _context.Competitions.CountAsync(), leaguesSelect.Count);
            Assert.AreEqual(await _context.Players.CountAsync(), playersSelect.Count);
            Assert.IsNotNull(viewResult.ViewData.Values.ToList()[2].ToString());
        }

        [TestMethod]
        public async Task StandardUserDashboard()
        {
            var userFactory = new UserFactory();
            var user = await userFactory.CreateUser("standard", _userId, _context);

            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext { User = user };

            var actionResult = await _controller.Dashboard();
            var viewResult = actionResult as ViewResult;
            var shortlistsSelect = (List<SelectListItem>)viewResult.ViewData.Values.ToList()[0];
            var myTeamID = viewResult.ViewData.Values.ToList()[1].ToString();
            var myTeamName = viewResult.ViewData.Values.ToList()[2].ToString();
            var myTeamColour1 = viewResult.ViewData.Values.ToList()[3].ToString();
            var myTeamColour2 = viewResult.ViewData.Values.ToList()[4].ToString();
            var leaguesSelect = (List<SelectListItem>)viewResult.ViewData.Values.ToList()[5];
            var playersSelect = (List<SelectListItem>)viewResult.ViewData.Values.ToList()[6];

            var myTeam = _context.Teams.FirstOrDefault(x => x.ID == 1);

            Assert.AreEqual(await _context.Shortlists.Where(x => x.UserID.Equals(_userId)).CountAsync(), shortlistsSelect.Count);
            Assert.AreEqual(myTeamID, myTeam.ID.ToString());
            Assert.AreEqual(myTeamName, myTeam.Name);
            Assert.AreEqual(myTeamColour1, myTeam.ColourCode1);
            Assert.AreEqual(myTeamColour2, myTeam.ColourCode2);
            Assert.AreEqual(await _context.Competitions.CountAsync(), leaguesSelect.Count);
            Assert.AreEqual(await _context.Players.CountAsync(), playersSelect.Count);
            Assert.IsNotNull(viewResult.ViewData.Values.ToList()[2].ToString());
        }

        [TestMethod]
        public async Task ChiefScoutDashboard()
        {
            var userFactory = new UserFactory();
            var user = await userFactory.CreateUser("chief scout", _userId, _context);

            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext { User = user };

            var actionResult = await _controller.Dashboard();
            var viewResult = actionResult as ViewResult;
            var shortlistsSelect = (List<SelectListItem>)viewResult.ViewData.Values.ToList()[0];
            var staffActivity = viewResult.ViewData.Values.ToList()[1];
            var myTeamID = viewResult.ViewData.Values.ToList()[2].ToString();
            var myTeamName = viewResult.ViewData.Values.ToList()[3].ToString();
            var myTeamColour1 = viewResult.ViewData.Values.ToList()[4].ToString();
            var myTeamColour2 = viewResult.ViewData.Values.ToList()[5].ToString();
            var leaguesSelect = (List<SelectListItem>)viewResult.ViewData.Values.ToList()[6];
            var playersSelect = (List<SelectListItem>)viewResult.ViewData.Values.ToList()[7];

            var myTeam = _context.Teams.FirstOrDefault(x => x.ID == 2);

            Assert.AreEqual(await _context.Shortlists.Where(x => x.UserID.Equals(_userId)).CountAsync(), shortlistsSelect.Count);
            Assert.IsNotNull(staffActivity);
            Assert.AreEqual(myTeamID, myTeam.ID.ToString());
            Assert.AreEqual(myTeamName, myTeam.Name);
            Assert.AreEqual(myTeamColour1, myTeam.ColourCode1);
            Assert.AreEqual(myTeamColour2, myTeam.ColourCode2);
            Assert.AreEqual(await _context.Competitions.CountAsync(), leaguesSelect.Count);
            Assert.AreEqual(await _context.Players.CountAsync(), playersSelect.Count);
            Assert.IsNotNull(viewResult.ViewData.Values.ToList()[2].ToString());
        }
    }
}

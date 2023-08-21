using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using TeamManager.Application.Services.Team;
using TeamManager.Domain.Entities;
using TeamManager.Web.Controllers;
using TeamManager.Web.Models.Team;

namespace TeamManager.Web.Tests.Controllers
{
    [TestClass]
    public class TeamControllerTests
    {
        private ITeamService _teamService;
        private TeamController _teamController;

        [TestInitialize]
        public void TestInitialize()
        {
            _teamService = Substitute.For<ITeamService>();
            _teamController = new TeamController(_teamService);
        }

        [TestMethod]
        public void ListShouldCallTeamServiceAndReturnAListOfTeams()
        {
            // Arrange 
            var teams = new List<Team>()
            {
                new Team(){Id = 1, Name = "Team #1"},
                new Team(){Id = 2, Name = "Team #2"}
            };

            _teamService.ListAll().Returns(teams);

            var teamListViewModel = new TeamListViewModel(teams);

            // Act 
            var result = _teamController.List() as ViewResult;

            // Assert 
            _teamService.Received().ListAll();
            result.Should().NotBeNull();
            result?.ViewData.Model.Should().BeEquivalentTo(teamListViewModel);
        }
    }
}

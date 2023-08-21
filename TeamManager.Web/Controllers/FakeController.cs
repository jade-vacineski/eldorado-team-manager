using Microsoft.AspNetCore.Mvc;
using TeamManager.DataAccess;

namespace TeamManager.Web.Controllers
{
    public class FakeController : Controller
    {
        public IActionResult Index()
        {
            var collaborators = FakeData.GenerateCollaborators();

            var sqlList = new List<string>();
            foreach (var collaborator in collaborators)
            {
                sqlList.Add($"INSERT INTO Collaborator(Name,Email,Unit_Id,Team_Id) VALUES('{collaborator.Name}','{collaborator.Email}',{collaborator.UnitId},{(collaborator.TeamId == null ? "NULL" : collaborator.TeamId)});");
            }

            return View(sqlList);
        }
    }
}

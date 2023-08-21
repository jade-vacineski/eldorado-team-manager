using Entity = TeamManager.Domain.Entities;

namespace TeamManager.Web.Models.Team
{
    public class TeamListViewModel
    {
        public IEnumerable<Entity.Team> Teams { get; set; }

        public TeamListViewModel(IEnumerable<Entity.Team> teams)
        {
            Teams = teams;
        }
    }
}

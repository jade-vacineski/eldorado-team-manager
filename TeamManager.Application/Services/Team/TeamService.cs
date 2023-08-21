using TeamManager.Domain.Repositories;
using Entity = TeamManager.Domain.Entities;

namespace TeamManager.Application.Services.Team
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public IEnumerable<Entity.Team> ListAll()
        {
            var teams = _teamRepository.GetAll();
            return teams;
        }

        public Entity.Team GetById(int id)
        {
            var team = _teamRepository.GetById(id);
            return team;
        }

        public void Delete(int id)
        {
            _teamRepository.Delete(id);
        }

        public void Save(Entity.Team team)
        {
            if (team.Id == 0)
                _teamRepository.Insert(team);
            else
                _teamRepository.Update(team);
        }
    }
}

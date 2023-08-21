using Entity = TeamManager.Domain.Entities;

namespace TeamManager.Application.Services.Team
{
    public interface ITeamService
    {
        public IEnumerable<Entity.Team> ListAll();
        public Entity.Team GetById(int id);
        public void Delete(int id);
        public void Save(Entity.Team team);
    }
}

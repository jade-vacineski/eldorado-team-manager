using TeamManager.Domain.Entities;

namespace TeamManager.Domain.Repositories
{
    public interface ITeamRepository
    {
        public IEnumerable<Team> GetAll();
        public Team GetById(int id);
        public void Delete(int id);
        public void Insert(Team team);
        public void Update(Team team);
    }
}

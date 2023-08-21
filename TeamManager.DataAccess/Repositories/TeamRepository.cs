using Microsoft.EntityFrameworkCore;
using TeamManager.DataAccess.EF;
using TeamManager.Domain.Entities;
using TeamManager.Domain.Repositories;

namespace TeamManager.DataAccess.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly TeamManagerDbContext _dbContext;

        public TeamRepository(TeamManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Team> GetAll()
        {
            var teamList = _dbContext.Teams
                 .AsNoTracking()
                 .OrderBy(x => x.Name)
                 .ToList();

            return teamList;
        }

        public Team? GetById(int id)
        {
            var team = _dbContext.Teams
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            return team;
        }

        public void Delete(int id)
        {
            var team = _dbContext.Teams
                .FirstOrDefault(x => x.Id == id);

            if (team != null)
            {
                _dbContext.Remove(team);
                _dbContext.SaveChanges();
            }
        }

        public void Insert(Team team)
        {
            _dbContext.Teams.Add(team);
            _dbContext.SaveChanges();
        }

        public void Update(Team team)
        {
            _dbContext.Teams.Attach(team);
            _dbContext.Entry(team).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}

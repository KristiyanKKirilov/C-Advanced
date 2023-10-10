using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private readonly List<ITeam> teams;
        public TeamRepository()
        {
            teams = new List<ITeam>();
        }
        public IReadOnlyCollection<ITeam> Models => teams;

        public void AddModel(ITeam model)
        {
            teams.Add(model);
        }

        public bool ExistsModel(string name)
        {
            foreach (var team in teams)
            {
                if (team.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public ITeam GetModel(string name)
        {
            ITeam team = teams.FirstOrDefault(p => p.Name == name);

            if (team is null)
            {
                return null;
            }

            return team; ;
        }

        public bool RemoveModel(string name)
        {

            ITeam team = teams.FirstOrDefault(p => p.Name == name);
            if (team is null)
            {
                return false;
            }
            teams.Remove(team);
            return true;
        }
    }
}

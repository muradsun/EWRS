//Murad :: Info : Must ADD referance to Entity and Linq to see the extension methods
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ADMA.EWRS.Data.Models.Repositories;
using ADMA.EWRS.Data.Models;


namespace ADMA.EWRS.Data.Access.Repositories
{
    public class TeamModelRepository : Repository<TeamModel, EWRSContext>, ITeamModelsRepository
    {
        public TeamModelRepository(EWRSContext context)
          : base(context)
        {

        }

        public ICollection<TeamModel> GetTeamModelByProjectId(int projectId)
        {
            //return DbContext.TeamModels.Include(t => t.TeamModelSubjects).Where(t => t.Project_Id == projectId).ToList();
            return DbContext.TeamModels.Include(t => t.TeamModelSubjects).Where(t => t.Project_Id == projectId).ToList();
        }

        TeamModel ITeamModelsRepository.GetTeamModel(int teamModelId, bool inlcudeTeamModelSubjects)
        {
            if (inlcudeTeamModelSubjects)
                return DbContext.TeamModels.Include(t => t.TeamModelSubjects).Where(t => t.TeamModel_Id == teamModelId).FirstOrDefault();
            else
                return DbContext.TeamModels.Where(t => t.TeamModel_Id == teamModelId).FirstOrDefault();
        }
    }
}
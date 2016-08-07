﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models.Repositories
{
    public interface ITeamModelsRepository : IRepository<TeamModel>
    {
        ICollection<TeamModel> GetTeamModelByProjectId(int projectId);
        TeamModel GetTeamModel(int teamModelId, bool inlcudeTeamModelSubjects);

    }
}
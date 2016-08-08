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

        public ICollection<TeamModel> GetTeamModelCollection(int projectId)
        {
            //return DbContext.TeamModels.Include(t => t.TeamModelSubjects).Where(t => t.Project_Id == projectId).ToList();
            return DbContext.TeamModels.Include(t => t.TeamModelSubjects).Where(t => t.Project_Id == projectId).ToList();
        }

        public bool MarkSaveTeamModelWithSubjects(List<TeamModel> teamModel)
        {

            DbContext.TeamModels.AddRange(teamModel.Where(t => t.EntityState == ModelState.Added));
            DbContext.TeamModels.RemoveRange(teamModel.Where(t => t.EntityState == ModelState.Deleted));

            teamModel.All(t =>
            {
                if (t.EntityState == ModelState.Updated)
                    DbContext.Entry(t).State = EntityState.Modified;

                return true;
            });

            //DbContext.TeamModelSubjects.AddRange(teamModel.Select().Where(t => t.EntityState == ModelState.Added));
            //DbContext.TeamModelSubjects.RemoveRange(teamModel.Where(t => t.EntityState == ModelState.Deleted));



            //if (template.Template_Id == 0)
            //    //Make ADD
            //    DbContext.Templates.Add(template);
            //else
            //{
            //    DbContext.Subjects.RemoveRange(template.Subjects.Where(s => s.EntityState == ModelState.Deleted).ToList());
            //    DbContext.Subjects.AddRange(template.Subjects.Where(s => s.EntityState == ModelState.Added).ToList());

            //    //Attach the entity for all old and add new subjects
            //    DbContext.Entry(template).State = EntityState.Modified;

            //    //template.Subjects.All(s =>
            //    //{
            //    //    //if (s.EntityState == ModelState.Added)
            //    //    //    DbContext.Subjects.Add(s);
            //    //    //else if (s.EntityState == ModelState.Updated)
            //    //    //    DbContext.Entry(s).State = EntityState.Modified; else
            //    //    if (s.EntityState == ModelState.Deleted)
            //    //        DbContext.Subjects.Remove(s);

            //    //    return true;
            //    //});
            //}
            return true;

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
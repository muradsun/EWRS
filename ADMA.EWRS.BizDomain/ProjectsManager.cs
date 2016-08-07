using ADMA.EWRS.BizDomain.Engine;
using ADMA.EWRS.Data.Access;
using ADMA.EWRS.Data.Models;
using ADMA.EWRS.Data.Models.Security;
using ADMA.EWRS.Data.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.BizDomain
{

    /// <summary>
    /// Manage the Project and the project related item such as Templates and Team Model
    /// </summary>
    public class ProjectsManager : BaseManager
    {
        private UnitOfWork UnitOfWork { get { return base._unitOfWork; } }

        public ProjectsManager(IServiceProvider _provider)
            : base(_provider)
        {
            BusinessErrors = Enumerable.Empty<ADMA.EWRS.Data.Models.Validation.ValidationError>();
        }

        public ProjectsManager(IServiceProvider _provider, UnitOfWork unitOfWork)
            : base(_provider, unitOfWork)
        {
            BusinessErrors = Enumerable.Empty<ADMA.EWRS.Data.Models.Validation.ValidationError>();
        }


        public List<Project> GetProjects(int Owner_UserId, List<int> Delegated_UsersList)
        {
            return UnitOfWork.Projects.GetAllProjects(Owner_UserId, Delegated_UsersList).ToList();
        }

        public Project GetProject(int projectId)
        {
            return UnitOfWork.Projects.Find(p => p.Project_Id == projectId).FirstOrDefault();
        }

        public Subject GetSubject(int subjectId)
        {
            return UnitOfWork.Subjects.GetSubject(subjectId);
        }

        public Template GetTemplate(int templteId)
        {
            return UnitOfWork.Templates.GetTemplate(templteId, true);
        }

        public TeamModel GetTeamModel(int teamModelId)
        {
            return UnitOfWork.TeamModels.GetTeamModel(teamModelId, true);
        }

        public Template GetTemplateOrDefualt(int projectId)
        {
            if (projectId == 0)
                return GetDefualtTemplate(projectId);
            else
            {
                var temp = UnitOfWork.Templates.GetTemplate(projectId);
                if (temp != null)
                    return temp;
                else
                    return GetDefualtTemplate(projectId);
            }
        }

        public List<TeamModel> GetTeamModelOrDefualt(int projectId)
        {
            if (projectId == 0)
                return new List<TeamModel>();
            else
                return UnitOfWork.TeamModels.GetTeamModelByProjectId(projectId).ToList();
        }

        public List<OrganizationHierarchy> SearchOrganizationHierarchy(string orgName)
        {
            var escapOrgTypes = new List<string>(new string[] { "TC", "BG", null });
            return UnitOfWork.OrganizationHierarchies.Find(o => o.ORGNAME.Contains(orgName) && !escapOrgTypes.Contains(o.ORGTYPE)).ToList();
        }

        public OrganizationHierarchy GetOrganizationHierarchy(int orgId)
        {
            return UnitOfWork.OrganizationHierarchies.Find(o => o.ORGID == orgId).FirstOrDefault();
        }
        public bool SaveProject(Project project)
        {
            try
            {
                UnitOfWork.Projects.MarkSaveProject(project);

                var engine = new ProjectsEngine();
                //Make Validation//
                var errors = engine.Validate(project, UnitOfWork);
                if (errors != null && errors.Count() > 0)
                {
                    base.BusinessErrors = errors;
                    return false;
                }


                UnitOfWork.Save();

                return true;
            }
            catch (Framework.ExceptionHandling.ValidationException ex)
            {
                //Business validation Error
                base.BusinessErrors = ex.ValidationErrors;
                return false;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Template ExtractTemplate(TemplateWizardStepView templateWizardStepView, LoggedInUser currentUser)
        {
            Template temp;

            if (templateWizardStepView.Template_Id == 0)
                temp = new Template();
            else
                temp = GetTemplate(templateWizardStepView.Template_Id);

            temp.CreatedBy = temp.Template_Id > 0 ? temp.CreatedBy : currentUser.UserId.ToString();
            temp.CreatedDate = temp.Template_Id > 0 ? temp.CreatedDate : DateTime.Now;

            temp.UpdateBy = temp.Template_Id > 0 ? currentUser.UserId.ToString() : null;
            temp.UpdatedDate = temp.Template_Id > 0 ? DateTime.Now : (DateTime?)null;
            temp.Project_Id = templateWizardStepView.Project_Id;

            temp.Name = templateWizardStepView.Name;

            //Temp is old guy, has nothing to do with "Intercourse"...
            SubjectWizardStepView uiSubj = null;
            foreach (Subject sub in temp.Subjects)
            {
                //1. Get UI Subject 
                uiSubj = templateWizardStepView.Subjects.FirstOrDefault(s => s.Subject_Id == sub.Subject_Id);

                //2. If UI Subject Exists - Update the DB subject otherwise it has been deleted 
                if (uiSubj != null)
                {
                    sub.DueDate = uiSubj.DueDate;
                    sub.Name = uiSubj.Name;
                    sub.IsMandatory = uiSubj.IsMandatory;
                    sub.SequenceNo = uiSubj.SequenceNo;
                    sub.UpdateBy = currentUser.UserId.ToString();
                    sub.UpdatedDate = DateTime.Now;
                    sub.EntityState = Data.Models.ModelState.Updated;
                }
                else
                    sub.EntityState = ModelState.Deleted;
            }

            //Add the new items 
            temp.Subjects.AddRange(
                    templateWizardStepView.Subjects.Where(s => s.Subject_Id == 0).Select(s => new Subject()
                    {
                        Template_Id = temp.Template_Id,
                        Project_Id = temp.Project_Id,
                        Subject_Id = s.Subject_Id,
                        DueDate = s.DueDate,
                        Name = s.Name,
                        IsMandatory = s.IsMandatory,
                        SequenceNo = s.SequenceNo,

                        CreatedBy = currentUser.UserId.ToString(),
                        CreatedDate = DateTime.Now,

                        SubjectStatus_Id = (int)Data.Models.Enums.SubjectStatusEnum.Draft, // Murad Fix
                        EntityState = Data.Models.ModelState.Added

                    }).ToList()
                );


            //if (templateWizardStepView.Subjects != null && templateWizardStepView.Subjects.Count > 0)
            //{
            //    //Update the shared subject : Subjects in both UI and DB
            //    if (temp.Template_Id > 0)
            //    {
            //        //Get Joined Query 
            //        var query = from db_sub in temp.Subjects
            //                    join ui_sub in templateWizardStepView.Subjects on db_sub.Subject_Id equals ui_sub.Subject_Id
            //                    where db_sub.Subject_Id != 0 && ui_sub.Subject_Id != 0
            //                    select new { db_sub, ui_sub };

            //        query.All(
            //            s =>
            //            {
            //                //s.db_sub.Template_Id = s.db_sub.Template_Id;
            //                //s.db_sub.Project_Id = s.db_sub.Project_Id;
            //                //s.db_sub.Subject_Id = s.db_sub.Subject_Id;
            //                s.db_sub.DueDate = s.ui_sub.DueDate;
            //                s.db_sub.Name = s.ui_sub.Name;
            //                s.db_sub.IsMandatory = s.ui_sub.IsMandatory;
            //                s.db_sub.SequenceNo = s.ui_sub.SequenceNo;

            //                //s.db_sub.CreatedBy = s.db_sub.CreatedBy;
            //                //s.db_sub.CreatedDate = s.db_sub.CreatedDate;

            //                s.db_sub.UpdateBy = currentUser.UserId.ToString();
            //                s.db_sub.UpdatedDate = DateTime.Now;

            //                //s.db_sub.SubjectStatus_Id = s.db_sub.SubjectStatus_Id;
            //                s.db_sub.EntityState = Data.Models.ModelState.Updated;

            //                s.db_sub.PercentComplete = s.db_sub.PercentComplete;

            //                return true;
            //            }
            //        );

            //        //Deleted List: Subjects in DB not in UI
            //        var uiSubjectIds = templateWizardStepView.Subjects.Where(s => s.Subject_Id != 0).Select(s => s.Subject_Id).Distinct().ToList();
            //        temp.Subjects
            //            .Where(s => !uiSubjectIds.Contains(s.Subject_Id) && s.Subject_Id != 0)
            //            .ToList()
            //            .ForEach(s => s.EntityState = Data.Models.ModelState.Deleted);
            //    }

            //}

            return temp;
        }

        public bool SaveTemplate(Template template)
        {
            try
            {
                UnitOfWork.Templates.MarkSaveTemplateWithSubjects(template);

                var engine = new TemplateEngine();
                //Make Validation//
                var errors = engine.Validate(template, UnitOfWork);
                if (errors != null && errors.Count() > 0)
                {
                    base.BusinessErrors = errors;
                    return false;
                }

                UnitOfWork.Save();

                return true;
            }
            catch (Framework.ExceptionHandling.ValidationException ex)
            {
                //Business validation Error
                base.BusinessErrors = ex.ValidationErrors;
                return false;

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public List<TeamModel> ExtractTeamModel(List<TeamModeWizardStepView> teamModeWizardStepView, LoggedInUser currentUser)
        {
            List<TeamModel> teamList = new List<TeamModel>();
            TeamModel team;

            foreach (var item in teamModeWizardStepView)
            {
                if (item.TeamModel_Id == 0)
                    team = new TeamModel();
                else
                    team = GetTeamModel(item.TeamModel_Id);
            }

            //temp.CreatedBy = temp.Template_Id > 0 ? temp.CreatedBy : currentUser.UserId.ToString();
            //temp.CreatedDate = temp.Template_Id > 0 ? temp.CreatedDate : DateTime.Now;

            //temp.UpdateBy = temp.Template_Id > 0 ? currentUser.UserId.ToString() : null;
            //temp.UpdatedDate = temp.Template_Id > 0 ? DateTime.Now : (DateTime?)null;
            //temp.Project_Id = templateWizardStepView.Project_Id;

            //temp.Name = templateWizardStepView.Name;

            ////Temp is old guy, has nothing to do with "Intercourse"...
            //SubjectWizardStepView uiSubj = null;
            //foreach (Subject sub in temp.Subjects)
            //{
            //    //1. Get UI Subject 
            //    uiSubj = templateWizardStepView.Subjects.FirstOrDefault(s => s.Subject_Id == sub.Subject_Id);

            //    //2. If UI Subject Exists - Update the DB subject otherwise it has been deleted 
            //    if (uiSubj != null)
            //    {
            //        sub.DueDate = uiSubj.DueDate;
            //        sub.Name = uiSubj.Name;
            //        sub.IsMandatory = uiSubj.IsMandatory;
            //        sub.SequenceNo = uiSubj.SequenceNo;
            //        sub.UpdateBy = currentUser.UserId.ToString();
            //        sub.UpdatedDate = DateTime.Now;
            //        sub.EntityState = Data.Models.ModelState.Updated;
            //    }
            //    else
            //        sub.EntityState = ModelState.Deleted;
            //}

            ////Add the new items 
            //temp.Subjects.AddRange(
            //        templateWizardStepView.Subjects.Where(s => s.Subject_Id == 0).Select(s => new Subject()
            //        {
            //            Template_Id = temp.Template_Id,
            //            Project_Id = temp.Project_Id,
            //            Subject_Id = s.Subject_Id,
            //            DueDate = s.DueDate,
            //            Name = s.Name,
            //            IsMandatory = s.IsMandatory,
            //            SequenceNo = s.SequenceNo,

            //            CreatedBy = currentUser.UserId.ToString(),
            //            CreatedDate = DateTime.Now,

            //            SubjectStatus_Id = (int)Data.Models.Enums.SubjectStatusEnum.Draft, // Murad Fix
            //            EntityState = Data.Models.ModelState.Added

            //        }).ToList()
            //    );

            return teamList;
        }


        #region Private Members 

        private Template GetDefualtTemplate(int projectId)
        {
            return new Template()
            {
                Project_Id = projectId,
                Name = "Default Template",
                Subjects = new List<Subject>() {
                    new Subject() { Name = "Progress", IsMandatory= true, DueDate = null , SequenceNo = 1, Project_Id = projectId},
                    new Subject() { Name = "Planning", IsMandatory= true, DueDate = null , SequenceNo = 2,  Project_Id = projectId},
                    new Subject() { Name = "Problems", IsMandatory= true, DueDate = null , SequenceNo = 3, Project_Id = projectId}
                }
            };
        }



        #endregion

    }
}

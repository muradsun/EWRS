//Murad :: Info : Must ADD referance to Entity and Linq to see the extension methods
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ADMA.EWRS.Data.Models.Repositories;
using ADMA.EWRS.Data.Models;


namespace ADMA.EWRS.Data.Access.Repositories
{
    public class TemplateRepository : Repository<Template, EWRSContext>, ITemplatesRepository
    {
        public TemplateRepository(EWRSContext context)
            : base(context)
        {

        }

        public Template GetTemplate(int projectId)
        {
            return DbContext.Templates.Include(t => t.Subjects).Where(t => t.Project_Id == projectId).FirstOrDefault();
        }

        public Template GetTemplate(int templateId, bool includeSubjects)
        {
            if (includeSubjects)
                return DbContext.Templates.Include(t => t.Subjects).Where(t => t.Template_Id == templateId).FirstOrDefault();
            else
                return DbContext.Templates.Where(t => t.Template_Id == templateId).FirstOrDefault();
        }

        public bool MarkSaveTemplateWithSubjects(Template template)
        {
            //For Deleting Ya Who reading this code Read this :: https://blog.oneunicorn.com/2012/06/02/deleting-orphans-with-entity-framework/
            if (template.Template_Id == 0)
                //Make ADD
                DbContext.Templates.Add(template);
            else
            {
                DbContext.Subjects.RemoveRange(template.Subjects.Where(s => s.EntityState == ModelState.Deleted).ToList());
                DbContext.Subjects.AddRange(template.Subjects.Where(s => s.EntityState == ModelState.Added).ToList());

                //Attach the entity for all old and add new subjects
                DbContext.Entry(template).State = EntityState.Modified;

                //template.Subjects.All(s =>
                //{
                //    //if (s.EntityState == ModelState.Added)
                //    //    DbContext.Subjects.Add(s);
                //    //else if (s.EntityState == ModelState.Updated)
                //    //    DbContext.Entry(s).State = EntityState.Modified; else
                //    if (s.EntityState == ModelState.Deleted)
                //        DbContext.Subjects.Remove(s);

                //    return true;
                //});
            }
            return true;
        }
    }
}

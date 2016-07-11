using ADMA.EWRS.Data.Access;
using ADMA.EWRS.Data.Models;
using ADMA.EWRS.Data.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.BizDomain
{
    public class ProjectsManager : BaseManager
    {


        public ProjectsManager(IServiceProvider _provider)
            : base(_provider)
        {

        }

        public List<Project> GetProjects(int Owner_UserId, List<int> Delegated_UsersList)
        {
            using (var unitOfWork = new UnitOfWork())
                return unitOfWork.Projects.GetAllProjects(Owner_UserId, Delegated_UsersList).ToList();
        }

        public IEnumerable<Project> ProcessTopNRecordes(int count)
        {
            using (var unitOfWork = new UnitOfWork())
            {

                IEnumerable<Project> x = unitOfWork.Projects.GetTopNProjects(count);
                foreach (var item in x)
                {
                    item.CreatedBy = "MYassin";
                }

                return x;



                //// Example1
                //var course = unitOfWork.Muradies.GetTopMurad(3);
                //return course.ToList();

                //// Example2
                //var courses = unitOfWork.Courses.GetCoursesWithAuthors(1, 4);

                //// Example3
                //var author = unitOfWork.Authors.GetAuthorWithCourses(1);
                //unitOfWork.Courses.RemoveRange(author.Courses);
                //unitOfWork.Authors.Remove(author);
                //unitOfWork.Complete();
            }
        }




    }
}

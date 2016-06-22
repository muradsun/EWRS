using ADMA.EWRS.Data.Access;
using ADMA.EWRS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.BizDomain
{
    public class MuradManager
    {
        public MuradManager()
        {

        }

        public IEnumerable<Murad> GetTopMuradies(int count)
        {
            //Transaction support:see http://www.entityframeworktutorial.net/entityframework6/transaction-in-entity-framework.aspx
            //OR
            //Use Transaction scope

            using (var unitOfWork = new UnitOfWork())
            {

                //// Example1
                var course = unitOfWork.Muradies.GetTopMurad(3);
                //return course.ToList();

                //// Example2
                //var courses = unitOfWork.Courses.GetCoursesWithAuthors(1, 4);

                //// Example3
                //var author = unitOfWork.Authors.GetAuthorWithCourses(1);
                //unitOfWork.Courses.RemoveRange(author.Courses);
                //unitOfWork.Authors.Remove(author);
                //unitOfWork.Complete();
            }

            return null;
        }


    }
}

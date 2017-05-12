using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class SetNewQuestions
    {
       public static void SetQuestion(Question question)
        {

            using (var db = new Model())
            {
               
                db.Questions.Add(question);
                db.Entry(question.Course).State = EntityState.Unchanged;
                db.SaveChanges();
                
            }

        }
        public static void SetCourse(Course corse)
        {
            using (var db = new Model())
            {
                
                db.Courses.Add(corse);
                db.SaveChanges();

            }

        }
        public static List<Question> GetQuestion(int How)
        {
            List<Question> x = new List<Question>();
            using (var db = new Model())
            {
                x=db.Questions.ToList();
            }

            return x;
        }
        public static List<Course> GetCourse(int How)
        {

            List<Course> x = new List<Course>();
            using (var db = new Model())
            {
                x = db.Courses.ToList();
            }

            return x;
        }






    }
}

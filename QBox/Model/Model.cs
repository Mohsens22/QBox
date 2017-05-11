using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Model
{
    public class Model : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<Stat> Stats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=blogging.db");
        }


    }

    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }

    }
    public class Question
    {
        public int ID { get; set; }
        public Course Course { get; set; }

        public string Soal { get; set; }
        public List<Answer> Answer { get; set; }
        public int Correct { get; set; }
    }
    public class Answer
    {
        public int ID { get; set; }
        public int AssignedFlag { get; set; }
        public string Javab { get; set; }

    }
    public class Stat
    {
        public int ID { get; set; }
        public DateTime Created { get; set; }
        public int All { get; set; }
        public int Correct { get; set; }
        public Course Course { get; set; }

    }

}

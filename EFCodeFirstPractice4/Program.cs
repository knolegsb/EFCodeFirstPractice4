using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstPractice4
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyContext context = new CompanyContext();

            var financeTeam = new Team { TeamName = "Finance Team" };
            context.Teams.Add(financeTeam);
            context.SaveChanges();

            var teams = context.Teams;
            foreach (var team in teams)
            {
                Console.WriteLine("{0}, {1}", team.Id, team.TeamName);
            }

            Console.Read();
        }
    }

    //public class CompanyContext:DbContext
    //{
    //    public DbSet<Employee> Employees { get; set; }
    //    public DbSet<Team> Teams { get; set; }
    //    public DbSet<Club> Clubs { get; set; }
    //}

    //public class Employee
    //{
    //    public int Id { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public virtual Team Team { get; set; }
    //    public virtual ICollection<Club> Clubs { get; set; }
    //}

    //public class Team
    //{
    //    public int Id { get; set; }
    //    public string TeamName { get; set; }
    //    public virtual ICollection<Employee> Employees { get; set; }
    //}

    //public class Club
    //{
    //    public int Id { get; set; }
    //    public string ClubName { get; set; }
    //    public virtual ICollection<Employee> Employees { get; set; }
    //}
}

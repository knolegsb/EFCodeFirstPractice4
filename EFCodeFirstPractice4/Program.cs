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
            var devTeam = new Team { TeamName = "Development Team" };

            new List<Employee>
            {
                new Employee
                {
                    FirstName = "Soprano",
                    LastName = "Alto",
                    Team = devTeam
                },
                new Employee
                {
                    FirstName = "Monday",
                    LastName = "Date",
                    Team = financeTeam
                }
            }.ForEach(e => context.Employees.Add(e));

            //context.Teams.Add(financeTeam);
            context.SaveChanges();

            var employees = context.Employees;
            foreach (var employee in employees)
            {
                Console.WriteLine("{0}, {1}{2}", employee.Id, employee.FirstName, employee.LastName);
            }

            var empFromServer = context.Employees.Single(e => e.FirstName.Equals("Soprano"));
            empFromServer.FirstName = "Semptember";
            empFromServer.LastName = "Year";
            context.SaveChanges();

            var empUpdated = context.Employees.Single(e => e.FirstName.Equals("Semptember"));

            Console.WriteLine("{0}, {1}{2}", empUpdated.Id, empUpdated.LastName, empUpdated.FirstName);

            var empDelete = context.Employees.First();
            context.Employees.Remove(empDelete);
            context.SaveChanges();

            int empCounts = context.Employees.Count();
            Console.WriteLine("Total Employees : {0}", empCounts);



            //var teams = context.Teams;
            //foreach (var team in teams)
            //{
            //    Console.WriteLine("{0}, {1}", team.Id, team.TeamName);
            //}

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

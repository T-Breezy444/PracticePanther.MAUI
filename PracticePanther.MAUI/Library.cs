using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePanther.MAUI
{
    public class Client
    {
        //impliment the singleton design pattern
        private static Client _instance;
        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public static Client Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Client();
                }
                return _instance;
            }
        }
        private Client(int id = 0, DateTime openDate = new DateTime(), DateTime closeDate = new DateTime(), bool isActive = false, string name = "", string notes = "")
        {
            Id = id;
            OpenDate = openDate;
            CloseDate = closeDate;
            IsActive = isActive;
            Name = name;
            Notes = notes;
        }

    }

    public class Project
    {
        //singleton design pattern
        private static Project _instance;
        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public bool IsActive { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public int ClientId { get; set; }

        //singlton
        public static Project Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Project();
                }
                return _instance;
            }
        }
        private Project(int id = 0, DateTime openDate = new DateTime(), DateTime closeDate = new DateTime(), bool isActive = false, string shortName = "", string longName = "", int clientId = 0)
        {
            Id = id;
            OpenDate = openDate;
            CloseDate = closeDate;
            IsActive = isActive;
            ShortName = shortName;
            LongName = longName;
            ClientId = clientId;
        }

    }

    public class Employee
    {
        //singleton design pattern
        private static Employee _instance;
        public int Id { get; set; }
        public decimal Rate { get; set; }
        public string Name { get; set; }
        public static Employee Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Employee();
                }
                return _instance;
            }
        } 
        private Employee(int id = 0, decimal rate = 0, string name = "")
        {
            Id = id;
            Rate = rate;
            Name = name;
        }

    }

    //class to represent ime used to work on a project
    public class Time
    {
        //singleton desgin pattern
        private static Time _instance;
        public DateTime Date { get; set; }
        public string Narrative { get; set; }
        public decimal Hours { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public static Time Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Time();
                }
                return _instance;
            }
        }
        private Time(DateTime date = new DateTime(), string narrative = "", decimal hours = 0, int projectId = 0, int employeeId = 0)
        {
            Date = date;
            Narrative = narrative;
            Hours = hours;
            ProjectId = projectId;
            EmployeeId = employeeId;
        }
    }


}

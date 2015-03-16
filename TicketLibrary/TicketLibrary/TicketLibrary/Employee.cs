using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketLibrary
{
    public class Employee
    {
        private int employeeNumber;
        private string lastName;
        private string firstName;
        private int officeNumber;
        private string phoneNumber;
        private string email;
        private string jobDescription;



        //Getters and Setters
        public int EmployeeNumber
        {
            get { return employeeNumber; }
            set { employeeNumber = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public int OfficeNumber
        {
            get { return officeNumber; }
            set { officeNumber = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public string EMail
        {
            get { return email; }
            set { email = value; }
        }
        public string JobDescription
        {
            get { return jobDescription; }
            set { jobDescription = value; }
        }
     
        //Constructors
        public Employee(int employeeNumber, string lastName, string firstName, int officeNumber, string phoneNumber, string email, string jobDescription)
        {
            EmployeeNumber = employeeNumber;
            LastName = lastName;
            FirstName = firstName;
            OfficeNumber = officeNumber;
            PhoneNumber = phoneNumber;
            EMail = email;
            JobDescription = jobDescription;
            
        }
        public Employee(string lastName, string firstName, int officeNumber, string phoneNumber, string email)
        {
            
            LastName = lastName;
            FirstName = firstName;
            OfficeNumber = officeNumber;
            PhoneNumber = phoneNumber;
            EMail = email;
            

        }
        public Employee(int employeeNumber, string firstName, string lastName)
        {
            EmployeeNumber = employeeNumber;//as id
            FirstName = firstName;
            LastName = lastName;
        }
        public Employee(string lastName, int employeeNumber)
        {
            LastName = lastName;
            EmployeeNumber = employeeNumber;
        }
        public Employee(string lastName)
        {
            LastName = lastName;
           
        }
       
        
        
        
    }
}

  


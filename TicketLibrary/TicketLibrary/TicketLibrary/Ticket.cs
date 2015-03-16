using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketLibrary
{
    public class Ticket
    {
        private int ticketNumber;
        private int employeeNumber;
        private DateTime dateSubmitted;
        private String building;
        private String description;
        private String status;
        private int assignedTo;
        
        public Employee FirstName;
        public Employee LastName;
        public Employee OfficeNumber;
        public Employee PhoneNumber;
        public Employee EMail;


        public Employee SubmittedBy { get; set; }
        public Employee AssignedToEm { get; set; }
        public Employee Ee { get; set; }
        public Employee Mm { get; set; }
        


        public Ticket(int ticketNumber, int employeeNumber, DateTime dateSubmitted, String building, String description, String status, Employee assignedToEm)
        {
            TicketNumber = ticketNumber;
            EmployeeNumber = employeeNumber;
            DateSubmitted = dateSubmitted;
            Building = building;
            Description = description;
            Status = status;
            AssignedToEm = assignedToEm;
        }

        public Ticket(int ticketNumber, int employeeNumber, DateTime dateSubmitted, String building, String description, String status, int assignedTo)
        {
            TicketNumber = ticketNumber;
            EmployeeNumber = employeeNumber;
            DateSubmitted = dateSubmitted;
            Building = building;
            Description = description;
           Status = status;
         
            AssignedTo = assignedTo;
        }




        public Ticket(int employeeNumber, DateTime dateSubmitted, String building, String description, String status, int assignedTo)
        {
            EmployeeNumber = employeeNumber;
            DateSubmitted = dateSubmitted;
            Building = building;
            Description = description;
            Status = status;
            AssignedTo = assignedTo;
        }

     

        public Ticket(int ticketNumber, DateTime dateSubmitted, string building, string description, String status, Employee submittedBy, Employee assignedToEm)
        {

            TicketNumber = ticketNumber;
            DateSubmitted = dateSubmitted;
            Building = building;
            Description = description;
            Status = status;
            SubmittedBy = submittedBy;
            AssignedToEm = assignedToEm;
        }

        public Ticket(int ticketNumber,  string building, string description,  Employee submittedBy, Employee assignedToEm)
        {

            TicketNumber = ticketNumber;          
            Building = building;
            Description = description;          
            SubmittedBy = submittedBy;
            AssignedToEm = assignedToEm;
        }
        public Ticket(int employeeNumber, DateTime dateSubmitted, String building, String description)
        {

            EmployeeNumber = employeeNumber;
            DateSubmitted = dateSubmitted;
            Building = building;
            Description = description;
        }

   

        public Ticket(int ticketNumber)
        {
            TicketNumber = ticketNumber;

        }

        public Ticket(int TicketNumber, DateTime dateSubmitted, string Building, string Description, string Status, int AssignedTo, Employee ee, Employee mm)
        {
            TicketNumber = ticketNumber;
            DateSubmitted = dateSubmitted;
            Building = building;
            Description = description;
            Status = status;
            AssignedTo = assignedTo;
            Ee = ee;
            Mm = mm;

        }


        public Ticket(int ticketNumber, int employeeNumber, Employee firstName, Employee lastName, Employee officeNumber, Employee phoneNumber, Employee email, DateTime dateSubmitted, string building, string description, string status, int assignedTo)
        {
            TicketNumber = ticketNumber;
            EmployeeNumber = employeeNumber;
            FirstName = firstName;
            LastName = lastName;
            OfficeNumber = officeNumber;
            PhoneNumber = phoneNumber;
            EMail = email;
            DateSubmitted=dateSubmitted;
            Building=building;
            Description=description;
            Status=status;
            AssignedTo=assignedTo;
        }

        public Ticket(int ticketNumber, int employeeNumber, DateTime dateSubmitted, string building, string description, string status)
        {
            TicketNumber = ticketNumber;
            EmployeeNumber = employeeNumber;
            DateSubmitted =dateSubmitted;
            Building = building;
            Description = description;
            Status = status;
            //AssignedTo = assignedTo;
        }

        public Ticket(string status)
        {
            Status = status;
        }

        public Ticket(int assignedTo, int ticketNumber)
        {
            AssignedTo = assignedTo;
            TicketNumber = ticketNumber;
        }

        public int TicketNumber
        {
            get { return ticketNumber; }
            set { ticketNumber = value; }
        }
        public int EmployeeNumber
        {
            get { return employeeNumber; }
            set { employeeNumber = value; }
        }

        public DateTime DateSubmitted
        {
            get { return dateSubmitted; }
            set { dateSubmitted = value; }
        }

        public String Building
        {
            get { return building; }
            set { building = value; }
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        public String Status
        {
            get { return status; }
            set { status = value; }
        }

        public int AssignedTo
        {
            get { return assignedTo; }
            set { assignedTo = value; }
        }
    }
}

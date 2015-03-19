using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFTicketService
{

    [ServiceContract]
    public interface ITicketsService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        List<Ticket> SelectByEmpNum(int assignedToNum);

        [OperationContract]
        Ticket SelectTicketByID(int tickNum);

        [OperationContract]
        void UpdateCompleted(string completed, int ticketNum);

    }

    public class Ticket
    {
        private int ticketNumber;
        private int employeeNumber;
        private DateTime dateSubmitted;
        private String building;
        private String description;
        private String status;
        private int assignedTo;

        public Ticket(){} //this empty constructor has the impact of your connection

        //can use various contructors to assign values.

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

        public Ticket(int employeeNumber, DateTime dateSubmitted, String building, String description)
        {

            EmployeeNumber = employeeNumber;
            DateSubmitted = dateSubmitted;
            Building = building;
            Description = description;
        }
        public Ticket(int ticketNumber, String building, String description, String status)
        {

            TicketNumber = ticketNumber;
            Building = building;
            Description = description;
            Status = status;

        }

        public Ticket(int ticketNumber)
        {
            TicketNumber = ticketNumber;

        }

        public Ticket(int ticketNumber, int employeeNumber, DateTime dateSubmitted, string building, string description, string status)
        {
            TicketNumber = ticketNumber;
            EmployeeNumber = employeeNumber;
            DateSubmitted = dateSubmitted;
            Building = building;
            Description = description;
            Status = status;
        }

        public Ticket(string status)
        {
            Status = status;
        }


        //getters and setters
        [DataMember]
        public int TicketNumber
        {
            get { return ticketNumber; }
            set { ticketNumber = value; }
        }
        [DataMember]
        public int EmployeeNumber
        {
            get { return employeeNumber; }
            set { employeeNumber = value; }
        }
        [DataMember]
        public DateTime DateSubmitted
        {
            get { return dateSubmitted; }
            set { dateSubmitted = value; }
        }
        [DataMember]
        public String Building
        {
            get { return building; }
            set { building = value; }
        }
        [DataMember]
        public String Description
        {
            get { return description; }
            set { description = value; }
        }
        [DataMember]
        public String Status
        {
            get { return status; }
            set { status = value; }
        }
        [DataMember]
        public int AssignedTo
        {
            get { return assignedTo; }
            set { assignedTo = value; }
        }
    }
}
       

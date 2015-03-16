using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Ticket
{
	    private int ticketId;
        private DateTime currentDate;
        private int buildingId;
        private string issueDescription;
        private string status;
        private string email;
        private string employeeName;
        private string clientName;
        public Ticket() { }
        public Ticket(int ticketId, DateTime currentDate, int buildingId, string issueDescription, string status, string email, string employeeName)
        {
            TicketId = ticketId;
            CurrentDate = currentDate;
            BuildingId = buildingId;
            IssueDescription = issueDescription;
            Status = status;
            Email = email;
            EmployeeName = employeeName;
        }
        public Ticket(int ticketId, DateTime currentDate, int buildingId, string issueDescription, string status, string email)
        {
            TicketId = ticketId;
            CurrentDate = currentDate;
            BuildingId = buildingId;
            IssueDescription = issueDescription;
            Status = status;
            Email = email;
        }
        public int TicketId
        {
            get { return ticketId; }
            set { ticketId = value; }
        }

        public DateTime CurrentDate
        {
            get { return currentDate; }
            set { currentDate = value; }
        }
        public int BuildingId
        {
            get { return buildingId; }
            set { buildingId = value; }
        }

        public string IssueDescription
        {
            get { return issueDescription; }
            set { issueDescription = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public string ClientName
        {
            get { return clientName; }
            set { clientName = value; }
        }
        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }
    
	}

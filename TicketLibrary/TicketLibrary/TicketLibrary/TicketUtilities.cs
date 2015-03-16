using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketLibrary
{
    public class TicketUtilities
    {
        public static List<Ticket> GetAllTickets()
        {
            TicketData td = new TicketData();
            return td.SelectAllTickets();
        }


        public int InsertTicketNum(Ticket ttt)
        {
            int key=0;

            TicketData tdd = new TicketData();
            key=tdd.insertTicket(ttt);

            return key;
        }

        public Employee GetEmpNum(int empNum)
        {
            TicketData emp = new TicketData();
            return emp.SelectEmployeeByID(empNum);
        }

        public Ticket GetTicketByPin(int piN)
        {
            TicketData td = new TicketData();
            return td.SelectTicketByPin(piN);
        }

        
        public List<Ticket> GetPinByEmail(string email)
        {
            TicketData td = new TicketData();
            return td.SelectAllPinByEmail(email);
        }

        public int InsertEmp(Employee empN)
        {

            int key = 0;
            TicketData empNum = new TicketData();
            key=empNum.insertEmployee(empN);

            return key;
        }

        public List<Ticket> GetAllSubmittedTickets()
        {
            TicketData td = new TicketData();
            return td.SelectAllSubmittedTickets();
        }

        public List<Ticket> GetTicketByStatus(String status)
        {
            TicketData td = new TicketData();
            return td.SelectTicketFilterByStatus(status);
        }

        public List<Ticket> GetTicketByLastName()
        {
            TicketData td = new TicketData();
            return td.SelectAllTicketByLastName();
        }

        public List<Ticket> GetAllStatus()
        {
            TicketData td = new TicketData();
            return td.SelectAllStatus();
        }

        public List<Employee> GetAllLastName()
        {
            TicketData td = new TicketData();
            return td.SelectAllLastName();
        }

        public List<Employee> GetAllAssignedLastName()
        {
            TicketData td = new TicketData();
            return td.SelectAssignedAllLastName();
        }


        public List<Ticket> GetFilterByStatus(string status)
        {
            TicketData td = new TicketData();
            return td.SelectFilterByStatus();
        }

        public List<Ticket> GetFilterByLastName(int emNum)
        {
            TicketData td = new TicketData();
            return td.SelectFilterByEmpNum(emNum);
        }

        public List<Ticket> GetFilterByAssignedLN(int emNum)
        {
            TicketData td = new TicketData();
            return td.SelectFilterByAssignedLastName(emNum);
        }

        public void UpdateAssign(int assigNum, int tickNum, string sta)
        {     
            TicketData td = new TicketData();
            td.UpdateAssigned(assigNum, tickNum, sta);
        }

        public void UpdateStat(int assigNum, int tickNum, string sta)
        {
            TicketData td = new TicketData();
            td.UpdateStatus(assigNum, tickNum, sta);
        }
      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeeUtilities
/// </summary>
public class EmployeeUtilities
{
    public List<Building> SelectBuilding()
    {
        EmployeeData md = new EmployeeData();
        return md.SelectBuilding();
    }
    public List<Employee> SelectMainternanceEmployee()
    {
        EmployeeData md = new EmployeeData();
        return md.SelectMainternanceEmployee();
    }
    public int InsertTicket(Ticket ticket)
    {
        EmployeeData md = new EmployeeData();
        return md.InsertTicket(ticket);
    }
    public List<Ticket> SelectTicketByPin(int id)
    {
        EmployeeData md = new EmployeeData();
        return md.SelectTicketByPin(id);
    }

    public List<Ticket> SelectTicketByEmail(string email)
    {
        EmployeeData md = new EmployeeData();
        return md.SelectTicketByEmail(email);
    }
    public List<Ticket> SelectTicketByStatus(string status)
    {
        EmployeeData md = new EmployeeData();
        return md.SelectTicketByStatus(status);
    }
    public List<Ticket> SelectTicketByEmployeeName(string employeeName)
    {
        EmployeeData md = new EmployeeData();
        return md.SelectTicketByEmployeeName(employeeName);
    }
    public List<Ticket> SelectTicketByClientName(string clientName)
    {
        EmployeeData md = new EmployeeData();
        return md.SelectTicketByClientName(clientName);
    }
    public List<Ticket> SelectTicketById(int id)
    {
        EmployeeData md = new EmployeeData();
        return md.SelectTicketById(id);
    }
    public void UpdateTicket(int id, string status, string employeeName)
    {
        EmployeeData md = new EmployeeData();
        md.UpdateTicket(id, status, employeeName);
    }
    public void UpdateStatusTicket(int id, string status)
    {
        EmployeeData md = new EmployeeData();
        md.UpdateStatusTicket(id, status);
    }
    public void InsertEmployee(Employee employee)
    {
        EmployeeData md = new EmployeeData();
        md.InsertEmployee(employee);
    }
}
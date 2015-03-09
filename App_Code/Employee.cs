using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Employee
/// </summary>
public class Employee
{
    private int id;
    private string firstName;
    private string lastName;
    private string officeNumber;
    private string phoneNumber;
    private string email;
    private int employeeNumber;

    public Employee() { }
    public Employee(int id, string lastName)
    {
        Id = id;
        LastName = lastName;
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }
    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
    public string OfficeNumber
    {
        get { return officeNumber; }
        set { officeNumber = value; }
    }
    public string PhoneNumber
    {
        get { return phoneNumber; }
        set { phoneNumber = value; }
    }
    public string Email
    {
        get { return email; }
        set { email = value; }
    }
    public int EmployeeNumber
    {
        get { return employeeNumber; }
        set { employeeNumber = value; }
    }
}
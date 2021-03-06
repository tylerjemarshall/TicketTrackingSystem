﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TicketLibrary;

public partial class EZFacilities : System.Web.UI.Page
{
    //happens upon page load
    protected void Page_Load(object sender, EventArgs e)
    {
        //changes text box to current day in format yyyy-MM-dd on page load
        txtDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
      
    }
    //Submit button
    protected void btn1_Click(object sender, EventArgs e)
    {
        
        TicketUtilities tl = new TicketUtilities();
        //updates display box
        lblOutput.Text = "Thank you for your submission";
        
        //visible is changed depending on if employee exists
        //client can now enter new emp
        if (lblMessage.Visible)
        {
            Employee em = new Employee(Convert.ToInt32(txtEmpNum.Text), Convert.ToString(txtFN.Text), 
                Convert.ToString(txtLN.Text), Convert.ToInt32(txtOfficeNum.Text), 
                Convert.ToString(txtPhoneNum.Text), Convert.ToString(txtEmail.Text), Convert.ToString(DropDownList2.SelectedValue));
            tl.InsertEmp(em);

        }


        Ticket t = new Ticket(Convert.ToInt32(txtEmpNum.Text), Convert.ToDateTime(txtDate.Text), 
            Convert.ToString(DropDownList1.SelectedValue), Convert.ToString(txtIssueDesc.Text), "Submitted", 0);

        int tickNum = tl.InsertTicketNum(t);

        //clear all fields
        txtEmpNum.Text = "";
        txtFN.Text = "";
        txtLN.Text = "";
        txtOfficeNum.Text = "";
        txtPhoneNum.Text = "";
        txtEmail.Text = "";
        txtIssueDesc.Text = "";

        //displays pin (ticketNumber)
        lblPinNum.Text = "Your Pin is:" + tickNum;
            
    }

    //Continue button
    protected void btnAutoFill_Click(object sender, EventArgs e)
    {
        //populates text boxes based on Employee Number. Doesn't check if box is empty.

        txtFN.Enabled = true;
        txtLN.Enabled = true;
        txtOfficeNum.Enabled = true;
        txtPhoneNum.Enabled = true;
        txtEmail.Enabled = true;

        TicketUtilities tu = new TicketUtilities();
        int num = 0;
        //This was catching error, might be cause converting empty string to num. Going to catch.
        try{
            num = Convert.ToInt32(txtEmpNum.Text);
        } catch (FormatException fe) {
            if (fe.Source != null)
                lblOutput.Text=("IOException: "+ fe.Message);
            throw;}

        Employee emp = tu.GetEmpNum(num);

        if(emp != null)//if the record in database Employees table exists
        {
            txtFN.Text = emp.FirstName;
            txtLN.Text = emp.LastName;
            txtOfficeNum.Text = (emp.OfficeNumber).ToString();
            txtPhoneNum.Text = emp.PhoneNumber;
            txtEmail.Text = emp.EMail;

            DropDownList2.SelectedValue = emp.JobDescription;
            lblMessage.Visible = false;
            //lblmessage is for createing new employee
        }
        else
        {
            lblMessage.Text = "The Employee Number does not exist. Enter info to create new Employee";
            lblMessage.Visible = true;
        }
    }

    //checks status from ticket pin
    protected void btuView_Click(object sender, EventArgs e)
    {

        TicketUtilities pinNum = new TicketUtilities();
        Ticket ticket = pinNum.GetTicketByPin(Convert.ToInt32(txtPin.Text));
        GridView1.Visible = true;
        GridView1.DataBind();

    }


    //retrieves pin by email
    protected void btnEnter_Click(object sender, EventArgs e)
    {
        TicketUtilities tu = new TicketUtilities();

        string em = Convert.ToString(txtRetrieve.Text);
        List<Ticket> email = tu.GetPinByEmail(em);

        if (email.Count != 0)
        {
            GridView2.Visible = true;
            GridView2.DataBind();  
        }
        else
        {
            lblPin.Text = "Email address doesn't exist. Please try again!";
        } 
    }

}

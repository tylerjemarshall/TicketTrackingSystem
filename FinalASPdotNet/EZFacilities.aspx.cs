﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TicketLibrary;

public partial class EZFacilities : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
      
    }

    protected void btn1_Click(object sender, EventArgs e)
    {
        
        TicketUtilities tl = new TicketUtilities();
        lblOutput.Text = "Thank you for your submission";
        
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

        txtEmpNum.Text = "";
        txtFN.Text = "";
        txtLN.Text = "";
        txtOfficeNum.Text = "";
        txtPhoneNum.Text = "";
        txtEmail.Text = "";
        txtIssueDesc.Text = "";


        lblPinNum.Text = "Your Pin is:" + tickNum;
            
    }


    protected void btnAutoFill_Click(object sender, EventArgs e)
    {

        txtFN.Enabled = true;
        txtLN.Enabled = true;
        txtOfficeNum.Enabled = true;
        txtPhoneNum.Enabled = true;
        txtEmail.Enabled = true;

        TicketUtilities tu = new TicketUtilities();

        int num = Convert.ToInt32(txtEmpNum.Text);
        Employee emp = tu.GetEmpNum(num);

        if(emp != null)//if the record in database Employees table is not null do the following
        {
            txtFN.Text = emp.FirstName;
            txtLN.Text = emp.LastName;
            txtOfficeNum.Text = (emp.OfficeNumber).ToString();
            txtPhoneNum.Text = emp.PhoneNumber;
            txtEmail.Text = emp.EMail;

            DropDownList2.SelectedValue = emp.JobDescription;
            lblMessage.Visible = false;
        }
        else
        {
            lblMessage.Text = "The Employee Number does not exist. Enter info to create new Employee";
            lblMessage.Visible = true;
        }
    }

    protected void btuView_Click(object sender, EventArgs e)
    {

        TicketUtilities pinNum = new TicketUtilities();
        Ticket ticket = pinNum.GetTicketByPin(Convert.ToInt32(txtPin.Text));
        GridView1.Visible = true;
        GridView1.DataBind();

    }



    protected void btnEnter_Click(object sender, EventArgs e)
    {
        TicketUtilities tu = new TicketUtilities();

        string em = Convert.ToString(txtRetrieve.Text);
        List<Ticket> email = tu.GetPinByEmail(em);

        if (email.Count != 0)
        {
            GridView2.DataSource = email;
            GridView2.Visible = true;
            GridView2.DataBind();
            
           
        }
        else
        {
            lblPin.Text = "Email address doesn't exist. Please try again!";
        }

        
    }

}
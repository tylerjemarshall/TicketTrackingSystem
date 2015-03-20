using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TicketServiceRef;

public partial class EZMyTickets : System.Web.UI.Page
{
    //View Assigned Tickets
    protected void btnView_Click(object sender, EventArgs e)
    {
        TicketsServiceClient tsc = new TicketsServiceClient();
        int assignId = Convert.ToInt32(txtEmpNum.Text);

        //populates dropdownlist of tickets based on assignId

        DropDownList1.DataTextField = "TicketNumber";
        DropDownList1.DataBind();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //When selecting a ticket from the drop down box that was populated, changes data being displayed.
        TicketsServiceClient tsc = new TicketsServiceClient();
        int tickNum = Convert.ToInt32(DropDownList1.SelectedValue);
        Ticket tic = tsc.SelectTicketByID(tickNum);

        lblTicketNumber.Text = tic.TicketNumber.ToString();
        lblBuilding.Text = tic.Building;
        lblDescription.Text = tic.Description;
        lblStatus.Text = tic.Status;

        if (tic.Status == "Completed")
        {
            CheckBox1.Checked = true;
        }
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        //Task Completed check box (boolean true/false)
        TicketsServiceClient tsc = new TicketsServiceClient();
        if (CheckBox1.Checked) //if changed to completed
        {
            tsc.UpdateCompleted("Completed", Convert.ToInt32(lblTicketNumber.Text));
        }
        else //else, if box was unchecked, will change to assigned.
        {
            tsc.UpdateCompleted("Assigned", Convert.ToInt32(lblTicketNumber.Text));
        }
        int tickNum = Convert.ToInt32(DropDownList1.SelectedValue);
        Ticket tic = tsc.SelectTicketByID(tickNum);

        lblTicketNumber.Text = tic.TicketNumber.ToString();
        lblBuilding.Text = tic.Building;
        lblDescription.Text = tic.Description;
        lblStatus.Text = tic.Status;      
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TicketServiceRef;

public partial class EZMyTickets : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        TicketsServiceClient tsc = new TicketsServiceClient();
        int assignId = Convert.ToInt32(txtEmpNum.Text);
        //DropDownList1.DataSource = tsc.SelectByEmpNum(assignId);

        DropDownList1.DataTextField = "TicketNumber";
        DropDownList1.DataBind();

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
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
        TicketsServiceClient tsc = new TicketsServiceClient();
        if (CheckBox1.Checked)
        {
            tsc.UpdateCompleted("Completed", Convert.ToInt32(lblTicketNumber.Text));
        }
        else
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
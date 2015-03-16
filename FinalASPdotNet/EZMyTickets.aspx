<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EZMyTickets.aspx.cs" Inherits="EZMyTickets" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" GroupingText="My EZ Tickets App">
            Enter your Employee Number:
            <asp:TextBox ID="txtEmpNum" runat="server"></asp:TextBox>
            <asp:Button ID="btnView" runat="server" Text="View Assigned Tickets" OnClick="btnView_Click" style="margin-bottom: 0px" />
            <br />
            <br />
            Ticket Number:<asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" DataSourceID="ObjectDataSource2" DataTextField="TicketNumber" DataValueField="TicketNumber" ></asp:DropDownList>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="SelectByEmpNum" TypeName="TicketServiceRef.TicketsServiceClient">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtEmpNum" Name="assignedToNum" PropertyName="Text" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <br />
            <br />
                    Ticket ID: <asp:Label ID="lblTicketNumber" runat="server" Text=""></asp:Label> 
                    <br />
                    Ticket location: <asp:Label ID="lblBuilding" runat="server" Text=""></asp:Label>
                    <br />            
                    Ticket Description: <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
                    <br />
                    Ticket Status: <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                    <br />
                    <br />    
                    If Task Completed:<asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged"  />                    
        </asp:Panel>
    </div>
    </form>
</body>
</html>

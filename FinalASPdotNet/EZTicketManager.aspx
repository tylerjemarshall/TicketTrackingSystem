<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EZTicketManager.aspx.cs" Inherits="EZTicketManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" GroupingText="EZTicket Manager"><br />
            <table><tr>
                <td> <asp:Button ID="btuViewAll" runat="server" Text="View All Submitted Tickets" OnClick="btuViewAll_Click" /></td><td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="212px"  DataTextField="Status" DataValueField="Status" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"   ></asp:DropDownList></td><td>
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="20px" Width="231px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList></td><td>
                <asp:DropDownList ID="DropDownList3" runat="server" Height="20px" Width="231px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"></asp:DropDownList></td></tr>
            </table><br /><br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="TicketNumber" AutoGenerateEditButton="True" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                <Columns>
                    <asp:BoundField DataField="TicketNumber" HeaderText="TicketID" SortExpression="TicketNumber" ReadOnly="true" />
                    <asp:BoundField DataField="SubmittedBy.EmployeeNumber" HeaderText="SubByEmpID" SortExpression="SubmittedBy" ReadOnly="true" />
                    <asp:BoundField DataField="SubmittedBy.FirstName" HeaderText="FirstName" SortExpression="SubmittedBy" ReadOnly="true"/>
                    <asp:BoundField DataField="SubmittedBy.LastName" HeaderText="LastName" SortExpression="SubmittedBy" ReadOnly="true"/>
                    <asp:BoundField DataField="DateSubmitted" HeaderText="DateSubmitted" SortExpression="DateSubmitted" ReadOnly="true"/>
                    <asp:BoundField DataField="Building" HeaderText="Building" SortExpression="Building" ReadOnly="true"/>
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" ReadOnly="true"/>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>                          
                               <asp:DropDownList ID="DropDownList4" runat="server" ></asp:DropDownList>                                                           
                        </ItemTemplate>  
                        <EditItemTemplate>
                        </EditItemTemplate>
                    </asp:TemplateField>               
                    <asp:TemplateField  HeaderText="Assign To">
                        <ItemTemplate>
                           <asp:DropDownList ID="DropDownList5" runat="server"></asp:DropDownList>
                        </ItemTemplate>
                        <EditItemTemplate>
                            
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="AssignedToEm.EmployeeNumber" HeaderText="AssignToEmpID" SortExpression="AssignedToEm" ReadOnly="true"/>
                   
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </div>
    </form>
</body>
</html>

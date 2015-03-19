<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EZFacilities.aspx.cs" Inherits="EZFacilities" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:Panel ID="Panel1" runat="server" GroupingText="Tickets Tracking System">
            
            <table>
            <tr><td>EmployeeNumber:<asp:TextBox ID="txtEmpNum" runat="server"></asp:TextBox></td>
                <td>
                    <asp:Button ID="btnAutoFill" runat="server" Text="Continue" OnClick="btnAutoFill_Click" /></td>
             <td>
                 <asp:Label ID="lblMessage" runat="server" Text="Lable" ></asp:Label></td>
            </tr>
                <tr><td colspan="2">Name:</td>
                    <td>
                       
                    </td>
                   
                </tr>
                <tr>                    
                    <td><asp:TextBox ID="txtFN" Text="First Name" runat="server" Width="171px" Enabled="False"></asp:TextBox></td>
                             
                    <td><asp:TextBox ID="txtLN" Text="Last Name" runat="server" Width="160px" Enabled="False"></asp:TextBox></td>
                  
                </tr>
                <tr><td>Office Number:<asp:TextBox ID="txtOfficeNum" runat="server" Enabled="False"></asp:TextBox></td>
                    <td>Phone Number:<asp:TextBox ID="txtPhoneNum"  runat="server" Enabled="False"></asp:TextBox></td>
                </tr>
                <tr><td>Email:<asp:TextBox ID="txtEmail"  runat="server" Width="290px" Enabled="False"></asp:TextBox></td>
            
                    <td>Current Date:<asp:TextBox ID="txtDate" runat="server"></asp:TextBox></td>
                </tr>
                <tr><td class="auto-style1">Building with issue:
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>Main Office</asp:ListItem>
                        <asp:ListItem>Warehouse A</asp:ListItem>
                        <asp:ListItem>Warehouse B</asp:ListItem>
                        <asp:ListItem>West Annex</asp:ListItem>
                        <asp:ListItem>Downtown office</asp:ListItem>
                        <asp:ListItem>Transport pool</asp:ListItem>
                    </asp:DropDownList></td>
                    <td class="auto-style1">Job Description<asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem>Manager</asp:ListItem>
                        <asp:ListItem>Accountant</asp:ListItem>
                        <asp:ListItem>Marketing</asp:ListItem>
                        <asp:ListItem>Maintenance</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                    
                        
                </tr>
                <tr><td colspan="2"> Issue Description:<asp:TextBox ID="txtIssueDesc" runat="server" TextMode="MultiLine" Width="425px"></asp:TextBox></td>
                    <td></td>
                </tr>
   
            <tr><td colspan="2" > 
                <asp:Button ID="btn1" runat="server" Text="Submit" Width="142px" OnClick="btn1_Click" /> </td>
                <td></td>
            </tr>
                <tr><td colspan="2">
                    <asp:Label ID="lblOutput" runat="server" Text="Label"></asp:Label></td>
                    <td>
                        <asp:Label ID="lblPinNum" runat="server" Text="Label"></asp:Label></td>
                </tr>
            </table>
      
        </asp:Panel>
        <br />
        <asp:Panel ID="Panel2" runat="server" GroupingText="View Status">
            Enter Your Pin to view your status:<asp:TextBox ID="txtPin" runat="server" ></asp:TextBox>
            <asp:Button ID="btuView" runat="server" Text="View" Width="113px" />
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetTicketByPin" TypeName="TicketLibrary.TicketUtilities">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtPin" Name="piN" PropertyName="Text" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
                <Columns>
                    <asp:BoundField DataField="TicketNumber" HeaderText="TicketNumber" SortExpression="TicketNumber" />
                    <asp:BoundField DataField="EmployeeNumber" HeaderText="EmployeeNumber" SortExpression="EmployeeNumber" />
                    <asp:BoundField DataField="DateSubmitted" HeaderText="DateSubmitted" SortExpression="DateSubmitted" />
                    <asp:BoundField DataField="Building" HeaderText="Building" SortExpression="Building" />
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:BoundField DataField="AssignedTo" HeaderText="AssignedTo" SortExpression="AssignedTo" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            To Retrieve Your Pin Enter Email:<asp:TextBox ID="txtRetrieve" runat="server" Width="290px" TextMode="Email"></asp:TextBox>
            <asp:Button ID="btnEnter" runat="server" Text="Enter" OnClick="btnEnter_Click" />
            <br />
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetPinByEmail" TypeName="TicketLibrary.TicketUtilities">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtRetrieve" Name="email" PropertyName="Text" Type="String" DefaultValue="@Email" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2">
                <Columns>
                    <asp:BoundField DataField="TicketNumber" HeaderText="TicketNumber" SortExpression="TicketNumber" />
                    <asp:BoundField DataField="EmployeeNumber" HeaderText="EmployeeNumber" SortExpression="EmployeeNumber" />
                    <asp:BoundField DataField="DateSubmitted" HeaderText="DateSubmitted" SortExpression="DateSubmitted" />
                    <asp:BoundField DataField="Building" HeaderText="Building" SortExpression="Building" />
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:BoundField DataField="AssignedTo" HeaderText="AssignedTo" SortExpression="AssignedTo" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Label ID="lblPin" runat="server" Text="Label"></asp:Label>
        </asp:Panel><br />
        <asp:Panel ID="Panel3" runat="server">

        </asp:Panel>

    </div>
    </form>
</body>
</html>

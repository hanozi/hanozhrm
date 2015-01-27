<%@ Page Title="" Language="C#" MasterPageFile="~/Home/admin.master" AutoEventWireup="true" CodeFile="viewpayroll.aspx.cs" Inherits="Home_generatepayroll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="TextBox1" placeholder="Employee ID" AutoComplete="off" Height="25px" runat="server"></asp:TextBox>
    <asp:Label ID="Label2" runat="server" Text="Period"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>&lt;-select-&gt;</asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>7</asp:ListItem>
        <asp:ListItem>8</asp:ListItem>
        <asp:ListItem>9</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownList2" runat="server">
        <asp:ListItem>&lt;-select-&gt;</asp:ListItem>
        <asp:ListItem>2008</asp:ListItem>
        <asp:ListItem>2009</asp:ListItem>
        <asp:ListItem>2010</asp:ListItem>
        <asp:ListItem>2011</asp:ListItem>
        <asp:ListItem>2012</asp:ListItem>
        <asp:ListItem>2013</asp:ListItem>
        <asp:ListItem>2014</asp:ListItem>
        <asp:ListItem>2015</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
    <br /><br />
    <h1 id="Label13" runat="server" visible="False">No Record Found</h1>
    <table id="tab" runat="server" style="width:100%" visible="False">
        <tr>
            <th>Element</th><th>Days</th><th>Presence</th><th>Add/Deduct</th><th>Amount</th>
        </tr>
        <tr>
            <td>Basic</td>
            <td><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
            <td><asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
            <td>Add</td>
            <td><asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>Late or Early deduction</td>
            <td><asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></td>
            <td><asp:Label ID="Label21" runat="server" Text="Label"></asp:Label></td>
            <td>Deduct</td>
            <td><asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>PT</td>
            <td><asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></td>
            <td><asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></td>
            <td>Deduct</td>
            <td><asp:Label ID="Label9" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>Expenses</td>
            <td><asp:Label ID="Label14" runat="server" Text="Label"></asp:Label></td>
            <td><asp:Label ID="Label15" runat="server" Text="Label"></asp:Label></td>
            <td>Add</td>
            <td><asp:Label ID="Label16" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>Advance Adujstments</td>
            <td><asp:Label ID="Label17" runat="server" Text="Label"></asp:Label></td>
            <td><asp:Label ID="Label18" runat="server" Text="Label"></asp:Label></td>
            <td><asp:Label ID="Label20" runat="server" Text="Label"></asp:Label></td>
            <td><asp:Label ID="Label19" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3"> </td>
            <td>Gross Salary</td>
            <td><asp:Label ID="Label10" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3"> </td>
            <td>Total Deduction</td>
            <td><asp:Label ID="Label11" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3"> </td>
            <td>Net Salary</td>
            <td><asp:Label ID="Label12" runat="server" Text="Label"></asp:Label></td>
        </tr>
    </table>
    <div id="adjust" runat="server" visible="false">
        <asp:Label ID="Label22" runat="server" Text="Adjust Salary : "></asp:Label>
        <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true"/>
        <div id="check" runat="server">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label23" runat="server" Text="Computation Type"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList3" runat="server">
                            <asp:ListItem>Basic</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label24" runat="server" Text="Addition/Deduction"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList4" runat="server">
                            <asp:ListItem>Addition</asp:ListItem>
                            <asp:ListItem>Deduction</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label25" runat="server" Text="Amount"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="Button2_Click" />
                        <asp:Button ID="Button3" runat="server" Text="Reset" OnClick="Button3_Click"/>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>


<%@ Page Title="Controls" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BasicControls.aspx.cs" Inherits="WebApp.SamplePages.BasicControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Basic Controls</h1>
        <div class="row">
            <div class="col-sm-offset-1 col-sm-10">
                <div class="alert alert-info">
                    <blockquote style="font-style:italic">
                        This page will demonstrate some basic controls of a webpage. 
                        We will investigate the Checkbox, Textbox, RadioButtons, Lists, Dropdown List, Label, Literal and Submit button(Button and LinkButton).
                        The formatting of the controls will be done in a &lt;table&gt; tag. 
                        We will investigate event driven logic and how it differs from the top-down logic on Razor/form page
                    </blockquote>
                </div>
            </div>
        </div>
    <br />
    <table align="center" style="width: 80%">
        <tr>
            <td align="right">Textbox</td>
            <td>
                <asp:TextBox ID="TextBoxNumberChoice" runat="server"></asp:TextBox>
                <asp:Button ID="SubmitButtonChoice" runat="server" Text="Submit Choice" CssClass="btn btn-primary" OnClick="SubmitButtonChoice_Click" /> &nbsp;(Enter number from 1-4)
            </td>
        </tr>
        <tr>
            <td style="height: 22px" align="right">
                <asp:Label ID="Label1" runat="server" Text="RadioButtonList" Font-Bold="false"></asp:Label>
            </td>
            <td style="height: 22px">
                <asp:RadioButtonList ID="RadioButtonListChoice" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">COMP1008 &nbsp;&nbsp;</asp:ListItem>
                    <asp:ListItem Value="2">CPSC1517 &nbsp;&nbsp;</asp:ListItem>
                    <asp:ListItem Value="3">DMIT1508 &nbsp;&nbsp;</asp:ListItem>
                    <asp:ListItem Value="4">DMIT2018 &nbsp;&nbsp;</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Literal ID="Literal1" runat="server" Text="Choice: CheckBox"></asp:Literal>
            </td>
            
            <td>
                <asp:CheckBox ID="CheckBoxChoice" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label2" runat="server" Text="Display Label"></asp:Label>
            </td>
            <td>
                <asp:Label ID="DisplayDataReadOnly" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label3" runat="server" Text="View Collection"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="CollectionList" runat="server">
                    
                </asp:DropDownList>
                <asp:LinkButton ID="LinkButtonSubmitChoice" runat="server" OnClick="LinkButtonSubmitChoice_Click">Submit Collection Choice</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">

            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="MessageLabel" runat="server"></asp:Label>

            </td>
        </tr>
    </table>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="StudentRecordSystem.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form runat="server" class="border border-2 mt-5 p-5" style="margin: auto; width: 600px">
        <h3 class="display-5">Add Result</h3>
        <hr />
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    
                    <label class="form-label">Student Registration:</label>
                    <input type="text" runat="server" id="StdRegId" class="form-control" />
                    <label class="form-label">Course:</label>
                     <asp:DropDownList CssClass="col-md-4 col-form-label rounded rounded-3 mt-3" runat="server" ID="DrpListId"></asp:DropDownList>              
                </div>
                <div class="">
                    <asp:Button runat="server" CssClass="btn btn-outline-danger mt-3" Text="Search" OnClick="Submit_Click" />
                </div>
                <asp:Panel ID="PanelId" runat="server"></asp:Panel>
            </div>
        </div>
    </form>
</asp:Content>

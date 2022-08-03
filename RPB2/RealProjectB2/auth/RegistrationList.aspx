<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout/AdminMain.Master" AutoEventWireup="true" CodeBehind="RegistrationList.aspx.cs" Inherits="RealProjectB2.auth.RegistrationList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <asp:Label ID="lblHeading" CssClass="h3 mb-0 text-gray-800" runat="server" Text="User Registration Info"></asp:Label>
        <%-- <h1 class="h3 mb-0 text-gray-800">Dashboard</h1>--%>
        <a href="#" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fas fa-download fa-sm text-white-50"></i></a>
    </div>
    <div class="card">
        <div class="card-body">
            <div class="row">
                <div class="col-md-5">
                    <label class="form-label">Religion</label>
                    <asp:DropDownList ID="ddlReligion" runat="server" CssClass="form-control">
                    
                    </asp:DropDownList>
                </div>
                <div class="col-md-5">
                    <label class="form-label">Gender</label>
                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0">Select --</asp:ListItem>
                        <asp:ListItem Value="1">Male</asp:ListItem>
                        <asp:ListItem Value="2">Female</asp:ListItem>
                        <asp:ListItem Value="3">Others</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-2" style="margin-top:33px">
                    <asp:Button ID="btnSearch" runat="server"  CssClass="btn btn-success" Text="Search" OnClick="btnSearch_Click" />
                </div>
            </div>
        </div>
        <div class="card-header bg-gradient-primary text-light">
            User Registration Info
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-md-12">

                    <asp:GridView ID="gvRegList" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" OnRowCommand="gvRegList_RowCommand" >
                        <Columns>
                            <asp:BoundField DataField="UserName" HeaderText="User Name" />
                            <asp:BoundField DataField="Fullname" HeaderText="Full Name" />
                            <asp:BoundField DataField="Gender" HeaderText="Gender" />
                            <asp:BoundField DataField="DateofBirth" HeaderText="Date of Birth" />
                            <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
                            <asp:BoundField DataField="ReligionName" HeaderText="Religion Name" />
                            <asp:TemplateField>
                                <ItemTemplate>
            <asp:Image ID="Image1" runat="server" ImageUrl='<%# (string)BaseUrl((string)Eval("UserImage")) %>' Height="50" />
                                    <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("UserImage1") %>' Height="50" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action"  >
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnUserId" runat="server" Value='<%# Eval("UserId") %>' />
                                    <asp:ImageButton ID="imgUser" runat="server" CommandName="approve" CommandArgument='<%# Container.DataItemIndex %>' ImageUrl="~/assets/img/R.png" Width="25px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
            </div>
        </div>
    </div>

</asp:Content>

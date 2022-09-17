<%@ Page Title="" Language="C#" MasterPageFile="~/FleetApp/fleet.Master" AutoEventWireup="true" CodeBehind="ViewUsers.aspx.cs" Inherits="VehicleFleetManagment.FleetApp.ViewUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page-header start -->
    <div class="page-header">
        <div class="page-block">
            <div class="row align-items-center">
                <div class="col-md-8">
                    <div class="page-header-title">
                        <asp:Label class="m-b-10 h5" ID="txtSystemTitle" runat="server" Text=""></asp:Label>
                        <p>
                            <asp:Label class="m-b-0 p" ID="txtSlogan" runat="server" Text=""></asp:Label></p>
                    </div>
                </div>
                <div class="col-md-4">
                    <ul class="breadcrumb-title">
                        <li class="breadcrumb-item">
                            <a href="index.html"><i class="fa fa-home"></i></a>
                        </li>
                        <li class="breadcrumb-item"><a href="AddUsers.aspx">Add-User</a>
                        </li>
                        <li class="breadcrumb-item"><a href="ViewUsers.aspx">List-User</a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- Page-header end -->
    <div class="pcoded-inner-content">
        <!-- Main-body start -->
        <div class="main-body">
            <div class="page-wrapper">

                <!-- Page body start -->
                <div class="page-body">
                    <!-- Hover table card start -->
                    <div class="card">
                        <div class="card-header">
                            <h5 class="font-weight-bold">All Leave Records</h5>
                            <div class="card-header-right">
                                <ul class="list-unstyled card-option">
                                    <li><i class="fa fa fa-wrench open-card-option"></i></li>
                                    <li><i class="fa fa-window-maximize full-card"></i></li>
                                    <li><i class="fa fa-minus minimize-card"></i></li>
                                    <li></li>
                                    <li><a onserverclick="btnReload_click" runat="server" class="reload-card btn-out"><i class="fa fa-refresh"></i></a></li>
                                    <li><i class="fa fa-trash close-card"></i></li>
                                </ul>
                            </div>

                            <!-- Start Search  -->
                            <div class="row">
                                <div class="col-md-6 d-flex mx-auto mb-0 mt-0">
                                    <div class="col-md ">
                                        <div class="form-material">
                                            <div class="form-group form-primary">
                                                <input name="footer-email" class="form-control" id="txt_Search" runat="server" placeholder="search" ontextchanged="txt_Search_TextChanged" />
                                                <span class="form-bar"></span>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="col-md">
                                        <button class="btn btn-default" runat="server" onserverclick="btn_srch_Click"><i class="fa fa-search m-r-10"></i>search</button>

                                    </div>
                                </div>
                            </div>
                            <!-- end Search  -->
                            <div class="float-right mt-0 d-flex mb-0" runat="server" id="records">
                                <span runat="server" class="font-weight-bold mr-1">Records: </span>
                                <asp:Label ID="nbr" runat="server" Text="" class="text-danger font-weight-bold mr-1"> </asp:Label>
                            </div>

                            <div class="float-right mt-0 d-flex mb-0" runat="server" id="CountserchResult" visible="false">
                                <span runat="server" class="font-weight-bold mr-1">Search result: </span>
                                <asp:Label ID="txtSearchResult" runat="server" Text="" class="text-danger font-weight-bold mr-1"> </asp:Label>
                            </div>

                        </div>
                        <div class="card-block table-border-style">
                            <div class="table-responsive">
                                <div class=" ml-5  mb-2 mr-5" runat="server" id="DeleteAllVisibility" visible="false">
                                    <button runat="server" class="btn btn-default ml-5" onserverclick="DeleteCheck_Click">
                                        <i class="fa fa-trash"></i>
                                    </button>
                                </div>
                                <table class="">
                                    <asp:GridView ID="gdv" DataKeyNames="USERS_ID" ShowHeaderWhenEmpty="true" EmptyDataText="No Records" HeaderStyle-HorizontalAlign="Center"
                                        class="table  table-striped  table-borderless text-center gdv" HorizontalAlign="Center" HeaderStyle-Font-Bold="true"
                                        AutoGenerateColumns="false" EmptyDataRowStyle-Font-Size="X-Large" AllowPaging="true" PageSize="10" OnPreRender="gdv_PreRender"
                                        GridLines="None" EmptyDataRowStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#448aff" HeaderStyle-ForeColor="White"
                                        runat="server" Width="100%" OnRowCommand="gdv_RowCommand" OnPageIndexChanging="gdv_PageIndexChanging">

                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="checkSelHeader" runat="server" Text=" Select All" AutoPostBack="true" OnCheckedChanged="checkSelHeader_CheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="checkSel" runat="server" OnCheckedChanged="checkSel_CheckedChanged" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="USERS_ID" HeaderText="#" Visible="false" />

                                            <asp:TemplateField HeaderText="Ministry" FooterText="#" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("MINISTRY_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Picture">
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" runat="server" Width="50px" Height="40px" ImageUrl='<%# string.Concat("~/FleetApp/assets/images/Drivers/",Eval("Picture")) %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="First Name" FooterText="#">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("First_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Last Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Last_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="DOB">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("DOB") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Address" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Telephone">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblPhone" runat="server" Text='<%# Eval("Phone") %>'></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblMail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Role">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblRole" runat="server" Text='<%# Eval("ROLE_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblUserCode" runat="server" Text='<%# Eval("User_Code") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="state">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblState" runat="server" Text='<%# Eval("State") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Saved Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label99" runat="server" Text='<%# Eval("Saved_Date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="btn_Edit" class="btn btn-sm btn-primary" runat="server" Text="Edit" CommandName="edit" CommandArgument='<%# Eval("USERS_ID") %>' />
                                                    <asp:Button ID="Btn_state" class="btn btn-sm btn-secondary " runat="server" Text="State" CommandName="stat" CommandArgument='<%# Eval("USERS_ID") %>' OnClientClick="return confirm('Do you want to Block Him?')" />
                                                    <asp:Button ID="Btn_Delete" class="btn btn-sm btn-danger " runat="server" Text="Delete" CommandName="delet" CommandArgument='<%# Eval("USERS_ID") %>' OnClientClick="return confirm('Do you want to delete Him?')" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>

                                </table>
                            </div>
                        </div>

                        <div class="card-footer">
                            <asp:Label ID="indexFooter" runat="server"></asp:Label>
                        </div>
                    </div>
                    <!-- Hover table card end -->
                </div>
                <!-- Page body end -->
            </div>
        </div>
        <!-- Main-body end -->
        <div id="styleSelector">
        </div>
    </div>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/FleetApp/fleet.Master" AutoEventWireup="true" CodeBehind="ViewLeave.aspx.cs" Inherits="VehicleFleetManagment.FleetApp.ViewLeave" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page-header start -->
    <div class="page-header">
        <div class="page-block">
            <div class="row align-items-center">
                <div class="col-md-8">
                    <div class="page-header-title">
                        <h5 class="m-b-10">Vehicle Fleet Managment</h5>
                        <p class="m-b-0">Safety Rules Are Your Best Tools.</p>
                    </div>
                </div>
                <div class="col-md-4">
                    <ul class="breadcrumb-title">
                        <li class="breadcrumb-item">
                            <a href="index.html"><i class="fa fa-home"></i></a>
                        </li>
                        <li class="breadcrumb-item"><a href="AddLeave.aspx">Add-Leave</a>
                        </li>
                        <li class="breadcrumb-item"><a href="ViewLeave.aspx">List-Leave</a>
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
                            <div class=" col-md-6 mx-auto mb-0 mt-0">
                                <div class="row">
                                    <div class="col-md">
                                        <div class="form-material">
                                            <div class="form-group form-primary">
                                                <input type="text" name="footer-email" class="form-control" id="txt_Search" runat="server" placeholder="search">
                                                <span class="form-bar"></span>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="col-md">
                                        <button class="btn btn-default" runat="server" onserverclick="btn_srch_Click"><i class="fa fa-search m-r-10"></i>search</button>
                                        <%--<asp:Button ID="DeleteCheck" runat="server" Text="Delete All" class="btn btn-danger" OnClick="DeleteCheck_Click" />--%>
                                    </div>
                                </div>
                            </div>
                            <!-- end Search  -->
                            <div class="float-right mt-0 d-flex mb-0">
                                <span runat="server" class="font-weight-bold mr-1">Records: </span>
                                <asp:Label ID="nbr" runat="server" Text="" class="text-danger font-weight-bold mr-1"> </asp:Label>
                            </div>

                        </div>
                        <div class="card-block table-border-style">
                            <div class="table-responsive">
                                <table class="">
                                    <asp:GridView ID="gdv" DataKeyNames="LEAVE_ID" ShowHeaderWhenEmpty="true" EmptyDataText="No Records" HeaderStyle-HorizontalAlign="Center"
                                        class="table  table-striped  table-borderless text-center gdv" HorizontalAlign="Center" HeaderStyle-Font-Bold="true"
                                        AutoGenerateColumns="false" EmptyDataRowStyle-Font-Size="X-Large" AllowPaging="true" PageSize="10" OnPreRender="gdv_PreRender"
                                        GridLines="None" EmptyDataRowStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#448aff" HeaderStyle-ForeColor="White"
                                        runat="server" Width="100%" OnRowCommand="gdv_RowCommand" OnPageIndexChanging="gdv_PageIndexChanging">

                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="checkSelHeader" runat="server" Text="Select All" AutoPostBack="false" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="checkSel" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="#" FooterText="#">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("LEAVE_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Ministry" FooterText="#" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("MINISTRY_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Driver" FooterText="#">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("MIN_DRIVER_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           

                                            <asp:TemplateField HeaderText="Leave Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("LEAVE_TYPE_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Leave Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Leave_Code") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Demand Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Demand_Dte") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Approved Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Approved_Dte") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Start Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("Start_Dte") %>'></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="End Date" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("End_Dte") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Approved By" >
                                                <ItemTemplate>
                                                    <asp:Label ID="Label12" runat="server" Text='<%# Eval("Approved_By") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Carpooling" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label18" runat="server" Text='<%# Eval("Carpooling") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Comment" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label98" runat="server" Text='<%# Eval("Comment") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="btn_Edit" class="btn btn-sm btn-primary mr-4" runat="server" Text="Edit" CommandName="edit" CommandArgument='<%# Eval("LEAVE_ID") %>' />
                                                    <asp:Button ID="Btn_Delete" class="btn btn-sm btn-danger " runat="server" Text="Delete" CommandName="delet" CommandArgument='<%# Eval("LEAVE_ID") %>' OnClientClick="return confirm('Do you want to delete It?')" />
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

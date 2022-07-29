<%@ Page Title="" Language="C#" MasterPageFile="~/FleetApp/fleet.Master" AutoEventWireup="true" CodeBehind="Granted_Right.aspx.cs" Inherits="VehicleFleetManagment.FleetApp.Granted_Right" %>

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
                            <a href="Home.aspx"><i class="fa fa-home"></i></a>
                        </li>
                        <li class="breadcrumb-item"><a href="AddMenu.aspx">Add-Menu</a>
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
                    <div class="row">
                        <div class="col-sm-6 mx-auto">
                            <div class="alert alert-success alert-dismissible fade show" runat="server" id="SuccessMsg">
                                <button type="button" class="close" data-dismiss="alert">&times;</button>
                                <strong>Success!</strong>
                            </div>
                            <div class="alert alert-info alert-dismissible fade show" runat="server" id="FillMsg">
                                <button type="button" class="close" data-dismiss="alert">&times;</button>
                                <strong>Please complete all fields!</strong>
                            </div>
                            <div class="alert alert-danger alert-dismissible fade show" runat="server" id="FailMsg">
                                <button type="button" class="close" data-dismiss="alert">&times;</button>
                                <strong>Operation Failed!</strong>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h5>Menu</h5>
                                </div>
                                <div class="card-block">

                                    <div class="form-material">

                                        <div class="form-group form-default">
                                            <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Role" required="" runat="server">
                                            </asp:DropDownList>
                                            <label class="float-label">Role</label>
                                        </div>
                                    </div>
                                </div>

                                <!-- Hover table card start -->
                                <div class="col-md-12 mt-5">
                                    <div class="card">
                                        <div class="card-header">
                                            <h5 class="font-weight-bold">Role</h5>
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
                                            <div class="float-right mt-0 d-flex mb-0">
                                                <span runat="server" class="font-weight-bold mr-1">Records: </span>
                                                <asp:Label ID="nbr" runat="server" Text="" class="text-danger font-weight-bold mr-1"> </asp:Label>
                                            </div>

                                        </div>
                                        <div class="card-block table-border-style">
                                            <div class="table-responsive">

                                                <table class="">
                                                    <asp:GridView ID="gdv" DataKeyNames="RowId" ShowHeaderWhenEmpty="true" EmptyDataText="No Records" HeaderStyle-HorizontalAlign="Center"
                                                        class="table  table-striped  table-borderless text-center gdv" HorizontalAlign="Center" HeaderStyle-Font-Bold="true"
                                                        AutoGenerateColumns="false" EmptyDataRowStyle-Font-Size="X-Large" AllowPaging="true" PageSize="10" OnPreRender="gdv_PreRender"
                                                        GridLines="None" EmptyDataRowStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#448aff" HeaderStyle-ForeColor="White"
                                                        runat="server" Width="100%" OnRowCommand="gdv_RowCommand" OnPageIndexChanging="gdv_PageIndexChanging">

                                                        <Columns>

                                                            <asp:BoundField DataField="RowId" HeaderText="#" Visible="false" />

                                                            <asp:TemplateField HeaderText="Role">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Menu_Code") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Access">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="checkSel" runat="server" OnCheckedChanged="checkSel_CheckedChanged" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="Action">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btn_update" class="btn btn-sm btn-primary mr-4" runat="server" Text="Update" CommandName="edit" CommandArgument='<%# Eval("RowId") %>' />
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
                                </div>
                                <!-- Hover table card end -->

                            </div>
                        </div>
                    </div>
                </div>
                <!-- Page body end -->
            </div>
        </div>
        <!-- Main-body end -->
    </div>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/FleetApp/fleet.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="VehicleFleetManagment.FleetApp.Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <!-- Page-header start -->
    <div class="page-header">
        <div class="page-block">
            <div class="row align-items-center">
                <div class="col-md-8">
                    <div class="page-header-title">
                        <asp:Label class="m-b-10 h5" ID="txtSystemTitle" runat="server" Text="" ></asp:Label>
                        <p><asp:Label class="m-b-0 p" ID="HeaderSlogan" runat="server" Text="" ></asp:Label></p>
                    </div>
                </div>
                <div class="col-md-4">
                    <ul class="breadcrumb-title">
                        <li class="breadcrumb-item">
                            <a href="Home.aspx"><i class="fa fa-home"></i></a>
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
                    <!--Start Main Card -->

                    <!-- Setting Message-->
                    <div class="col-sm-6 mx-auto">
                        <div class="alert alert-success alert-dismissible fade show" runat="server" id="SuccessMsg">
                            <button type="button" class="close" data-dismiss="alert">&times;</button>
                            <strong>Reset Default</strong>
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

                    <!-- Role Message-->
                    <div class="col-sm-6 mx-auto">
                        <div class="alert alert-success alert-dismissible fade show" runat="server" id="successMsgRole">
                            <button type="button" class="close" data-dismiss="alert">&times;</button>
                            <strong>Success!</strong>
                        </div>
                        <div class="alert alert-info alert-dismissible fade show" runat="server" id="EmptyRoleMsg">
                            <button type="button" class="close" data-dismiss="alert">&times;</button>
                            <strong>Please complete all fields!</strong>
                        </div>
                        <div class="alert alert-danger alert-dismissible fade show" runat="server" id="failMsgRole">
                            <button type="button" class="close" data-dismiss="alert">&times;</button>
                            <strong>Operation Failed!</strong>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-12">
                            <!-- Tab variant tab card start -->
                            <div class="card">
                                <div class="card-header">
                                    <h5>Settings</h5>
                                </div>
                                <div class="card-block tab-icon">

                                    <!-- Nav tabs -->
                                    <ul class="nav nav-tabs md-tabs " role="tablist">
                                        <li class="nav-item">
                                            <a class="nav-link active" role="tab" runat="server" id="tabSettings" onserverclick="ActiveSettings_click"><i class="icofont icofont-home"></i>Setting</a>
                                            <div class="slide"></div>
                                        </li>
                                        <li class="nav-item">
                                            <a class="nav-link" role="tab" runat="server" id="tabProfile" onserverclick="ActiveProfile_click"><i class="icofont icofont-ui-settings"></i>Profile</a>
                                            <div class="slide"></div>
                                        </li>

                                        <li class="nav-item">
                                            <a class="nav-link" role="tab" runat="server" id="tabRole" onserverclick="ActiveRole_click"><i class="icofont icofont-ui-settings"></i>Role</a>
                                            <div class="slide"></div>
                                        </li>
                                        
                                    </ul>
                                    <!-- Tab panes -->
                                    <div class="tab-content card-block">
                                        <!-- MULTIVIEW  -->
                                        <asp:MultiView ID="MultiView" runat="server">

                                            <!--Setting  info Tab  -->
                                            <asp:View ID="ViewSettings" runat="server">
                                                <div class="row card-block">

                                                    <div class="col-md-12">
                                                        <div class="form-material">
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtSysName">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Change System Name</label>
                                                            </div>

                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtSysTitle">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Change System Title</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="email" name="footer-email" class="form-control" required="" runat="server" id="txtSysMaile">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Change System Email</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtSlogan">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Change Slogan</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtTheme">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Change Theme</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <asp:FileUpload ID="file_updLogo" name="footer-email" data-parsley-trigger="change" required="" autocomplete="off" class="form-control text-right" runat="server" />
                                                                <span class="form-bar"></span>
                                                                <label class="float-label ">Change Logo:.ico,.png,.jpg</label>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="card-footer">
                                                    <div class="float-right">
                                                        <button type="button" id="btnSave" class="btn btn-primary ml-5 waves-effect" runat="server" onserverclick="btn_save_Click">Save Changes</button>
                                                        <button type="reset" class="btn btn-danger ml-5" runat="server" id="btnCancel">Cancel</button>
                                                    </div>
                                                </div>
                                            </asp:View>
                                            <!-- end Settings Tab  -->
                                          
                                            <!--  Profile Tab  -->
                                            <asp:View ID="ViewProfile" runat="server">
                                                <div class="row card-block">
                                                    <div class="d-flex">
                                                        <div class="col-md-5 ">
                                                            <div class="form-group form-default">
                                                                <label class="float-label">Name:  </label>
                                                                <asp:Label ID="txtName" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                            </div>

                                                            <div class="form-group form-default">
                                                                <label class="float-label">Telephone: </label>
                                                                <asp:Label ID="txtTel" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <label class="float-label">Address: </label>
                                                                <asp:Label ID="txtAddress" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                            </div>

                                                            <div class="form-group form-default">
                                                                <label class="float-label">Fax : </label>
                                                                <asp:Label ID="txtFax" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <label class="float-label">Postal Code:</label>
                                                                <asp:Label ID="txtPostal" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <label class="float-label">Ministry Code :</label>
                                                                <asp:Label ID="txtCode" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                            </div>

                                                        </div>

                                                        <div class="col-md-7">
                                                            <div class="form-group form-default ">
                                                                <asp:Image ID="Image1" runat="server" Width="170px" Height="190px" BorderStyle="Solid" BorderWidth="1px" BorderColor="BlueViolet" AlternateText="No Picture" />
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>

                                            </asp:View>
                                            <!-- Profile Tab  -->

                                            <!--  Role Tab  -->
                                            <asp:View ID="ViewRole" runat="server">
                                                <div class=" card-block">

                                                    <div class="form-material">
                                                        <div class="form-group form-default">
                                                            <input type="text" name="footer-email" class="form-control" runat="server" id="txtRole">
                                                            <span class="form-bar"></span>
                                                            <label class="float-label">Role</label>
                                                        </div>

                                                        <div class="form-group form-default">
                                                            <input type="text" name="footer-email" class="form-control" runat="server" id="txtDescript">
                                                            <span class="form-bar"></span>
                                                            <label class="float-label">Description</label>
                                                        </div>

                                                    </div>
                                                    <div class="card-footer">
                                                        <div class="float-right">
                                                            <div class="float-right">
                                                                <button type="button" id="btnSaveRole" class="btn btn-primary ml-5 waves-effect" runat="server" onserverclick="btn_save_role_Click">Save</button>
                                                                <button type="reset" class="btn btn-danger ml-5" runat="server" id="btnCancelRole">Cancel</button>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>

                                                <!-- Hover table card start -->
                                                <div class="col-md-12 mt-5">
                                                    <div class="card">
                                                        <div class="card-header">
                                                            <h5 class="font-weight-bold">Role</h5>
                                                            <div class="card-header-right">
                                                                <ul class="list-unstyled card-option">
                                                                    <li><i class="fa fa fa-wrench open-card-option"></i></li>
                                                                    <li><i class="fa fa-window-maximize full-card"></i></li>
                                                                    <li><i class="fa fa-minus minimize-card"></i></li>
                                                                    <li><a onserverclick="btnReload_click" runat="server" class="reload-card btn-out"><i class="fa fa-refresh"></i></a></li>
                                                                    <li><a onserverclick="DeleteCheck_Click" runat="server" class="reload-card btn-out"><i class="fa fa-trash"></i></a></li>
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
                                                            <div class="float-right mt-0 d-flex mb-0">
                                                                <span runat="server" class="font-weight-bold mr-1">Records: </span>
                                                                <asp:Label ID="nbr" runat="server" Text="" class="text-danger font-weight-bold mr-1"> </asp:Label>
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
                                                                    <asp:GridView ID="gdv" DataKeyNames="ROLE_ID" ShowHeaderWhenEmpty="true" EmptyDataText="No Records" HeaderStyle-HorizontalAlign="Center"
                                                                        class="table  table-striped  table-borderless text-center gdv" HorizontalAlign="Center" HeaderStyle-Font-Bold="true"
                                                                        AutoGenerateColumns="false" EmptyDataRowStyle-Font-Size="X-Large" AllowPaging="true" PageSize="10" OnPreRender="gdv_PreRender"
                                                                        GridLines="None" EmptyDataRowStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#448aff" HeaderStyle-ForeColor="White"
                                                                        runat="server" Width="100%" OnRowCommand="gdv_RowCommand" OnPageIndexChanging="gdv_PageIndexChanging">

                                                                        <Columns>
                                                                            <asp:TemplateField>
                                                                                <HeaderTemplate>
                                                                                    <asp:CheckBox ID="checkSelHeader" runat="server" Text="Select All" AutoPostBack="true" OnCheckedChanged="checkSelHeader_CheckedChanged" />
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="checkSel" runat="server" OnCheckedChanged="checkSel_CheckedChanged" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:BoundField DataField="ROLE_ID" HeaderText="#" Visible="false" />

                                                                            <asp:TemplateField HeaderText="Role" >
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Role_Name") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="Description">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Descrept") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>


                                                                            <asp:TemplateField HeaderText="Action">
                                                                                <ItemTemplate>
                                                                                    <asp:Button ID="btn_Edit" class="btn btn-sm btn-primary mr-4" runat="server" Text="Edit" CommandName="edit" CommandArgument='<%# Eval("ROLE_ID") %>' />
                                                                                    <asp:Button ID="Btn_Delete" class="btn btn-sm btn-danger " runat="server" Text="Delete" CommandName="delet" CommandArgument='<%# Eval("ROLE_ID") %>' OnClientClick="return confirm('Do you want to delete It?')" />
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

                                            </asp:View>

                                             <!--  Role Tab  -->
                                        </asp:MultiView>
                                        <!-- END MULTIVIEW  -->
                                    </div>
                                </div>
                            </div>
                            <!-- Tab variant tab card start -->
                        </div>
                    </div>
                    <!--End Main Card -->

                </div>
                <!-- Page body end -->
            </div>
        </div>
        <!-- Main-body end -->
        <div id="styleSelector"></div>
    </div>

</asp:Content>

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

                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-header">
                                <h5>Customize your Settings</h5>
                            </div>
                            <div class="card-block">
                                <!-- Nav tabs -->
                                <ul class="nav nav-tabs md-tabs tabs-left b-none" role="tablist">
                                    <li class="nav-item">
                                        <a class="nav-link " data-toggle="tab" href="#profile5" role="tab">Profile</a>
                                        <div class="slide"></div>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link active" data-toggle="tab" href="#settings5" role="tab">Settings</a>
                                        <div class="slide"></div>
                                    </li>
                                </ul>
                                <!-- Tab panes -->
                                <div class=" col-md-12 tab-content tabs-left-content ">
                                    <!-- Profile -->
                                    <div class="tab-pane" id="profile5" role="tabpanel">
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
                                                <div class="form-group form-default">
                                                    <label class="float-label">User Name :</label>
                                                    <asp:Label ID="txtUserName" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="col-md-7">
                                                <div class="form-group form-default ">
                                                    <asp:Image ID="Image1" runat="server" Width="170px" Height="190px" BorderStyle="Solid" BorderWidth="1px" BorderColor="BlueViolet" AlternateText="No Picture" />
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    <!-- end Profile -->

                                    <!-- Settings -->

                                    <div class="tab-pane active" id="settings5" role="tabpanel">
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
                                        <div class="form-material">
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtSysName">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Change System Name</label>
                                            </div>
                                            <%--<div class="form-group form-default">
                                                    <input type="password" name="footer-email" class="form-control" required="" runat="server" id="txtPassword">
                                                    <i class="far fa-eye" id="togglePassword" style="margin-left: -30px; cursor: pointer;"></i>
                                                    <span class="form-bar"></span>
                                                    <label class="float-label">Password</label>
                                                </div>--%>
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
                                        <div class="card-footer">
                                            <div class="float-right">
                                                <div class="float-right">
                                                    <button type="button" id="btnSave" class="btn btn-primary ml-5 waves-effect" runat="server" onserverclick="btn_save_Click" >Save Changes</button>
                                                    <button type="reset" class="btn btn-danger ml-5" runat="server" id="btnCancel">Cancel</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!--end Settings -->
                                </div>
                            </div>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/FleetApp/fleet.Master" AutoEventWireup="true" CodeBehind="AddMinistry.aspx.cs" Inherits="VehicleFleetManagment.FleetApp.AddMinistry" %>

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
                        <p><asp:Label class="m-b-0 p" ID="txtHeaderSlogan" runat="server" Text="" ></asp:Label></p>
                    </div>
                </div>
                <div class="col-md-4">
                    <ul class="breadcrumb-title">
                        <li class="breadcrumb-item">
                            <a href="Home.aspx"><i class="fa fa-home"></i></a>
                        </li>
                        <li class="breadcrumb-item"><a href="AddMinistry.aspx">Add Ministry</a>
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

                    <div class="row">
                        <div class="col-sm-12">
                            <!-- Tab variant tab card start -->
                            <div class="card">
                                <div class="card-header">
                                    <h5>Ministry</h5>
                                </div>
                                <div class="card-block tab-icon">

                                    <!-- Nav tabs -->
                                    <ul class="nav nav-tabs md-tabs " role="tablist">
                                        <li class="nav-item">
                                            <a class="nav-link active" role="tab" runat="server" id="tabGen" onserverclick="ActiveGen_click"><i class="icofont icofont-home"></i>General</a>
                                            <div class="slide"></div>
                                        </li>
                                        <li class="nav-item">
                                            <a class="nav-link" role="tab" id="tabSettings" runat="server" onserverclick="ActiveSettings_click"><i class="icofont icofont-ui-settings"></i>Settings</a>
                                            <div class="slide"></div>
                                        </li>
                                    </ul>
                                    <!-- Tab panes -->
                                    <div class="tab-content card-block">
                                        <asp:MultiView ID="MultiView" runat="server">
                                            <!--General Ministriy info Tab  -->
                                            <asp:View ID="ViewGeneral" runat="server">
                                                <div class="tab-content col-md-8 mx-auto card-block" id="home7">
                                                    <div class="form-material">
                                                        <div class="form-group form-default">
                                                            <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtName">
                                                            <span class="form-bar"></span>
                                                            <label class="float-label">Name</label>
                                                        </div>

                                                        <div class="form-group form-default">
                                                            <input type="tel" name="footer-email" class="form-control" required="" runat="server" id="txtTel">
                                                            <span class="form-bar"></span>
                                                            <label class="float-label">Telephone</label>
                                                        </div>
                                                        <div class="form-group form-default">
                                                            <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtAddress">
                                                            <span class="form-bar"></span>
                                                            <label class="float-label">Address</label>
                                                        </div>

                                                        <div class="form-group form-default">
                                                            <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtFax">
                                                            <span class="form-bar"></span>
                                                            <label class="float-label">Fax</label>
                                                        </div>
                                                        <div class="form-group form-default">
                                                            <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtPostal">
                                                            <span class="form-bar"></span>
                                                            <label class="float-label">Postal Code</label>
                                                        </div>
                                                       
                                                        <div class="form-group form-default">
                                                            <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtCode" visible="false">
                                                        </div>
                                                    </div>
                                                </div>


                                                <div class="card-footer">
                                                    <div class="float-right">
                                                        <a class="btn btn-sm btn-info ml-5" href="ViewMinistry.aspx">List <i class="icofont icofont-listine-dots"></i></a>
                                                        <button type="reset" class="btn btn-sm btn-danger ml-5 mr-5">Cancel</button>
                                                    <button type="button" id="btnGenNext" class="btn btn-sm btn-default ml-5 waves-effect ml-5  " runat="server" onserverclick="ActiveSettings_click">Next <i class="icofont icofont-hand-drawn-right"></i></button>
                                                    </div>
                                                </div>
                                            </asp:View>
                                            <!-- End General Ministriy info Tab  -->

                                            <!--  Settings Ministriy info Tab  -->
                                            <asp:View ID="ViewSettings" runat="server">
                                                <div class="card-block col-md-8 mx-auto">
                                                    <div class="form-material">
                                                        <div class="form-group form-default">
                                                            <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtSysName">
                                                            <span class="form-bar"></span>
                                                            <label class="float-label">System Name</label>
                                                        </div>
                                                        
                                                        <div class="form-group form-default">
                                                            <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtSysTitle">
                                                            <span class="form-bar"></span>
                                                            <label class="float-label">System Title</label>
                                                        </div>
                                                        <div class="form-group form-default">
                                                            <input type="email" name="footer-email" class="form-control" required="" runat="server" id="txtSysMaile">
                                                            <span class="form-bar"></span>
                                                            <label class="float-label">System Email</label>
                                                        </div>
                                                        <div class="form-group form-default">
                                                            <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtSlogan">
                                                            <span class="form-bar"></span>
                                                            <label class="float-label">Slogan</label>
                                                        </div>
                                                        <div class="form-group form-default">
                                                            <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtTheme">
                                                            <span class="form-bar"></span>
                                                            <label class="float-label">Theme</label>
                                                        </div>
                                                        
                                                        <div class="form-group form-default">
                                                            <asp:FileUpload ID="file_upd" name="footer-email" data-parsley-trigger="change" required="" autocomplete="off" class="form-control text-right" runat="server" />
                                                            <span class="form-bar"></span>
                                                            <label class="float-label ">Picture:.ico,.png,.jpg</label>
                                                        </div>
                                                        <div class="form-group form-default">
                                                            <asp:FileUpload ID="file_updLogo"  name="footer-email" data-parsley-trigger="change" required="" autocomplete="off" class="form-control text-right" runat="server" />
                                                            <span class="form-bar"></span>
                                                            <label class="float-label ">Logo:.ico,.png,.jpg</label>
                                                        </div>
                                                    </div>
                                                </div>
                                                   <button type="button" id="BtnSettingsPreview" class="btn btn-sm btn-default  waves-effect" runat="server" onserverclick="ActiveGen_click"><i class="icofont icofont-hand-drawn-left"></i>Preview</button>
                                                        <div class="float-right">
                                                            <button type="button" id="btnSave" class="btn btn-sm btn-primary ml-5 waves-effect" runat="server" onserverclick="btn_save_Click">Save <i class="icofont icofont-save"></i></button>
                                                            <button type="reset" class="btn btn-sm btn-danger ml-5">Cancel</button>
                                                            <a class="btn btn-sm btn-info ml-5" href="ViewMinistry.aspx">List <i class="icofont icofont-listine-dots"></i></a>

                                                        </div>

                                            </asp:View>
                                            <!-- End Settings Ministriy info Tab  -->
                                        </asp:MultiView>

                                    </div>
                                </div>

                            </div>
                            <!-- Tab variant tab card start -->
                        </div>
                    </div>

                </div>
                <!-- Page body end -->
            </div>
        </div>
        <!-- Main-body end -->
        <div id="styleSelector"></div>
    </div>
    <script>
        const togglePassword = document.querySelector('#togglePassword');
        const password = document.querySelector('#txtPassword');

        togglePassword.addEventListener('click', function (e) {
            // toggle the type attribute
            const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
            password.setAttribute('type', type);
            // toggle the eye slash icon
            this.classList.toggle('fa-eye-slash');
        });
    </script>
</asp:Content>

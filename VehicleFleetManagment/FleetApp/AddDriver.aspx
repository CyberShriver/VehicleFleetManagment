<%@ Page Title="" Language="C#" MasterPageFile="~/FleetApp/fleet.Master" AutoEventWireup="true" CodeBehind="AddDriver.aspx.cs" Inherits="VehicleFleetManagment.FleetApp.AddDriver" %>

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
                        <p class="m-b-0">Safety Rules Are Your Best Tools</p>
                    </div>
                </div>
                <div class="col-md-4">
                    <ul class="breadcrumb-title">
                        <li class="breadcrumb-item">
                            <a href="Home.aspx"><i class="fa fa-home"></i></a>
                        </li>
                        <li class="breadcrumb-item"><a href="AddDriver.aspx">Add-Driver</a>
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
                    <div class="card">
                        <div class="card-header">
                            <h5>Driver</h5>
                        </div>
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
                            <div class="col-md-6">
                                <div class="card">
                                    <div class="card-header">
                                        <h5>General information</h5>
                                    </div>
                                    <div class="card-block">
                                        <div class="form-material">

                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtFullName">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Full Name</label>
                                            </div>

                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Gender" required="" runat="server">
                                                    <asp:ListItem>Male</asp:ListItem>
                                                    <asp:ListItem>Female</asp:ListItem>
                                                    <asp:ListItem>other</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Gender</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="date" class="form-control text-right" required="" runat="server" id="dateBirth">
                                                <span class="form-bar"></span>
                                                <label class="float-label  ">DOB</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtNationality">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Nationality</label>
                                            </div>
                                             <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Marital" required="" runat="server">
                                                    <asp:ListItem>Single</asp:ListItem>
                                                    <asp:ListItem>Married</asp:ListItem>
                                                    <asp:ListItem>Divorced</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Marital Status</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control bfh-languages"  name="footer-email" Style="width: 100%;" ID="DropDown_language" required="" runat="server">
                                                    <asp:ListItem>Kirundi</asp:ListItem>
                                                    <asp:ListItem>Kinyarwanda</asp:ListItem>
                                                    <asp:ListItem>Francais</asp:ListItem>
                                                    <asp:ListItem>Swahili</asp:ListItem>
                                                    <asp:ListItem>English</asp:ListItem>
                                                    <asp:ListItem>Spanish</asp:ListItem>
                                                    <asp:ListItem>Portugal</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Mother Langage</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtCNI">
                                                <span class="form-bar"></span>
                                                <label class="float-label">CNI</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtAddress1">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Address 1</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtAddress2">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Address 2</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtAddress3">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Address 3</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="tel" name="footer-email" class="form-control" required="" runat="server" id="txtTel">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Personal Phone</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:FileUpload ID="file_upd" name="footer-email" data-parsley-trigger="change" required=""  autocomplete="off" class="form-control text-right" runat="server" />
                                                <span class="form-bar"></span>
                                                <label class="float-label ">Pic:.ico,.png,.jpg</label>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="card">
                                    <div class="card-header">
                                        <h5>Professional</h5>
                                    </div>
                                    <div class="card-block">
                                        <div class="form-material">
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtCode">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Driver Code</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDownList_DriverType" required="" runat="server">
                                                    <asp:ListItem>Vehicle</asp:ListItem>
                                                    <asp:ListItem>Motor</asp:ListItem>
                                                    <asp:ListItem>Trail</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Driver Type</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="email" name="footer-email" class="form-control" required="" runat="server" id="txtMail">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Email (example@gmail.com)</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtPostal">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Postal Code</label>
                                            </div>
                                            <div class="form-group form-default"">
                                                <input type="tel" name="footer-email" class="form-control" data-tip="only number required" required="" runat="server" id="txtTelOffice" title="phone number" pattern="[0-9]{3}-[0-9]{2}-[0-9]{3}-[0-9]{3}">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Office Phone  </label> 
                                                
                                            </div>
                                        </div>
                                                  
                                    </div>
                                </div>
                            </div>
                               
                        </div>

                        <div class="card-footer">
                            <div class="float-right">
                                <button type="button" id="btnSave" class="btn btn-primary ml-5 waves-effect" runat="server" onserverclick="btn_save_Click">Save</button>
                                <button type="reset" class="btn btn-danger ml-5">Cancel</button>
                                <a class="btn btn-info ml-5" href="ViewDriver.aspx">List</a>
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
    <script>
        $("#txtTelOffice").intlTelInput({
            utilsScript: "https://cdnjs.cloudflare.com/ajax/libs/intl-tel-input/8.4.6/js/utils.js"
        });

        $("#txtTelOffice").intlTelInput();
    </script>
</asp:Content>

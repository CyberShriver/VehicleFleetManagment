﻿<%@ Page Title="" Language="C#" MasterPageFile="~/FleetApp/fleet.Master" AutoEventWireup="true" CodeBehind="AddProvider.aspx.cs" Inherits="VehicleFleetManagment.FleetApp.AddProvider" %>

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
                            <a href="Home.aspx"><i class="fa fa-home"></i></a>
                        </li>
                        <li class="breadcrumb-item"><a href="AddProvider.aspx">Add Provider</a>
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
                                <strong>Something goes wrong!! please try again</strong>
                            </div>
                            <div class="alert alert-info alert-dismissible fade show" runat="server" id="ExistMsg">
                                <button type="button" class="close" data-dismiss="alert">&times;</button>
                                <strong>Already saved!</strong>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h5>Provider</h5>
                                </div>
                                <div class="row card-block">
                                    <div class="col-md-6">
                                        <div class="form-material">                                           
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control"  runat="server" id="txtCode" visible="false">
                                            </div>

                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtFullName">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Full Name</label>
                                            </div>

                                            <div class="form-group form-default">
                                                <input type="date" class="form-control text-right" required="" runat="server" id="dateBirth">
                                                <span class="form-bar"></span>
                                                <label class="float-label  ">DOB</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:TextBox ID="txtCNI" class="form-control" required="" runat="server" OnTextChanged="OnTextChanged_txtCNI" AutoPostBack="true"></asp:TextBox>
                                                <span class="form-bar"></span>
                                                <label class="float-label">CNI</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtAddress">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Address</label>
                                            </div>

                                            <div class="form-group form-default">
                                                <input type="tel" name="footer-email" class="form-control" required="" runat="server" id="txtTel">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Telephone</label>
                                            </div>
                                          
                                        </div>

                                    </div>

                                    <div class="col-md-6">
                                        <div class="form-material">
                                              <div class="form-group form-default">
                                                <input type="email" name="footer-email" class="form-control" required="" runat="server" id="txtMail">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Email</label>
                                            </div>
                                             <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_ProviderType" required="" runat="server">
                                                    <asp:ListItem>Internal Tank</asp:ListItem>
                                                    <asp:ListItem>External Tank</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Provider Type</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Status" required="" runat="server">
                                                    <asp:ListItem>Activate</asp:ListItem>
                                                    <asp:ListItem>Deactivate</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">State</label>
                                            </div>

                                            <div class="form-group form-default">
                                                <asp:FileUpload ID="file_upd" name="footer-email" data-parsley-trigger="change" required="" autocomplete="off" class="form-control text-right" runat="server" />
                                                <span class="form-bar"></span>
                                                <label class="float-label ">Provider Picture:.png,.jpg</label>
                                            </div>

                                            <div class="form-group form-default">
                                                <asp:FileUpload ID="file_updContract" name="footer-email" data-parsley-trigger="change" required="" autocomplete="off" class="form-control text-right" runat="server" />
                                                <span class="form-bar"></span>
                                                <label class="float-label ">Contract:.png,.jpg</label>
                                            </div>

                                            <div class="form-group form-default" runat="server" id="displayContract" visible="false">
                                            <a href="#" class="btn btn-danger" onClick="newWindow=window.open('<%=ImgView %>');newWindow.print();"> Open Contract </a>
                                             </div>
                                        </div>

                                    </div>
                                </div>

                                <div class="card-footer">
                                    <div class="float-right">
                                        <button type="submit" id="btnSave" class="btn btn-primary ml-5 waves-effect" runat="server" onserverclick="btn_save_Click">Save</button>
                                        <button type="button" id="btnEmpty" class="btn btn-dark ml-5 waves-effect" runat="server" onserverclick="btn_Empty_Click" visible="false">Empty</button>
                                        <button type="reset" class="btn btn-danger ml-5">Cancel</button>
                                        <a class="btn btn-info ml-5" href="ViewProvider.aspx">List</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Page body end -->
            </div>
        </div>
        <!-- Main-body end -->
        <div id="styleSelector">
        </div>
    </div>

</asp:Content>

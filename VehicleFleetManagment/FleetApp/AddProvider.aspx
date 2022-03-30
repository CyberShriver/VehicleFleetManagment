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
                        <h5 class="m-b-10">Vehicle Fleet Managment</h5>
                        <p class="m-b-0">Safety Rules Are Your Best Tools</p>
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
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h5>Provider</h5>
                                </div>
                                <div class="card-block">

                                    <div class="form-material">
                                        <div class="form-group form-default">
                                            <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_ProviderType" required="" runat="server">
                                                <asp:ListItem>Internal Tank</asp:ListItem>
                                                <asp:ListItem>External Tank</asp:ListItem>
                                            </asp:DropDownList>
                                            <label class="float-label">Provider Type</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtCode">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Provider Code</label>
                                        </div>

                                       <div class="form-group form-default">
                                            <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtFullName">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Full Name</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <input type="tel" name="footer-email" class="form-control" required="" runat="server" id="txtTel">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Telephone</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <input type="email" name="footer-email" class="form-control" required="" runat="server" id="txtMail">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Email</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Status" required="" runat="server">
                                                <asp:ListItem>enable</asp:ListItem>
                                                <asp:ListItem>desable</asp:ListItem>
                                            </asp:DropDownList>
                                            <label class="float-label">Status</label>
                                        </div>
                                    </div>
                                </div>

                                <div class="card-footer">
                                    <div class="float-right">
                                        <asp:Button ID="btn_save" class="btn btn-primary ml-5" runat="server" Text="Save" />
                                        <button type="reset" class="btn btn-danger ml-5">Cancel</button>
                                        <a class="btn btn-info ml-5" href="ViewProvider.aspx">View</a>
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
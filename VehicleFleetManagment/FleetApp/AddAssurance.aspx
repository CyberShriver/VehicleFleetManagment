﻿<%@ Page Title="" Language="C#" MasterPageFile="~/FleetApp/fleet.Master" AutoEventWireup="true" CodeBehind="AddAssurance.aspx.cs" Inherits="VehicleFleetManagment.FleetApp.AddAssurance" %>

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
                        <li class="breadcrumb-item"><a href="AddAssurance.aspx">Add Assurance</a>
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
                            <h5>Assurance</h5>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="card">
                                    <div class="card-block">
                                        <div class="form-material">
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Plate" required="" runat="server"> </asp:DropDownList>
                                                <label class="float-label">Plate</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Ministry" required="" runat="server"> </asp:DropDownList>
                                                <label class="float-label">Ministry</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtMaintenance">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Maintenance Type</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtInsurancePolicy">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Insurance Policy</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtInsuranceCompany">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Insurance Company</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="date" class="form-control text-right" required="" runat="server" id="dateStart">
                                                <span class="form-bar"></span>
                                                <label class="float-label  ">Start Date</label>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="card">
                                    <div class="card-block">
                                        <div class="form-material">
                                            <div class="form-group form-default">
                                                <input type="date" name="footer-email" class="form-control text-right" required="" runat="server" id="dateExp">
                                                <span class="form-bar"></span>
                                                <label class="float-label ">Expire Date</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="date" name="footer-email" class="form-control text-right" required="" runat="server" id="dateLocalExp">
                                                <span class="form-bar"></span>
                                                <label class="float-label ">Local expire date</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="number" name="footer-email" class="form-control" required="" runat="server" id="txtAmount">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Amount</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="dropDown_AssuranceStatus" required="" runat="server">
                                                    <asp:ListItem>Validate</asp:ListItem>
                                                    <asp:ListItem>No validate</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Status</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <textarea class="form-control" required="" runat="server" id="txtComment"></textarea>
                                                <span class="form-bar"></span>
                                                <label class="float-label">Comment</label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card-footer">
                            <div class="float-right">
                                <asp:Button ID="btn_save" class="btn btn-primary ml-5" runat="server" Text="Save" />
                                <button type="reset" class="btn btn-danger ml-5">Cancel</button>
                                <a class="btn btn-info ml-5" href="ViewAssurance.aspx">List</a>
                            </div>
                        </div>
                    </div>
                    <!--End Main Card -->

                </div>
                <!-- Page body end -->
            </div>
        </div>
        <!-- Main-body end -->
        <div id="styleSelector"> </div>
    </div>

</asp:Content>

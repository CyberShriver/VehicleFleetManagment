﻿<%@ Page Title="" Language="C#" MasterPageFile="~/FleetApp/fleet.Master" AutoEventWireup="true" CodeBehind="AddMOT.aspx.cs" Inherits="VehicleFleetManagment.FleetApp.AddMOT" %>

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
                        <p><asp:Label class="m-b-0 p" ID="txtSlogan" runat="server" Text="" ></asp:Label></p>
                    </div>
                </div>
                <div class="col-md-4">
                    <ul class="breadcrumb-title">
                        <li class="breadcrumb-item">
                            <a href="Home.aspx"><i class="fa fa-home"></i></a>
                        </li>
                        <li class="breadcrumb-item"><a href="AddMOT.aspx">Add MOT</a>
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
                            <h5>MOT</h5>
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
                                    <div class="card-block">
                                        <div class="form-material">
                                            <div class="form-group form-default" id="DMinistry" runat="server">
                                                <asp:DropDownList class="form-control " name="footer-email" OnSelectedIndexChanged="dropDown_Ministry_SelectedIndexChanged" AutoPostBack="true" Style="width: 100%;" ID="DropDown_Ministry" required="" runat="server"></asp:DropDownList>
                                                <label class="float-label">Ministry</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Plate" required="" runat="server"></asp:DropDownList>
                                                <label class="float-label">Plate</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtMOT">
                                                <span class="form-bar"></span>
                                                <label class="float-label">MOT N°</label>
                                            </div>

                                        </div>
                                    </div>
                            </div>

                            <div class="col-md-6">
                                    <div class="card-block">
                                        <div class="form-material">
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtAgency">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Agency Name</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="date" name="footer-email" class="form-control text-right" required="" runat="server" id="dateVisit">
                                                <span class="form-bar"></span>
                                                <label class="float-label ">Visit Date</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="date" name="footer-email" class="form-control text-right" required="" runat="server" id="dateExpValidity">
                                                <span class="form-bar"></span>
                                                <label class="float-label ">Expire Validity</label>
                                            </div>
                                        </div>
                                    </div>
                            </div>
                        </div>
                        <div class="card-footer">
                            <div class="float-right">
                                <button type="submit" id="btnSave" class="btn btn-primary ml-5 waves-effect" runat="server" onserverclick="btn_save_Click">Save</button>
                                <button type="reset" class="btn btn-danger ml-5">Cancel</button>
                                <a class="btn btn-info ml-5" href="ViewMOT.aspx">List</a>
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

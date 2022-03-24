﻿<%@ Page Title="" Language="C#" MasterPageFile="~/FleetApp/fleet.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="VehicleFleetManagment.FleetApp.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page-header start -->
    <div class="page-header">
        <div class="page-block">
            <div class="row align-items-center">
                <div class="col-md-8">
                    <div class="page-header-title">
                        <h5 class="m-b-10">Basic Form Inputs</h5>
                        <p class="m-b-0">Lorem Ipsum is simply dummy text of the printing</p>
                    </div>
                </div>
                <div class="col-md-4">
                    <ul class="breadcrumb-title">
                        <li class="breadcrumb-item">
                            <a href="index.html"><i class="fa fa-home"></i></a>
                        </li>
                        <li class="breadcrumb-item"><a href="#!">Form Components</a>
                        </li>
                        <li class="breadcrumb-item"><a href="#!">Basic Form Inputs</a>
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
                        <div class="col-md-6">
                            <div class="card">
                                <div class="card-header">
                                    <h5>General information</h5>
                                </div>
                                <div class="card-block">
                                    <div class="form-material">

                                        <div class="form-group form-default">
                                            <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtCode">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Code</label>
                                        </div>

                                        <div class="form-group form-default">
                                            <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtPlate">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Plate</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <input type="Text" name="footer-email" class="form-control" required="" runat="server" id="txtName">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Name</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <input type="text" name="footer-email" class="form-control" required=""  runat="server" id="txtModel">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Model</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <input type="text" name="footer-email" class="form-control" required=""  runat="server" id="txtColor">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Color</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtEngineNumber">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Engine N°</label>
                                        </div>
                                         <div class="form-group form-default">
                                            <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtChassis">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Chassis N°</label>
                                        </div>

                                        <div class="form-group form-default">
                                            <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtEngineManif">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Engine Manufacturer</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <input type="password" name="footer-email" class="form-control" required="" runat="server" id="txtPicture">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Picture</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <input type="text" name="footer-email" class="form-control" required=""  runat="server" id="txtStatus">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Status </label>
                                        </div>

                                        <div class="form-group form-default">
                                            <textarea class="form-control" required=""></textarea>
                                            <span class="form-bar"></span>
                                            <label class="float-label">Text area Input</label>
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
                                            <input type="text" name="footer-email" class="form-control" required="">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Username</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <input type="text" name="footer-email" class="form-control" required="">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Email (exa@gmail.com)</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <input type="password" name="footer-email" class="form-control" required="">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Password</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <input type="text" name="footer-email" class="form-control" required="" value="My value">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Predefine value</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <input type="text" name="footer-email" class="form-control" required="" disabled>
                                            <span class="form-bar"></span>
                                            <label class="float-label">Disabled</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <input type="text" name="footer-email" class="form-control" required="" maxlength="6">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Max length 6 char</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <textarea class="form-control" required=""></textarea>
                                            <span class="form-bar"></span>
                                            <label class="float-label">Text area Input</label>
                                        </div>
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

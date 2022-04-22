<%@ Page Title="" Language="C#" MasterPageFile="~/FleetApp/fleet.Master" AutoEventWireup="true" CodeBehind="AddLicense.aspx.cs" Inherits="VehicleFleetManagment.FleetApp.AddLicense" %>

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
                        <li class="breadcrumb-item"><a href="AddLicense.aspx">Add-License</a>
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
                            <h5>License</h5>
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
                                    <div class="card-block">
                                        <div class="form-material">
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;"  OnSelectedIndexChanged="dropDown_Ministry_SelectedIndexChanged" AutoPostBack="true" ID="DropDown_Ministry" required="" runat="server"></asp:DropDownList>
                                                <label class="float-label">Ministry</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Driver" required="" runat="server"></asp:DropDownList>
                                                <label class="float-label">Driver</label>
                                            </div>
                                            
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtLicenseCode">
                                                <span class="form-bar"></span>
                                                <label class="float-label">License Code</label>
                                            </div>
                                             <div class="form-group form-default">
                                                <input type="date" name="footer-email" class="form-control text-right" required="" runat="server" id="dateExp">
                                                <span class="form-bar"></span>
                                                <label class="float-label ">Expire Date</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtInterCode">
                                                <span class="form-bar"></span>
                                                <label class="float-label">International License Code</label>
                                            </div>
                                             <div class="form-group form-default">
                                                <input type="date" name="footer-email" class="form-control text-right" required="" runat="server" id="dateExpInter">
                                                <span class="form-bar"></span>
                                                <label class="float-label ">International License Code Expire Date</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtCodeMission">
                                                <span class="form-bar"></span>
                                                <label class="float-label">License Code Mission</label>
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
                                                <input type="date" name="footer-email" class="form-control text-right" required="" runat="server" id="dateCodeMissionExp">
                                                <span class="form-bar"></span>
                                                <label class="float-label ">License Code Mission Expire Date</label>
                                            </div>
             
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="dropDown_Bike" required="" runat="server">
                                                    <asp:ListItem>True</asp:ListItem>
                                                    <asp:ListItem>False</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Bike</label>
                                            </div>

                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_ligthVeh" required="" runat="server">
                                                    <asp:ListItem>True</asp:ListItem>
                                                    <asp:ListItem>False</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Light Vehicle</label>
                                            </div>

                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_HeavyWeight" required="" runat="server">
                                                    <asp:ListItem>True</asp:ListItem>
                                                    <asp:ListItem>False</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Heavy Weight</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Trailer" required="" runat="server">
                                                    <asp:ListItem>True</asp:ListItem>
                                                    <asp:ListItem>False</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Trailer Weight</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_4x4" required="" runat="server">
                                                    <asp:ListItem>True</asp:ListItem>
                                                    <asp:ListItem>False</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">4x4</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_licenseState" required="" runat="server">
                                                    <asp:ListItem>Valid</asp:ListItem>
                                                    <asp:ListItem>invalid</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">State</label>
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
                                <a class="btn btn-info ml-5" href="ViewLicense.aspx">List</a>
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

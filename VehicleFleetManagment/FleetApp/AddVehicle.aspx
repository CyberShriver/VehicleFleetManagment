<%@ Page Title="" Language="C#" MasterPageFile="~/FleetApp/fleet.Master" AutoEventWireup="true" CodeBehind="AddVehicle.aspx.cs" Inherits="VehicleFleetManagment.FleetApp.AddVehicle" %>

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
                        <li class="breadcrumb-item"><a href="AddVehicle.aspx">Add-Vehicle</a>
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
                            <h5>Vehicle</h5>
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
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Ministry" required="" runat="server"></asp:DropDownList>
                                                <label class="float-label">Ministry</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtCode" visible="false">

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
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Model" required="" runat="server"></asp:DropDownList>
                                                <label class="float-label">Model</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Body" required="" runat="server"></asp:DropDownList>
                                                <label class="float-label">Body</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_fuel" required="" runat="server">
                                                    <asp:ListItem>Petrol</asp:ListItem>
                                                    <asp:ListItem>Gaz</asp:ListItem>
                                                    <asp:ListItem>Essence</asp:ListItem>
                                                    <asp:ListItem>Mazutu</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Fuel Type</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtColor">
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
                                                <asp:FileUpload ID="file_upd" name="footer-email" data-parsley-trigger="change" required=""  autocomplete="off" class="form-control text-right" runat="server" />
                                                <span class="form-bar"></span>
                                                <label class="float-label ">Pic:.ico,.png,.jpg</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtEnginType">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Engine Type </label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtEnginSeries">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Engine Series N° </label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtEngAltern">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Alternator Engine Manufacturer </label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtEngAlternType">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Alternator Engine Type </label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="number" name="footer-email" class="form-control" required="" runat="server" id="txtKva">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Kva </label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtVolt">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Volt </label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtGenerWeight">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Generator Weight</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtAssembly">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Assembly N° </label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtEnginPower">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Engine Power </label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtEnginCylind">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Engine cylinder Number </label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtEngincc">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Engine cc</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control text-right" required="" runat="server" id="txtGearBox">
                                                <span class="form-bar"></span>
                                                <label class="float-label ">Gearbox Type</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <textarea class="form-control" required="" runat="server" id="txtCondition"></textarea>
                                                <span class="form-bar"></span>
                                                <label class="float-label">Condition</label>
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
                                                <input type="text" name="footer-email" class="form-control text-right" required="" runat="server" id="txtTankTyp1">
                                                <span class="form-bar"></span>
                                                <label class="float-label ">Tank Type 1</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control text-right" required="" runat="server" id="txtTankSze1">
                                                <span class="form-bar"></span>
                                                <label class="float-label ">Tank Size 1</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtTankTyp2">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Tank Type 2 </label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtTankCapacity2">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Tank Capacity 2</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="number" name="footer-email" class="form-control" required="" runat="server" id="txtFrontSeat">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Front Seats Number</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="number" name="footer-email" class="form-control" required="" runat="server" id="txtBatteryVolt">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Battery Voltage</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="number" name="footer-email" class="form-control" required="" runat="server" id="txtVehiclWeight">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Vehicle Weight</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtKeyCode">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Key code</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="number" name="footer-email" class="form-control" required="" runat="server" id="txtGrossVehWeigth">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Gross Vehicle Weigth</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="number" name="footer-email" class="form-control" required="" runat="server" id="txtEmptyPod">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Empty Pod</label>
                                            </div>

                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Trailer" required="" runat="server">
                                                    <asp:ListItem>true</asp:ListItem>
                                                    <asp:ListItem>false</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Trailer? </label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_lhd_rhd" required="" runat="server">
                                                    <asp:ListItem>left</asp:ListItem>
                                                    <asp:ListItem>right</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">left hand or right hand? </label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Belt" required="" runat="server">
                                                    <asp:ListItem>true</asp:ListItem>
                                                    <asp:ListItem>false</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Have Safety Belt?</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Central_Locking" required="" runat="server">
                                                    <asp:ListItem>true</asp:ListItem>
                                                    <asp:ListItem>false</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Central Locking? </label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="dropDown_Rear_Lock" required="" runat="server">
                                                    <asp:ListItem>true</asp:ListItem>
                                                    <asp:ListItem>false</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Rear Lock?</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Forward_Lock" required="" runat="server">
                                                    <asp:ListItem>true</asp:ListItem>
                                                    <asp:ListItem>false</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Forward Lock?</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Opt_Four_Wheel" required="" runat="server">
                                                    <asp:ListItem>true</asp:ListItem>
                                                    <asp:ListItem>false</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Opt Four Wheel?</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Air_Conditioner" required="" runat="server">
                                                    <asp:ListItem>true</asp:ListItem>
                                                    <asp:ListItem>false</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Air Conditioner?</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Additional_Heating" required="" runat="server">
                                                    <asp:ListItem>true</asp:ListItem>
                                                    <asp:ListItem>false</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Additional Heating?</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Rear_Blake" required="" runat="server">
                                                    <asp:ListItem>true</asp:ListItem>
                                                    <asp:ListItem>false</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Rear Blake?</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Electronic_Logbook" required="" runat="server">
                                                    <asp:ListItem>true</asp:ListItem>
                                                    <asp:ListItem>false</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Electronic Logbook?</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtRadioCode">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Radio Code</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtGuaranteeCerticat">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Guaranteed Certificate N°</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="date" name="footer-email" class="form-control text-right" required="" runat="server" id="dateGuaranteExp">
                                                <span class="form-bar"></span>
                                                <label class="float-label ">Guaranteed Expiration Date</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="date" name="footer-email" class="form-control text-right" required="" runat="server" id="dateCirculationExp">
                                                <span class="form-bar"></span>
                                                <label class="float-label ">Circulation Expiration Date</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <textarea class="form-control" required="" runat="server" id="txtStat"></textarea>
                                                <span class="form-bar"></span>
                                                <label class="float-label">Status </label>
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
                                <a class="btn btn-info ml-5" href="ViewVehicle.aspx">List</a>
                            </div>
                        </div>
                    </div>
                    <!--End Main Card -->

                </div>
                <!-- Page body end -->
            </div>
        </div>
        <!-- Main-body end -->
        <%--<div id="styleSelector"></div>--%>
    </div>
</asp:Content>

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

                    <div class="col-sm-6 mx-auto">
                        <div class="alert alert-success alert-dismissible fade show" runat="server" id="SuccessMsg">
                            <button type="button" class="close" data-dismiss="alert">&times;</button>
                            <strong>Success!</strong>
                        </div>
                        <div class="alert alert-info alert-dismissible fade show" runat="server" id="FillMsg">
                            <button type="button" class="close" data-dismiss="alert">&times;</button>
                            <strong>Please complete all fields!</strong>
                        </div>
                        <div class="alert alert-info alert-dismissible fade show" runat="server" id="ExistMsg">
                            <button type="button" class="close" data-dismiss="alert">&times;</button>
                            <strong>Already saved!</strong>
                        </div>
                        <div class="alert alert-danger alert-dismissible fade show" runat="server" id="FailMsg">
                            <button type="button" class="close" data-dismiss="alert">&times;</button>
                            <strong>Operation Failed!</strong>
                        </div>
                        <div class="alert alert-danger alert-dismissible fade show" runat="server" id="MsgGVN">
                            <button type="button" class="close" data-dismiss="alert">&times;</button>
                            <strong>Check GVM value !!! <span class="form-txt-info">Values must be between 401 and 4499.999</span></strong>
                        </div>
                    </div>
                        <div class="row">
                        <div class="col-sm-12">
                            <!-- Tab variant tab card start -->
                            <div class="card">
                                <div class="card-header">
                                    <h5>Vehicle</h5>
                                </div>
                                <div class="card-block tab-icon">

                                    <!-- Nav tabs -->
                                    <ul class="nav nav-tabs md-tabs " role="tablist">
                                        <li class="nav-item">
                                            <a class="nav-link active" id="tabGen" role="tab" runat="server" onserverclick="ActiveGen_click"><i class="icofont icofont-home"></i>General Information</a>
                                            <div class="slide"></div>
                                        </li>
                                        <li class="nav-item">
                                            <a class="nav-link" id="tabEngin" role="tab" runat="server" onserverclick="ActiveEngine_click"><i class="icofont icofont-ui-settings"></i>Engine Information</a>
                                            <div class="slide"></div>
                                        </li>
                                        <li class="nav-item">
                                            <a class="nav-link" id="tabSpec" role="tab" runat="server" onserverclick="ActiveSpecific_click"><i class="icofont icofont-ui-settings"></i>Specific Information</a>
                                            <div class="slide"></div>
                                        </li>
                                    </ul>
                                    <!-- Tab panes -->
                                    <div class="tab-content card-block">
                                        <asp:MultiView ID="MultiView" runat="server">
                                            <!--General  info Tab  -->
                                            <asp:View ID="ViewGen" runat="server">
                                                <div class="row card-block" id="General">
                                                    <div class="col-md-6">
                                                        <div class="form-material">
                                                            <div class="form-group form-default" id="DMinistry" runat="server">
                                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Ministry" required="" runat="server"></asp:DropDownList>
                                                                <label class="float-label">Ministry</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtCode" visible="false">
                                                            </div>

                                                            <div class="form-group form-default">
                                                                <asp:TextBox ID="txtPlate"  class="form-control" required="" runat="server" OnTextChanged="OnTextChanged_txtPlate" AutoPostBack="true"></asp:TextBox>
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
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="form-material">

                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control" runat="server" id="txtChassis" required>
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Chassis N°</label>
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
                                                                <textarea class="form-control"  runat="server" id="txtCondition"></textarea>
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Condition</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="card-footer">
                                                    <div class="float-right">
                                                        <a class="btn btn-sm btn-info ml-5" href="ViewVehicle.aspx">List <i class="icofont icofont-listine-dots"></i></a>
                                                        <button type="reset" class="btn btn-sm btn-danger ml-5 mr-5">Cancel</button>
                                                        <button type="submit" id="btnGenNext" class="btn btn-sm btn-default ml-5 waves-effect ml-5" runat="server" onserverclick="ActiveEngine_click">Next <i class="icofont icofont-hand-drawn-right"></i></button>
                                                    </div>
                                                </div>
                                            </asp:View>
                                            <!-- end General  info Tab  -->

                                            <!--  Engine info Tab  -->
                                            <asp:View ID="ViewEngine" runat="server">
                                                <div class="row card-block">

                                                    <div class="col-md-6">
                                                        <div class="form-material">
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtEngineNumber">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Engine N°</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtEngineManif">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Engine Manufacturer</label>
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
                                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtKva" onkeypress="inpNum(event)" maxlength="10">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Kva </label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-6">
                                                        <div class="form-material">
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtVolt" onkeypress="inpNum(event)" maxlength="5">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Volt</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtGenerWeight" onkeypress="inpNum(event)" maxlength="7">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Generator Weight ( in Kgs )</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtAssembly">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Assembly N° </label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtEnginPower" onkeypress="inpNum(event)" maxlength="7">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Engine Power ( in Volt ) </label>
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
                                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtGearBox">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label ">Gearbox Type</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="float-right">
                                                    <a class="btn btn-sm btn-info ml-5 " href="ViewVehicle.aspx">List <i class="icofont icofont-listine-dots"></i></a>
                                                    <button type="reset" class="btn btn-sm btn-danger ml-5 mr-5">Cancel</button>
                                                    <button type="submit" id="BtnEngineNext" class="btn btn-sm btn-default  waves-effect  ml-5" runat="server" onserverclick="ActiveSpecific_click">Next <i class="icofont icofont-hand-drawn-right"></i></button>
                                                </div>
                                                <button type="button" id="BtnEnginePreview" class="btn btn-sm btn-default  waves-effect " runat="server" onserverclick="ActiveGen_click"><i class="icofont icofont-hand-drawn-left"></i>Preview</button>

                                                <!-- End Engine info Tab  -->
                                            </asp:View>
                                            <!-- End Engine info Tab  -->

                                            <!--  Specific info Tab  -->
                                            <asp:View ID="ViewSpecific" runat="server">
                                                <div class="row card-block">
                                                    <div class="col-md-6">
                                                        <div class="form-material">
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control " required="" runat="server" id="txtTankTyp1">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label ">Tank Type 1</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control " required="" runat="server" id="txtTankSze1" onkeypress="inpNum(event)" maxlength="7">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label ">Tank Size 1 ( in Meter )</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control"  runat="server" id="txtTankTyp2">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Tank Type 2 </label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control"  runat="server" id="txtTankCapacity2" onkeypress="inpNumInt(event)" maxlength="5">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Tank Capacity 2 ( in Liter )</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtFrontSeat" onkeypress="inpNumInt(event)" maxlength="3">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Front Seats Number</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtBatteryVolt" onkeypress="inpNum(event)" maxlength="10">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Battery Voltage ( in Volt )</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtVehiclWeight" onkeypress="inpNum(event)" maxlength="5">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Vehicle Weight (in kgs )</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control"  runat="server" id="txtKeyCode">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Key code</label>
                                                            </div>
                                                             <div class="form-group form-default">
<%--                                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtGrossVehWeigth" onkeypress="inpNum(event)" maxlength="5" OnTextChanged="OnTextChanged_txtGrossVehWeigth" AutoPostBack="true">--%>
                                                                <asp:TextBox name="footer-email" class="form-control" required="" runat="server" id="txtGrossVehWeigth" onkeypress="inpNum(event)" maxlength="4" OnTextChanged="OnTextChanged_txtGrossVehWeigth" AutoPostBack="true"></asp:TextBox>
                                                                <span class="form-bar"></span>
                                                                <label class="float-label"> Gross Vehicle Mass [between 400.99 and 4499.99] ( in Kgs )</label>
                                                            </div>

                                                            <div class="form-group form-default">
                                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Trailer" required="" runat="server">
                                                                    <asp:ListItem>Compact Car</asp:ListItem>
                                                                    <asp:ListItem >small lorry truck</asp:ListItem>
                                                                    <asp:ListItem>Van</asp:ListItem>
                                                                    <asp:ListItem>Bus</asp:ListItem>
                                                                    <asp:ListItem>Trailer</asp:ListItem>
                                                                    <asp:ListItem>Tractor</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <label class="float-label">Vehicle type</label>
                                                            </div>
                                                           
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control"  runat="server" id="txtEmptyPod" onkeypress="inpNum(event)" maxlength="10">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Empty Pod</label>
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
                                                        </div>
                                                    </div>

                                                    <div class="col-md-6">

                                                        <div class="form-material">

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
                                                                <label class="float-label">Opt Four Wheel over?</label>
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
                                                                <input type="text" name="footer-email" class="form-control"  runat="server" id="txtRadioCode">
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
                                                                <asp:FileUpload ID="file_upd" name="footer-email" data-parsley-trigger="change" autocomplete="off" class="form-control text-right" runat="server" />
                                                                <span class="form-bar"></span>
                                                                <label class="float-label ">Pic:.ico,.png,.jpg</label>
                                                            </div>
                                                            <div class="form-group form-default" id="IdState" runat="server">
                                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_State" required="" runat="server">
                                                                    <asp:ListItem>Available</asp:ListItem>
                                                                    <asp:ListItem>Unavailable</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <label class="float-label">State</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <button type="button" id="BtnSpecificPreview" class="btn btn-sm btn-default  waves-effect" runat="server" onserverclick="ActiveEngine_click"><i class="icofont icofont-hand-drawn-left"></i>Preview</button>
                                                <div class="float-right">
                                                    <button type="submit" id="btnSave" class="btn btn-sm btn-primary ml-5 waves-effect" runat="server" onserverclick="btn_save_Click">Save <i class="icofont icofont-save"></i></button>
                                                    <button type="reset" class="btn btn-sm btn-danger ml-5">Cancel</button>
                                                    <a class="btn btn-sm btn-info ml-5" href="ViewVehicle.aspx">List <i class="icofont icofont-listine-dots"></i></a>

                                                </div>
                                                <!-- End Specific info Tab  -->
                                            </asp:View>

                                        </asp:MultiView>
                                    </div>
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
    <%--<div id="styleSelector"></div>--%>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/FleetApp/fleet.Master" AutoEventWireup="true" CodeBehind="AddCarCrash.aspx.cs" Inherits="VehicleFleetManagment.FleetApp.AddCarCrash" %>

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
                        <li class="breadcrumb-item"><a href="AddCarCrash.aspx">Add-Car-Crash</a>
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
                            <h5>Car Crash</h5>
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
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Ministry" OnSelectedIndexChanged="dropDown_Ministry_SelectedIndexChanged" AutoPostBack="true" required="" runat="server"> </asp:DropDownList>
                                                <label class="float-label">Ministry</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Plate" required="" runat="server"></asp:DropDownList>
                                                <label class="float-label">Plate</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Driver" required="" runat="server"></asp:DropDownList>
                                                <label class="float-label">Driver</label>
                                            </div>
                                            
                                            <div class="form-group form-default">
                                                <input type="date" class="form-control text-right" required="" runat="server" id="dateCrash">
                                                <span class="form-bar"></span>
                                                <label class="float-label  ">Crash Date</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="time" name="footer-email" class="form-control text-right" required="" runat="server" id="TimeCrash">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Crash Time</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtCrashPlace">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Crash Place</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtAddress">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Full Crash Address</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtMeileage" onkeypress="inpNum(event)" maxlength="10"/>                                           
                                                <span class="form-bar"></span>
                                                <label class="float-label">Crash Mileage</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtResponible">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Responsible</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" class="form-control" required="" runat="server" id="txtDriverAge">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Driver Age</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtWeather">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Weather</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtSpeed" onkeypress="inpNum(event)" maxlength="4"                                               >
                                                <span class="form-bar"></span>
                                                <label class="float-label">Estimated Speed</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtPassenger" onkeypress="inpNumInt(event)" maxlength="4" >
                                                <span class="form-bar"></span>
                                                <label class="float-label">Total Number of passengers</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <textarea class="form-control" required="" runat="server" id="txtCrashInfo"></textarea>
                                                <span class="form-bar"></span>
                                                <label class="float-label">Crash information</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <textarea class="form-control" required="" runat="server" id="txtReason"></textarea>
                                                <span class="form-bar"></span>
                                                <label class="float-label">Crash Reason</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <textarea class="form-control" required="" runat="server" id="txtCondition"></textarea>
                                                <span class="form-bar"></span>
                                                <label class="float-label">Condition After Crash</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <textarea class="form-control" required="" runat="server" id="txtDamage"></textarea>
                                                <span class="form-bar"></span>
                                                <label class="float-label">Crash Demage</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:FileUpload ID="file_upd" name="footer-email" data-parsley-trigger="change" required=""  autocomplete="off" class="form-control text-right" runat="server" />
                                                <span class="form-bar"></span>
                                                <label class="float-label ">Pic:.ico,.png,.jpg</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="date" class="form-control text-right" required="" runat="server" id="dateCompensation">
                                                <span class="form-bar"></span>
                                                <label class="float-label  ">Compensation Rule Date</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <textarea class="form-control" required="" runat="server" id="txtCircumstance"></textarea>
                                                <span class="form-bar"></span>
                                                <label class="float-label">Circumstance</label>
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
                                                <input type="date" name="footer-email" class="form-control text-right" required="" runat="server" id="dateReport">
                                                <span class="form-bar"></span>
                                                <label class="float-label ">Report Date</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="date" name="footer-email" class="form-control text-right" required="" runat="server" id="dateFinalReport">
                                                <span class="form-bar"></span>
                                                <label class="float-label ">Final Report date</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="date" name="footer-email" class="form-control text-right" required="" runat="server" id="dateDeclaration">
                                                <span class="form-bar"></span>
                                                <label class="float-label "> Insurance Declaration Date</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtAmount" onkeypress="inpNum(event)" maxlength="4"                                               >
                                                <span class="form-bar"></span>
                                                <label class="float-label">Claim Compensation Amount</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <textarea class="form-control" required="" runat="server" id="txtDamageDesipt"></textarea>
                                                <span class="form-bar"></span>
                                                <label class="float-label">Damage Description</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <textarea class="form-control" required="" runat="server" id="txtComment"></textarea>
                                                <span class="form-bar"></span>
                                                <label class="float-label">Passenger Comment</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtLegalCost" onkeypress="inpNum(event)" maxlength="4"                >
                                                <span class="form-bar"></span>
                                                <label class="float-label">Legal Cost</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtLocalComp" onkeypress="inpNum(event)" maxlength="4"                                                >
                                                <span class="form-bar"></span>
                                                <label class="float-label">Local Insurance Compensation Amount</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtRecoverEmpl" onkeypress="inpNum(event)" maxlength="4"                                                 >
                                                <span class="form-bar"></span>
                                                <label class="float-label">Employee Amount Recovered</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtThirdPartyRecov" onkeypress="inpNum(event)" maxlength="4"                                                >
                                                <span class="form-bar"></span>
                                                <label class="float-label">Third Party Amount Recovered</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_vehicle_Damag" required="" runat="server">
                                                    <asp:ListItem>true</asp:ListItem>
                                                    <asp:ListItem>false</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Is Vehicle Damaged? </label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Damage_thirdParty" required="" runat="server">
                                                    <asp:ListItem>true</asp:ListItem>
                                                    <asp:ListItem>false</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Are Third Parties Damaged? </label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_thirdParty_injure" required="" runat="server">
                                                    <asp:ListItem>true</asp:ListItem>
                                                    <asp:ListItem>false</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Are Third Parties Injured?</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Employee_injure" required="" runat="server">
                                                    <asp:ListItem>true</asp:ListItem>
                                                    <asp:ListItem>false</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Employees are Injured? </label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="dropDown_Employe_Payed" required="" runat="server">
                                                    <asp:ListItem>true</asp:ListItem>
                                                    <asp:ListItem>false</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Employees are payed?</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_state" required="" runat="server">
                                                    <asp:ListItem>High</asp:ListItem>
                                                    <asp:ListItem>Medium</asp:ListItem>
                                                    <asp:ListItem>Low</asp:ListItem>
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
                                <a class="btn btn-info ml-5" href="ViewCarCrash.aspx">List</a>
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

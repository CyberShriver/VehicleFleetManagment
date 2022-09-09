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
                        <asp:Label class="m-b-10 h5" ID="txtSystemTitle" runat="server" Text="" ></asp:Label>
                        <p><asp:Label class="m-b-0 p" ID="txtSlogan" runat="server" Text="" ></asp:Label></p>
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
                        <div class="col-sm-12">
                            <!-- Tab variant tab card start -->
                            <div class="card">
                                <div class="card-header">
                                    <h5>Car Crash</h5>
                                </div>
                                <div class="card-block tab-icon">

                                    <!-- Nav tabs -->
                                    <ul class="nav nav-tabs md-tabs " role="tablist">
                                        <li class="nav-item">
                                            <a class="nav-link active" role="tab" runat="server" id="tabGen" onserverclick="ActiveGen_click"><i class="icofont icofont-home"></i>General Information</a>
                                            <div class="slide"></div>
                                        </li>
                                        <li class="nav-item">
                                            <a class="nav-link" role="tab" runat="server" id="tabReport" onserverclick="ActiveReport_click"><i class="icofont icofont-ui-settings"></i>Report Information</a>
                                            <div class="slide"></div>
                                        </li>
                                        <li class="nav-item">
                                            <a class="nav-link" id="tabSpec" role="tab" runat="server" onserverclick="ActiveSpecific_click"><i class="icofont icofont-ui-settings"></i>Specific Information</a>
                                            <div class="slide"></div>
                                        </li>
                                    </ul>
                                    <!-- Tab panes -->
                                    <div class="tab-content card-block">
                                        <!-- MULTIVIEW  -->
                                        <asp:MultiView ID="MultiView" runat="server">
                                            <!--General  info Tab  -->
                                            <asp:View ID="ViewGeneral" runat="server">
                                                <div class="row card-block">
                                                    <div class="col-md-6">
                                                        <div class="form-material">
                                                            <div class="form-group form-default" id="DMinistry" runat="server">
                                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Ministry" OnSelectedIndexChanged="dropDown_Ministry_SelectedIndexChanged" AutoPostBack="true" required="" runat="server"></asp:DropDownList>
                                                                <label class="float-label">Ministry</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Plate" OnSelectedIndexChanged="DropDown_Plate_SelectedIndexChanged" AutoPostBack="true"  required="" runat="server"></asp:DropDownList>
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
                                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtMeileage" onkeypress="inpNum(event)" maxlength="10" />
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Crash Mileage</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtResponible">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Responsible</label>
                                                            </div>                                                            
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtWeather">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Weather</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtSpeed" onkeypress="inpNum(event)" maxlength="4">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Estimated Speed</label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-6">
                                                        <div class="form-material">
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtPassenger" onkeypress="inpNumInt(event)" maxlength="4">
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
                                                            
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="card-footer">
                                                    <div class="float-right">
                                                        <a class="btn btn-sm btn-info ml-5" href="ViewCarCrash.aspx">List <i class="icofont icofont-listine-dots"></i></a>
                                                        <button type="reset" class="btn btn-sm btn-danger ml-5 mr-5">Cancel</button>
                                                    <button type="submit" id="btnGenNext" class="btn btn-sm btn-default ml-5 waves-effect  " runat="server" onserverclick="ActiveReport_click">Next <i class="icofont icofont-hand-drawn-right"></i></button>
                                                    </div>
                                                </div>
                                            </asp:View>
                                            <!-- end General  info Tab  -->

                                            <!--  Report info Tab  -->
                                            <asp:View ID="ViewReport" runat="server">
                                                <div class="row card-block">
                                                    <div class="col-md-6">
                                                        <div class="form-material">
                                                            <div class="form-group form-default">
                                                                <input type="date" class="form-control text-right" required="" runat="server" id="dateCompensation">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label  ">Compensation Rule Date</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <textarea class="form-control"  runat="server" id="txtCircumstance"></textarea>
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Circumstance</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="date" name="footer-email" class="form-control text-right" required="" runat="server" id="dateReport">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label ">Report Date</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control"  runat="server" id="txtCode" visible="false">
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="date" name="footer-email" class="form-control text-right" required="" runat="server" id="dateFinalReport">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label ">Final Report date</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="date" name="footer-email" class="form-control text-right" required="" runat="server" id="dateDeclaration">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label ">Insurance Declaration Date</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtAmount" onkeypress="inpNum(event)" maxlength="12">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Claim Compensation Amount</label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-6">
                                                        <div class="form-material">
                                                            <div class="form-group form-default">
                                                                <textarea class="form-control"  runat="server" id="txtDamageDesipt"></textarea>
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Damage Description</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <textarea class="form-control"  runat="server" id="txtComment"></textarea>
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Passenger Comment</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control"  runat="server" id="txtLegalCost" onkeypress="inpNum(event)" maxlength="12">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Legal Cost</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtLocalComp" onkeypress="inpNum(event)" maxlength="12">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Local Insurance Compensation Amount</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control"  runat="server" id="txtRecoverEmpl" onkeypress="inpNum(event)" maxlength="12">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Employee Amount Recovered</label>
                                                            </div>
                                                            <div class="form-group form-default">
                                                                <input type="text" name="footer-email" class="form-control"  runat="server" id="txtThirdPartyRecov" onkeypress="inpNum(event)" maxlength="12">
                                                                <span class="form-bar"></span>
                                                                <label class="float-label">Third Party Amount Recovered</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="float-right">
                                                    <a class="btn btn-sm btn-info ml-5 " href="ViewCarCrash.aspx">List <i class="icofont icofont-listine-dots"></i></a>
                                                    <button type="reset" class="btn btn-sm btn-danger ml-5 mr-5">Cancel</button>
                                                    <button type="submit" id="BtnReportNext" class="btn btn-sm btn-default  waves-effect  ml-5" runat="server" onserverclick="ActiveSpecific_click">Next <i class="icofont icofont-hand-drawn-right"></i></button>
                                                </div>
                                                <button type="button" id="BtnReportPreview" class="btn btn-sm btn-default  waves-effect " runat="server" onserverclick="ActiveGen_click"><i class="icofont icofont-hand-drawn-left"></i>Preview</button>
                                            </asp:View>
                                            <!-- End Report info Tab  -->

                                            <!--  Specific info Tab  -->
                                            <asp:View ID="ViewSpecific" runat="server">
                                                <div class="row card-block">
                                                    <div class="col-md-6">
                                                        <div class="form-material">
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
                                                        </div>
                                                    </div>

                                                    <div class="col-md-6">

                                                        <div class="form-material">


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
                                                            <div class="form-group form-default">
                                                                <asp:FileUpload ID="file_upd" name="footer-email" data-parsley-trigger="change"  autocomplete="off" class="form-control text-right" runat="server" />
                                                                <span class="form-bar"></span>
                                                                <label class="float-label ">Pic:.ico,.png,.jpg</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <button type="button" id="BtnSpecificPreview" class="btn btn-sm btn-default  waves-effect" runat="server" onserverclick="ActiveReport_click"><i class="icofont icofont-hand-drawn-left"></i>Preview</button>
                                                <div class="float-right">
                                                    <button type="submit" id="btnSave" class="btn btn-sm btn-primary ml-5 waves-effect" runat="server" onserverclick="btn_save_Click">Save <i class="icofont icofont-save"></i></button>
                                                    <button type="reset" class="btn btn-sm btn-danger ml-5">Cancel</button>
                                                    <a class="btn btn-sm btn-info ml-5" href="ViewCarCrash.aspx">List <i class="icofont icofont-listine-dots"></i></a>

                                                </div>
                                            </asp:View>
                                            <!-- End Specific info Tab  -->
                                        </asp:MultiView>
                                        <!-- END MULTIVIEW  -->
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
        <div id="styleSelector"></div>
    </div>


</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/FleetApp/fleet.Master" AutoEventWireup="true" CodeBehind="AddVehicleFuel.aspx.cs" Inherits="VehicleFleetManagment.FleetApp.AddVehicleFuel" %>

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
                        <li class="breadcrumb-item"><a href="AddVehicleFuel.aspx">Add-Vehicle-Fuel</a>
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
                            <h5>Vehicle Fuel</h5>
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
                            <div class="alert alert-danger alert-dismissible fade show" runat="server" id="FuelMsg">
                                <button type="button" class="close" data-dismiss="alert">&times;</button>
                                <strong>
                                    <b>Initial Quantity</b> Must be inferior on <b>Fuel Used</b>                                  
                                </strong>
                            </div>
                            <div class="alert alert-danger alert-dismissible fade show" runat="server" id="exceedFuelLimit">
                                <button type="button" class="close" data-dismiss="alert">&times;</button>
                                <strong>
                                    <b>You are not allowed to fill such quantity of Fuel. upload granted permission</b>                                  
                                </strong>
                            </div>
                            <div class="alert alert-danger alert-dismissible fade show" runat="server" id="MaxLiterMsg">
                                <button type="button" class="close" data-dismiss="alert">&times;</button>
                                <strong>
                                    <b>This vehicle cannot carry out that liter. Max liters are
                                        <asp:Label runat="server" ID="MaxLiter" Text="" class="text-c-green" ></asp:Label> liters</b>                                  
                                </strong>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="card-block">
                                    <div class="form-material">
                                        <div class="form-group form-default" id="DMinistry" runat="server">
                                            <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Ministry" required="" runat="server"></asp:DropDownList>
                                            <label class="float-label">Ministry</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Vehicle" OnSelectedIndexChanged="DropDown_Vehicle_SelectedIndexChanged" AutoPostBack="true" required="" runat="server"></asp:DropDownList>
                                            <label class="float-label">Plate</label>
                                        </div>

                                        <div class="form-group form-default">
                                            <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Category" runat="server"></asp:DropDownList>
                                            <label class="float-label">Vehicle Category</label>
                                        </div>

                                        <div class="form-group form-default">
                                            <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_ProviderCode" required="" runat="server"></asp:DropDownList>
                                            <label class="float-label">Provider</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_TankType" required="" runat="server">
                                                <asp:ListItem>Internal</asp:ListItem>
                                                <asp:ListItem>External</asp:ListItem>
                                            </asp:DropDownList>
                                            <label class="float-label">Tank Type</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_fuel" required="" runat="server"></asp:DropDownList>
                                            <label class="float-label">Fuel Type</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <input type="text" name="footer-email" class="form-control"  runat="server" id="txtTankCode">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Tank Code</label>
                                        </div>
                                        

                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="card-block">
                                    <div class="form-material">
                                        <div class="form-group form-default">
                                            <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtOdometer" onkeypress="inpNumInt(event)" maxlength="7">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Odometer(Distance traveled)</label>
                                        </div>

                                        <div class="form-group form-default">
                                            <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtInitQ" onkeypress="inpNum(event)" maxlength="3">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Initial Quantity </label>
                                        </div>
                                        <div class="form-group form-default">
                                            <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtFuelUsed" onkeypress="inpNum(event)" maxlength="3">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Fuel used</label>
                                        </div>
                                        <div class="form-group form-default" runat="server" id="scannedPic">
                                            <asp:FileUpload ID="file_upd" name="footer-email" data-parsley-trigger="change"  required="" autocomplete="off" onchange="" class="form-control text-right" runat="server"  />
                                            <span class="form-bar"></span>
                                            <label class="float-label ">Scanned Pic:.png,.jpg</label>
                                        </div>
                                        <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="Upload" Style="display:none"/>
                                        <asp:Label ID="InvalidLenght" runat="server" Text="Something goes wrong on this file !!" Visible="false" Class="text-danger small "></asp:Label>
                                        
                                        <div class="form-group form-default" runat="server" id="displayPermission" visible="false">
                                            Saved By : <asp:Label ID="clientAddress" runat="server" Text=""></asp:Label><br />
                                            <a href="#" class="btn btn-danger" onClick="newWindow=window.open('<%=ImgView %>');newWindow.print();"> Open permission </a>
                                        </div>
                                       
                                        <div class="form-group form-default" runat="server" id="checkApprove">
                                                <asp:CheckBox ID="Approve" runat="server" OnCheckedChanged="OnCheckedChangedApprove" AutoPostBack="true" Checked="false"/>                                              
                                                <label>permission granted</label>
                                            </div>  

                                        <div class="form-group form-default" runat="server" visible="false">
                                            <input type="text" name="footer-email" class="form-control"  runat="server" id="txtConsumeQ" onkeypress="inpNum(event)" maxlength="7" >
                                            <span class="form-bar"></span>
                                            <label class="float-label">Consummed Quantity</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtUnit" onkeypress="inpNum(event)" maxlength="7">
                                            <span class="form-bar"></span>
                                            <label class="float-label">United Price (Fuel price)</label>
                                        </div>
                                        <%--<div class="form-group form-default">
                                            <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtTotal" onkeypress="inpNum(event)" maxlength="7">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Total Price</label>
                                        </div>--%>
                                        <div class="form-group form-default" runat="server"  visible="false">
                                            <input type="text" name="footer-email" class="form-control"  runat="server" id="txtLiter_100_km" onkeypress="inpNum(event)" maxlength="7" >
                                            <span class="form-bar"></span>
                                            <label class="float-label">Fuel Consumption L/100km (in Liter)</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <input type="date" class="form-control text-right" visible="false" runat="server" id="dateSave">
                                        </div>
                                        <div class="form-group form-default">
                                            <textarea class="form-control"  runat="server" id="txtComment"></textarea>
                                            <span class="form-bar"></span>
                                            <label class="float-label">Comment</label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card-footer">
                            <div class="float-right">
                                <button type="submit" id="btnSave" class="btn btn-primary ml-5 waves-effect" runat="server" onserverclick="btn_save_Click">Save</button>
                                <button type="reset" class="btn btn-danger ml-5">Cancel</button>
                                <a class="btn btn-info ml-5" href="ViewVehicleFuel.aspx">List</a>
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

    <script type="text/javascript">
        function UploadFile(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("<%=btnUpload.ClientID%>").click();
            }
        }
    </script>

</asp:Content>

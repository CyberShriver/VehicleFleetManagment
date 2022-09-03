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
                        <asp:Label class="m-b-10 h5" ID="txtSystemTitle" runat="server" Text="" ></asp:Label>
                        <p><asp:Label class="m-b-0 p" ID="txtSlogan" runat="server" Text="" ></asp:Label></p>
                    </div>
                </div>
                <div class="col-md-4">
                    <ul class="breadcrumb-title">
                        <li class="breadcrumb-item">
                            <a href="Home.aspx"><i class="fa fa-home"></i></a>
                        </li>
                        <li class="breadcrumb-item"><a href="AddLicense.aspx">Add-Licence</a>
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
                            <h5>Driving's Licence</h5>
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
                                                <label class="float-label">Driving Licence N°</label>
                                            </div>
                                             
                                            <div class="form-group form-default">
                                                <input type="date" name="footer-email" class="form-control text-right" required="" runat="server" id="dateIssueOn">
                                                <span class="form-bar"></span>
                                                <label class="float-label ">Issued On </label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtIssuedAt">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Issued At</label>
                                            </div>                                          
                                            <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_IssuedAuthority" required="" runat="server">
                                                    <asp:ListItem>PR & SR</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">Issued Authority</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <label> Category :</label>
                                                <asp:CheckBox ID="category_A" runat="server" Text=" A " OnCheckedChanged="OnCheckedChanged_A" AutoPostBack="true" />
                                                <asp:CheckBox ID="category_B" runat="server" Text=" B " OnCheckedChanged="OnCheckedChanged_B" AutoPostBack="true"/>
                                                <asp:CheckBox ID="category_C" runat="server" Text=" C "  OnCheckedChanged="OnCheckedChanged_C" AutoPostBack="true"/>
                                                <asp:CheckBox ID="category_D1" runat="server" Text=" D1 "  OnCheckedChanged="OnCheckedChanged_D1" AutoPostBack="true"/>
                                                <asp:CheckBox ID="category_D2" runat="server" Text=" D2 " OnCheckedChanged="OnCheckedChanged_D2" AutoPostBack="true"/>
                                                <asp:CheckBox ID="category_E" runat="server" Text=" E "  OnCheckedChanged="OnCheckedChanged_E" AutoPostBack="true"/>
                                                <asp:CheckBox ID="category_F" runat="server" Text=" F " OnCheckedChanged="OnCheckedChanged_F" AutoPostBack="true"/>
                                            </div>                                                                               

                                            <div class="form-group form-default">
                                                <input type="date" name="footer-email" class="form-control text-right" required="" runat="server" id="dateExp">
                                                <span class="form-bar"></span>
                                                <label class="float-label ">Expire Date</label>
                                            </div>

                                             <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtCrdNum">
                                                <span class="form-bar"></span>
                                                <label class="float-label">CARD N°</label>
                                            </div>

                                            <div class="form-group form-default">
                                                <asp:FileUpload ID="file_upd" name="footer-email" data-parsley-trigger="change" required="" autocomplete="off" class="form-control text-right" runat="server" />
                                                <span class="form-bar"></span>
                                                <label class="float-label ">Scanned Pic:.png,.jpg</label>
                                            </div>
                                               
                                            <asp:Image ID="Image1" runat="server" Width="70px" Height="50px" />

                                        </div>
                                    </div>
                            </div>

                            <div class="col-md-6">
                                    <div class="card-block">
                                        <div class="form-material">
                                          
                                             <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtInterCode">
                                                <span class="form-bar"></span>
                                                <label class="float-label">International Licence Code</label>
                                            </div>
                                             <div class="form-group form-default">
                                                <input type="date" name="footer-email" class="form-control text-right" required="" runat="server" id="dateExpInter">
                                                <span class="form-bar"></span>
                                                <label class="float-label ">International Licence Code Expire Date</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtCodeMission">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Licence Code Mission</label>
                                            </div>     

                                            <div class="form-group form-default">
                                                <input type="date" name="footer-email" class="form-control text-right" required="" runat="server" id="dateCodeMissionExp">
                                                <span class="form-bar"></span>
                                                <label class="float-label ">Licence Code Mission Expire Date</label>
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

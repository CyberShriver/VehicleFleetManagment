<%@ Page Title="" Language="C#" MasterPageFile="~/FleetApp/fleet.Master" AutoEventWireup="true" CodeBehind="AddSchedule.aspx.cs" Inherits="VehicleFleetManagment.FleetApp.AddSchedule" %>

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
                        <li class="breadcrumb-item"><a href="AddSchedule.aspx">Add-Schedule</a>
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
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h5>Schedule</h5>
                                </div>
                                <div class="card-block">

                                    <div class="form-material">

                                        <div class="form-group form-default" id="DMinistry" runat="server">
                                            <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" OnSelectedIndexChanged="dropDown_Ministry_SelectedIndexChanged" AutoPostBack="true" ID="DropDown_Ministry" required="" runat="server"></asp:DropDownList>
                                            <label class="float-label">Ministry</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Plate" required="" runat="server"></asp:DropDownList>
                                            <label class="float-label">Plate</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <input type="text" name="footer-email" class="form-control" required="" runat="server" id="txtMission">
                                            <span class="form-bar"></span>
                                            <label class="float-label">Mission</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <input type="date" class="form-control text-right" required="" runat="server" id="dateMission">
                                            <span class="form-bar"></span>
                                            <label class="float-label  "> Date Mission</label>
                                        </div>
                                        <div class="form-group form-default">
                                            <input type="time" name="footer-email" class="form-control text-right" required="" runat="server" id="TimeMission">
                                            <span class="form-bar"></span>
                                            <label class="float-label"> Time Of Mission</label>
                                        </div>   
                                        <div class="form-group form-default">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_State" required="" runat="server">
                                                    <asp:ListItem>Done</asp:ListItem>
                                                    <asp:ListItem>Not Yet</asp:ListItem>
                                                    <asp:ListItem>Aborted</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="float-label">State</label>
                                            </div>

                                        <div class="form-group form-default">
                                            <textarea class="form-control" runat="server" id="txtComment"></textarea>
                                            <span class="form-bar"></span>
                                            <label class="float-label">Comment</label>
                                        </div>
                                    </div>
                                </div>

                                <div class="card-footer">
                                    <div class="float-right">
                                        <button type="submit" id="btnSave" class="btn btn-primary ml-5 waves-effect" runat="server" onserverclick="btn_save_Click">Save</button>
                                        <button type="reset" class="btn btn-danger ml-5">Cancel</button>
                                        <a class="btn btn-info ml-5" href="ViewSchedule.aspx">List</a>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/FleetApp/fleet.Master" AutoEventWireup="true" CodeBehind="AddLeave.aspx.cs" Inherits="VehicleFleetManagment.FleetApp.AddLeave" %>

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
                        <li class="breadcrumb-item"><a href="AddLeave.aspx">Add-Leave</a>
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
                            <h5>Leave</h5>
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
                             <div class="alert alert-danger alert-dismissible fade show" runat="server" id="DateFailed">
                                <button type="button" class="close" data-dismiss="alert">&times;</button>
                                <strong>
                                    <b>Start Date</b> Must be inferior on <b>End Date</b><br />
                                    <b>Demand Date</b> Must be inferior or equals on <b>start Date</b>
                                    <b>Approved Date</b> Must be inferior on <b>start Date</b>
                                </strong>
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
                                            <div class="form-group form-default" runat="server" id="driver">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_Driver" required="" runat="server"></asp:DropDownList>
                                                <label class="float-label">Driver</label>
                                            </div>
                                            <div class="form-group form-default"  runat="server" id="Leavetype">
                                                <asp:DropDownList class="form-control " name="footer-email" Style="width: 100%;" ID="DropDown_LeaveType" required="" runat="server"></asp:DropDownList>
                                                <label class="float-label">Leave Type</label>
                                            </div>
                                            <div class="form-group form-default" runat="server" visible="false">
                                                <input type="text" name="footer-email" class="form-control"  runat="server" id="txtLeaveCode">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Leave Code</label>
                                            </div>
                                        
                                            <div class="form-group form-default" id="idDemand" runat="server">
                                                <input type="date" name="footer-email" class="form-control text-right" required="" runat="server" id="dateDemand">
                                                <span class="form-bar"></span>
                                                <label class="float-label ">Demand date</label>
                                            </div>
                                           

                                        </div>
                                    </div>
                            </div>

                            <div class="col-md-6">
                                    <div class="card-block">
                                        <div class="form-material" >
                                             <div class="form-group form-default" id="idStart" runat="server">
                                                <input type="date" class="form-control text-right" required="" runat="server" id="dateStart">
                                                <span class="form-bar"></span>
                                                <label class="float-label  ">Start Date</label>
                                            </div>
                                            <div class="form-group form-default"  runat="server" id="EndDate">
                                                <input type="date" name="footer-email" class="form-control text-right" required="" runat="server" id="dateEnd">
                                                <span class="form-bar"></span>
                                                <label class="float-label ">End Date</label>
                                            </div>
                                            <div class="form-group form-default" runat="server" visible="false" id="idState">
                                                <input type="text" name="footer-email" class="form-control"  runat="server" id="txtState">
                                                <span class="form-bar"></span>
                                                <label class="float-label">State</label>
                                            </div> 
                                            <div class="form-group form-default" runat="server" visible="false" id="idAproved">
                                                <input type="date" name="footer-email " class="form-control text-right"  runat="server" id="dateApproved">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Approved Date</label>
                                            </div> 
                                            <div class="form-group form-default" runat="server" visible="false" id="VisApprovedBy">
                                                <input type="text" name="footer-email" class="form-control"  runat="server" id="txtApproved">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Approved By</label>
                                            </div> 
                                            <div class="form-group form-default" runat="server" visible="false" id="idSaved">
                                                <input type="text" name="footer-email " class="form-control text-right"  runat="server" id="DateSaved">
                                                <span class="form-bar"></span>
                                                <label class="float-label">Saved</label>
                                            </div>
                                            <div class="form-group form-default">
                                                <textarea class="form-control" runat="server" id="txtComment"></textarea>
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
                                <button id="btnCancel" runat="server" type="reset" class="btn btn-danger ml-5">Cancel</button>
                                <a class="btn btn-info ml-5" href="ViewLeave.aspx">List</a>
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

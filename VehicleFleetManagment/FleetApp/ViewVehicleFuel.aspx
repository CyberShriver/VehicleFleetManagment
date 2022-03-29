<%@ Page Title="" Language="C#" MasterPageFile="~/FleetApp/fleet.Master" AutoEventWireup="true" CodeBehind="ViewVehicleFuel.aspx.cs" Inherits="VehicleFleetManagment.FleetApp.ViewVehicleFuel" %>

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
                        <p class="m-b-0">Safety Rules Are Your Best Tools.</p>
                    </div>
                </div>
                <div class="col-md-4">
                    <ul class="breadcrumb-title">
                        <li class="breadcrumb-item">
                            <a href="Home.aspx"><i class="fa fa-home"></i></a>
                        </li>
                        <li class="breadcrumb-item"><a href="AddVehicleFuel.aspx">Add-Vehicle-Fuel</a>
                        </li>
                        <li class="breadcrumb-item"><a href="ViewVehicleFuel.aspx">List-Vehicle-Fuel</a>
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
                    <!-- Hover table card start -->
                    <div class="card">
                        <div class="card-header">
                            <h5>All Vehicle Fuel Records</h5>
                            <div class="card-header-right">
                                <ul class="list-unstyled card-option">
                                    <li><i class="fa fa fa-wrench open-card-option"></i></li>
                                    <li><i class="fa fa-window-maximize full-card"></i></li>
                                    <li><i class="fa fa-minus minimize-card"></i></li>
                                    <li><i class="fa fa-refresh reload-card"></i></li>
                                    <li><i class="fa fa-trash close-card"></i></li>
                                </ul>
                            </div>
                        </div>
                        <div class="card-block table-border-style">
                            <div class="table-responsive">
                                <table class="table table-hover">
                                    <asp:GridView HorizontalAlign="Center" AllowSorting="true" AllowPaging="true" AutoGenerateColumns="false" CellPadding="4" GridLines="None" CellSpacing="4" runat="server" Width="447px">
                                        <Columns>
                                            <asp:TemplateField HeaderText="#" FooterText="#" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderWidth="1px">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='1000'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Departement" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" FooterText="Departement" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderWidth="1px">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='BIU'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Action" FooterText="Options" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderWidth="1px" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Button ID="btn_Modify" class="btn btn-primary mr-4" runat="server" Text="Modify" />
                                                    <asp:Button ID="Btn_Delete" class="btn btn-danger " runat="server" Text="Delete" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </table>
                            </div>
                        </div>
                    </div>
                    <!-- Hover table card end -->
                </div>
                <!-- Page body end -->
            </div>
        </div>
        <!-- Main-body end -->
        <div id="styleSelector">
        </div>
    </div>

</asp:Content>

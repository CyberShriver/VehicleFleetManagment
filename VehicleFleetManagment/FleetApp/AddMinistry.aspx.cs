using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;
using VehicleFleetManagment.FleetImp;
using System.IO;

namespace VehicleFleetManagment.FleetApp
{
    public partial class AddMinistry : System.Web.UI.Page
    {

        Ministry_Class  Min = new Ministry_Class ();
        Ministry_Interface I = new Ministry_Imp();
        int msg;
        string id;
        string code;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["MINISTRY_ID"];
            MultiView.ActiveViewIndex = 0;
            if (!IsPostBack)
            {
                MsgInit();
                if (id == null)
                {
                    btnSave.InnerText = "Save";
                }
                else

                {
                    btnSave.InnerText = "Edit";
                    ChargeData();
                }

            }

        }

        private void MsgInit()
        {
            SuccessMsg.Visible = false;
            FillMsg.Visible = false;
            FailMsg.Visible = false;
        }

        //Code Generate
        string MinistryCode()
        {
            return code = "Min-" + (Convert.ToInt32(I.count() + 1)) + "/" + DateTime.Now.Year;
        }

        //Add 
        void Add()
        {
            try
            {
                if (txtName.Value == "" || txtAddress.Value == "" || txtTel.Value == "" || txtUserName.Value == "" || txtPassword.Value == "" || txtSysTitle.Value == "" ||
                    txtFax.Value == "" || txtPostal.Value == "" || txtSysName.Value == "" || txtSysMaile.Value == "" || txtTheme.Value=="" || txtSlogan.Value=="")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {
                    if (file_upd.HasFile || file_updLogo.HasFile)
                    {
                        file_upd.SaveAs(Server.MapPath("~/FleetApp/assets/images/Users/") + Path.GetFileName(file_upd.FileName));
                        file_updLogo.SaveAs(Server.MapPath("~/FleetApp/assets/images/Logo/") + Path.GetFileName(file_updLogo.FileName));
                        string img = Path.GetFileName(file_upd.FileName);
                        string Imglogo = Path.GetFileName(file_updLogo.FileName);
                        FileInfo ext = new FileInfo(img);
                        FileInfo ext2 = new FileInfo(Imglogo);
                        if (ext.Extension == ".ico" || ext.Extension == ".png" || ext.Extension == ".jpg" || ext.Extension == ".jpeg" ||
                            ext2.Extension == ".ico" || ext2.Extension == ".png" || ext2.Extension == ".jpg" || ext2.Extension == ".jpeg" )
                        {
                            if (file_upd.PostedFile.ContentLength < 104857600 || file_updLogo.PostedFile.ContentLength < 104857600)
                            {
                                Min.Code_Min = MinistryCode();
                                Min.Ministry_Name = txtName.Value;
                                Min.Address = txtAddress.Value;
                                Min.Phone = txtTel.Value;
                                Min.Fax = txtFax.Value;
                                Min.System_Name = txtSysName.Value;
                                Min.System_Title = txtSysTitle.Value;
                                Min.Postal_code = txtPostal.Value;
                                Min.User_Nme = txtUserName.Value;
                                Min.System_Email = txtSysMaile.Value;
                                Min.Password = txtPassword.Value;
                                Min.Picture = img;
                                Min.Logo = Imglogo;
                                Min.Theme = txtTheme.Value;
                                Min.Slogan = txtSlogan.Value;

                                msg = I.Add(Min);
                                if (msg > 0)
                                {
                                    I.Add(Min);
                                    FillMsg.Visible = false;
                                    FailMsg.Visible = false;
                                    SuccessMsg.Visible = true;

                                    txtPostal.Value = "";
                                    txtTel.Value = "";
                                    txtSysTitle.Value = "";
                                    txtSysName.Value = "";
                                    txtPassword.Value = "";
                                    txtName.Value = "";
                                    txtTel.Value = "";
                                    txtAddress.Value = "";
                                    txtUserName.Value = "";
                                    txtSysName.Value = "";
                                    txtTheme.Value = "";
                                    txtSlogan.Value = "";

                                }
                                else
                                {
                                    SuccessMsg.Visible = false;
                                    FillMsg.Visible = false;
                                    FailMsg.Visible = true;

                                }
                            }
                            else
                            {
                                SuccessMsg.Visible = false;
                                FillMsg.Visible = false;
                                FailMsg.Visible = true;
                            }
                        }
                        else
                        {
                            SuccessMsg.Visible = false;
                            FillMsg.Visible = false;
                            FailMsg.Visible = true;
                        }
                    }
                    else
                    {
                        Min.Code_Min =MinistryCode();
                        Min.Ministry_Name = txtName.Value;
                        Min.Address = txtAddress.Value;
                        Min.Phone = txtTel.Value;
                        Min.Fax = txtFax.Value;
                        Min.System_Name = txtSysName.Value;
                        Min.System_Title = txtSysTitle.Value;
                        Min.Postal_code = txtPostal.Value;
                        Min.User_Nme = txtUserName.Value;
                        Min.System_Email = txtSysMaile.Value;
                        Min.Password = txtPassword.Value;
                        Min.Picture = "No Picture";
                        Min.Logo = "No logo";
                        Min.Theme = txtTheme.Value;
                        Min.Slogan = txtSlogan.Value;

                        msg = I.Add(Min);
                        if (msg > 0)
                        {
                            I.Add(Min);
                            FillMsg.Visible = false;
                            FailMsg.Visible = false;
                            SuccessMsg.Visible = true;

                            txtPostal.Value = "";
                            txtTel.Value = "";
                            txtSysTitle.Value = "";
                            txtSysName.Value = "";
                            txtPassword.Value = "";
                            txtName.Value = "";
                            txtTel.Value = "";
                            txtAddress.Value = "";
                            txtUserName.Value = "";
                            txtSysName.Value = "";
                            txtTheme.Value = "";
                            txtSlogan.Value = "";
                        }
                        else
                        {
                            SuccessMsg.Visible = false;
                            FillMsg.Visible = false;
                            FailMsg.Visible = true;

                        }
                    }
                }
            }
           
            catch (SqlException e)
            {
                SuccessMsg.Visible = false;
                FillMsg.Visible = false;
                FailMsg.Visible = true;
            }
        }

        //update
        void Update()
        {

            try
            {
                if (txtName.Value == "" || txtAddress.Value == "" || txtTel.Value == "" || txtUserName.Value == "" || txtPassword.Value == "" || txtSysTitle.Value == "" ||
                  txtFax.Value == "" || txtPostal.Value == "" || txtSysName.Value == "" || txtSysMaile.Value == "" || txtTheme.Value == "" || txtSlogan.Value == "")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {
                    if (file_upd.HasFile || file_updLogo.HasFile)
                    {
                        file_upd.SaveAs(Server.MapPath("~/FleetApp/assets/images/Users/") + Path.GetFileName(file_upd.FileName));
                        file_updLogo.SaveAs(Server.MapPath("~/FleetApp/assets/images/Logo/") + Path.GetFileName(file_updLogo.FileName));
                        string img = Path.GetFileName(file_upd.FileName);
                        string Imglogo = Path.GetFileName(file_updLogo.FileName);
                        FileInfo ext = new FileInfo(img);
                        FileInfo ext2 = new FileInfo(Imglogo);
                        if (ext.Extension == ".ico" || ext.Extension == ".png" || ext.Extension == ".jpg" || ext.Extension == ".JPG" || ext.Extension == ".jpeg" ||
                            ext2.Extension == ".ico" || ext2.Extension == ".png" || ext2.Extension == ".jpg" || ext2.Extension == ".JPG" || ext2.Extension == ".jpeg")
                        {
                            if (file_upd.PostedFile.ContentLength < 104857600 || file_updLogo.PostedFile.ContentLength < 104857600)
                            {
                                Min.Code_Min = txtCode.Value;
                                Min.Ministry_Name = txtName.Value;
                                Min.Address = txtAddress.Value;
                                Min.Phone = txtTel.Value;
                                Min.Fax = txtFax.Value;
                                Min.System_Name = txtSysName.Value;
                                Min.System_Title = txtSysTitle.Value;
                                Min.Postal_code = txtPostal.Value;
                                Min.User_Nme = txtUserName.Value;
                                Min.System_Email = txtSysMaile.Value;
                                Min.Password = txtPassword.Value;
                                Min.Picture = img;
                                Min.Logo = Imglogo;
                                Min.Theme = txtTheme.Value;
                                Min.Slogan = txtSlogan.Value;

                                msg = I.Update(Min, Convert.ToInt32(id));
                                if (msg > 0)
                                {
                                    Response.Redirect("~/FleetApp/ViewMinistry.aspx");
                                }
                                else
                                {
                                    SuccessMsg.Visible = false;
                                    FillMsg.Visible = false;
                                    FailMsg.Visible = true;

                                }
                            }
                            else
                            {
                                SuccessMsg.Visible = false;
                                FillMsg.Visible = false;
                                FailMsg.Visible = true;
                            }
                        }
                        else
                        {
                            SuccessMsg.Visible = false;
                            FillMsg.Visible = false;
                            FailMsg.Visible = true;
                        }
                    }
                    else
                    {
                        Min.Code_Min = txtCode.Value;
                        Min.Ministry_Name = txtName.Value;
                        Min.Address = txtAddress.Value;
                        Min.Phone = txtTel.Value;
                        Min.Fax = txtFax.Value;
                        Min.System_Name = txtSysName.Value;
                        Min.System_Title = txtSysTitle.Value;
                        Min.Postal_code = txtPostal.Value;
                        Min.User_Nme = txtUserName.Value;
                        Min.System_Email = txtSysMaile.Value;
                        Min.Password = txtPassword.Value;
                        Min.Picture = "No Picture";
                        Min.Logo = "No logo";
                        Min.Theme = txtTheme.Value;
                        Min.Slogan = txtSlogan.Value;

                        msg = I.Update(Min, Convert.ToInt32(id));
                        if (msg > 0)
                        {
                            Response.Redirect("~/FleetApp/ViewMinistry.aspx");
                        }
                        else
                        {
                            SuccessMsg.Visible = false;
                            FillMsg.Visible = false;
                            FailMsg.Visible = true;

                        }
                    }
                }
            }
            catch (SqlException e)
            {
                SuccessMsg.Visible = false;
                FillMsg.Visible = false;
                FailMsg.Visible = true;
            }
        }

        protected void ChargeData()
        {
            if (id != null)
            {
                I.provide(Min, Convert.ToInt32(id));

                txtCode.Value = Min.Code_Min;
                txtName.Value = Min.Ministry_Name;
                txtAddress.Value = Min.Address;
                txtTel.Value = Min.Phone;
                txtFax.Value = Min.Fax;
                txtSysName.Value = Min.System_Name;
                txtSysTitle.Value= Min.System_Title;
                txtPostal.Value = Min.Postal_code;
                txtUserName.Value = Min.User_Nme;
                txtPassword.Value = Min.Password;
                txtSysMaile.Value = Min.System_Email;
                txtSlogan.Value = Min.Slogan;
                txtTheme.Value = Min.Theme;
               
            }
        }

        protected void btn_save_Click(object sender, EventArgs args)
        {
            if (id == null)
            {
               
                Add();
            }
           else
                Update();
        }

        protected void ActiveGen_click(object sender, EventArgs args)
        {
            MultiView.ActiveViewIndex = 0;
            MsgInit();
            tabSettings.Attributes.Remove("class");
            tabSettings.Attributes.Add("class", "nav-link");

            tabGen.Attributes.Remove("class");
            tabGen.Attributes.Add("class", "nav-link active");
        }
        protected void ActiveSettings_click(object sender, EventArgs args)
        {
            MultiView.ActiveViewIndex = 1;
            MsgInit();
            tabGen.Attributes.Remove("class");
            tabGen.Attributes.Add("class", "nav-link");

            tabSettings.Attributes.Remove("class");
            tabSettings.Attributes.Add("class", "nav-link active");
        }
    }
}
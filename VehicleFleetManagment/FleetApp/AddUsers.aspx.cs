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
    public partial class AddUsers : System.Web.UI.Page
    {

        Users_Class Us = new Users_Class();
        Users_Interface Iu = new Users_Imp();
        Grant_Interface Ig = new Grant_Imp();
        Role_Interface Ir = new Role_Imp();

        int msg,resp;
        string id;
        string code;
        string codeMin;
        string sytemTitle;
        string slogan;

        protected void Page_Load(object sender, EventArgs e)
        {
            ChargeCookies();
            dropDownRole();
            Ministry();
            id = Request.QueryString["USERS_ID"];
            MultiView.ActiveViewIndex = 0;
            if (!IsPostBack)
            {
                MsgInit();

                txtSystemTitle.Text = sytemTitle;
                txtHeaderSlogan.Text = slogan;

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

        void ChargeCookies()
        {
            if (Request.Cookies["Code_Min"] != null || Request.Cookies["Slogan"] != null || Request.Cookies["System_Title"] != null)
            {
                codeMin = Request.Cookies["Code_Min"].Value;
                sytemTitle = Request.Cookies["System_Title"].Value;
                slogan = Request.Cookies["Slogan"].Value;
            }

        }
        private void MsgInit()
        {
            SuccessMsg.Visible = false;
            FillMsg.Visible = false;
            FailMsg.Visible = false;
            MsgUserName.Visible = false;
        }

        //Code Generate
        string UserCode()
        {
            return code = "User" + (Convert.ToInt32(Iu.count(codeMin) + 1)) + "" + DateTime.Now.Year;
        }

        //Add 
        void Add()
        {
            try
            {
                if (txtFirstName.Value == "" || txtAddress.Value == "" || txtTel.Value == "" || txtUserName.Value == "" || txtPassword.Value == "" ||
                    txtLastName.Value == "" || dateBirth.Value == "" || DropDown_Role.SelectedValue == "-1")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                    MsgUserName.Visible = false;
                }
                else
                {
                    
                        if (file_upd.HasFile)
                        {
                            file_upd.SaveAs(Server.MapPath("~/FleetApp/assets/images/Users/") + Path.GetFileName(file_upd.FileName));
                            string img = Path.GetFileName(file_upd.FileName);
                            FileInfo ext = new FileInfo(img);
                            if (ext.Extension == ".ico" || ext.Extension == ".png" || ext.Extension == ".jpg" || ext.Extension == ".jpeg")
                            {
                                if (file_upd.PostedFile.ContentLength < 104857600)
                                {
                                    Us.First_Name = txtFirstName.Value;
                                    Us.Last_Name = txtLastName.Value;
                                    Us.Code_Min = codeMin;
                                    Us.Address = txtAddress.Value;
                                    Us.Phone = txtTel.Value;
                                    Us.DOB = dateBirth.Value;
                                    Us.User_Nme = txtUserName.Value;
                                    Us.Email = txtMail.Value;
                                    Us.Password = txtPassword.Value;
                                    Us.User_Code = UserCode();
                                    Us.State = DropDown_State.SelectedValue;
                                    Us.Saved_Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                    Us.Picture = img;
                                    Us.ROLE_ID = Convert.ToInt64(DropDown_Role.SelectedValue);
                                    Us.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);

                                    msg = Iu.Add(Us);
                                    if (msg > 0)
                                    {
                                        FillMsg.Visible = false;
                                        FailMsg.Visible = false;
                                        SuccessMsg.Visible = true;
                                        MsgUserName.Visible = false;

                                        dateBirth.Value = "";
                                        txtTel.Value = "";
                                        txtCodeUser.Value = "";
                                        txtPassword.Value = "";
                                        txtFirstName.Value = "";
                                        txtTel.Value = "";
                                        txtAddress.Value = "";
                                        txtUserName.Value = "";
                                        txtCodeUser.Value = "";
                                        txtMail.Value = "";
                                        txtLastName.Value = "";

                                    }
                                    else
                                    {
                                        SuccessMsg.Visible = false;
                                        FillMsg.Visible = false;
                                        FailMsg.Visible = true;
                                        MsgUserName.Visible = false;

                                    }
                                }
                                else
                                {
                                    SuccessMsg.Visible = false;
                                    FillMsg.Visible = false;
                                    FailMsg.Visible = true;
                                    MsgUserName.Visible = false;
                                }
                            }
                            else
                            {
                                SuccessMsg.Visible = false;
                                FillMsg.Visible = false;
                                FailMsg.Visible = true;
                                MsgUserName.Visible = false;
                            }
                        }
                        else
                        {
                            Us.First_Name = txtFirstName.Value;
                            Us.Last_Name = txtLastName.Value;
                            Us.Code_Min = codeMin;
                            Us.Address = txtAddress.Value;
                            Us.Phone = txtTel.Value;
                            Us.User_Code = UserCode();
                            Us.State = DropDown_State.SelectedValue;
                            Us.Saved_Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            Us.DOB = dateBirth.Value;
                            Us.User_Nme = txtUserName.Value;
                            Us.Email = txtMail.Value;
                            Us.Password = txtPassword.Value;
                            Us.ROLE_ID = Convert.ToInt64(DropDown_Role.SelectedValue);
                            Us.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                            Us.Picture = "unkownUser.jpg";


                            msg = Iu.Add(Us);
                            if (msg > 0)
                            {
                                FillMsg.Visible = false;
                                FailMsg.Visible = false;
                                SuccessMsg.Visible = true;
                                MsgUserName.Visible = false;

                                dateBirth.Value = "";
                                txtTel.Value = "";
                                txtCodeUser.Value = "";
                                txtPassword.Value = "";
                                txtFirstName.Value = "";
                                txtTel.Value = "";
                                txtAddress.Value = "";
                                txtUserName.Value = "";
                                txtCodeUser.Value = "";
                                txtMail.Value = "";
                                txtLastName.Value = "";
                            }
                            else
                            {
                                SuccessMsg.Visible = false;
                                FillMsg.Visible = false;
                                FailMsg.Visible = true;
                                MsgUserName.Visible = false;

                            }
                        }
                }
            }

            catch (SqlException e)
            {
                SuccessMsg.Visible = false;
                FillMsg.Visible = false;
                FailMsg.Visible = true;
                MsgUserName.Visible = false;
            }
        }

        //update
        void Update()
        {

            try
            {
                if (txtFirstName.Value == "" || txtAddress.Value == "" || txtTel.Value == "" || txtUserName.Value == "" || txtPassword.Value == "" ||
                    txtLastName.Value == "" || txtCodMin.Value == "" || dateBirth.Value == "" || DropDown_Role.SelectedValue == "-1")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                    MsgUserName.Visible = false;
                }
                else
                {
                    

                        if (file_upd.HasFile)
                        {
                            file_upd.SaveAs(Server.MapPath("~/FleetApp/assets/images/Users/") + Path.GetFileName(file_upd.FileName));
                            string img = Path.GetFileName(file_upd.FileName);
                            FileInfo ext = new FileInfo(img);
                            if (ext.Extension == ".ico" || ext.Extension == ".png" || ext.Extension == ".jpg" || ext.Extension == ".jpeg")
                            {
                                if (file_upd.PostedFile.ContentLength < 104857600)
                                {
                                    Us.First_Name = txtFirstName.Value;
                                    Us.Last_Name = txtLastName.Value;
                                    Us.Code_Min = codeMin;
                                    Us.Address = txtAddress.Value;
                                    Us.Phone = txtTel.Value;
                                    Us.User_Code = txtCodeUser.Value;
                                    Us.State = DropDown_State.SelectedValue;
                                    Us.Saved_Date = DateSaved.Value;
                                    Us.DOB = dateBirth.Value;
                                    Us.User_Nme = txtUserName.Value;
                                    Us.Email = txtMail.Value;
                                    Us.Password = txtPassword.Value;
                                    Us.Picture = img;
                                    Us.ROLE_ID = Convert.ToInt64(DropDown_Role.SelectedValue);
                                    Us.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);

                                    msg = Iu.Update(Us, Convert.ToInt32(id));
                                    if (msg > 0)
                                    {
                                        Response.Redirect("~/FleetApp/ViewUsers.aspx");
                                    }
                                    else
                                    {
                                        SuccessMsg.Visible = false;
                                        FillMsg.Visible = false;
                                        FailMsg.Visible = true;
                                        MsgUserName.Visible = false;

                                    }
                                }
                                else
                                {
                                    SuccessMsg.Visible = false;
                                    FillMsg.Visible = false;
                                    FailMsg.Visible = true;
                                    MsgUserName.Visible = false;
                                }
                            }
                            else
                            {
                                SuccessMsg.Visible = false;
                                FillMsg.Visible = false;
                                FailMsg.Visible = true;
                                MsgUserName.Visible = false;
                            }
                        }
                        else
                        {
                            Us.First_Name = txtFirstName.Value;
                            Us.Last_Name = txtLastName.Value;
                            Us.Code_Min = codeMin;
                            Us.Address = txtAddress.Value;
                            Us.Phone = txtTel.Value;
                            Us.User_Code = txtCodeUser.Value;
                            Us.State = DropDown_State.SelectedValue;
                            Us.Saved_Date = DateSaved.Value;
                            Us.DOB = dateBirth.Value;
                            Us.User_Nme = txtUserName.Value;
                            Us.Email = txtMail.Value;
                            Us.Password = txtPassword.Value;
                            Us.ROLE_ID = Convert.ToInt64(DropDown_Role.SelectedValue);
                            Us.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                            Us.Picture = "unkownUser.jpg";

                            msg = Iu.Update(Us, Convert.ToInt32(id));
                            if (msg > 0)
                            {
                                Response.Redirect("~/FleetApp/ViewUsers.aspx");
                            }
                            else
                            {
                                SuccessMsg.Visible = false;
                                FillMsg.Visible = false;
                                FailMsg.Visible = true;
                                MsgUserName.Visible = false;

                            }
                        }
                    
                }
            }
            catch (SqlException e)
            {
                SuccessMsg.Visible = false;
                FillMsg.Visible = false;
                FailMsg.Visible = true;
                MsgUserName.Visible = false;
            }
        }

        //void Verification()
        //{
        //    resp = Iu.CheckInputUser(txtUserName.Value);

        //    if (resp==1 )
        //    {
        //        if (id == null)
        //        {

        //            Add();
        //        }
        //        else
        //            Update();
                
        //    }
        //    else
        //    {
        //        MsgUserName.Visible = true;
        //    }
        //}

            protected void ChargeData()
        {
            if (id != null)
            {
                Iu.provide(Us, Convert.ToInt32(id));

                string img = Path.GetFileName(file_upd.FileName);

                txtCodMin.Value = Us.Code_Min;
                txtFirstName.Value = Us.First_Name;
                txtAddress.Value = Us.Address;
                txtTel.Value = Us.Phone;
                txtLastName.Value = Us.Last_Name;
                txtCodeUser.Value = Us.User_Code;
                DropDown_State.SelectedValue = Us.State;
                DateSaved.Value = Us.Saved_Date;
                dateBirth.Value = Us.DOB;
                txtUserName.Value = Us.User_Nme;
                txtPassword.Value = Us.Password;
                txtMail.Value = Us.User_Nme;
                // Path.GetFileName(file_upd.FileName).ToString() = Us.Picture;
                DropDown_Role.SelectedValue = Us.ROLE_ID.ToString();
                DropDown_Ministry.SelectedValue = Us.MINISTRY_ID.ToString();

            }
        }
        void dropDownRole()
        {
            Ir.DropdownRole(DropDown_Role);
        }
        protected void btn_save_Click(object sender, EventArgs args)
        {
            //Verification();

            if (id == null)
            {

                Add();
            }
            else
                Update();
        }

        //Add dropDown Minisrty
        void Ministry()
        {
            if (codeMin == "All")
            {
                DMinistry.Visible = true;
                Iu.DisplayMinistryAll(DropDown_Ministry);
            }
            else
            {
                Iu.DisplayMinistry(DropDown_Ministry, codeMin);
                DMinistry.Visible = false;
            }
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
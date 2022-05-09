using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;
using VehicleFleetManagment.FleetModel;
using System.Data.Entity;

namespace VehicleFleetManagment.FleetImp
{
    public class Driver_Imp : Driver_Interface
    {

        int msg;
        DRIVER D = new DRIVER();

        //ADD METHOD
        public int Add(Driver_Class Dr)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                D.Driver_Code = Dr.Driver_Code;
                D.Full_Name = Dr.Full_Name;
                D.CNI = Dr.CNI;
                D.Address1 = Dr.Address1;
                D.Address2 = Dr.Address2;
                D.Address3 = Dr.Address3;
                D.Driver_Type = Dr.Driver_Type;
                D.Postal_code = Dr.Postal_code;
                D.Email = Dr.Email;
                D.Nationality = Dr.Nationality;
                D.Gender = Dr.Gender;
                D.Marital_Status = Dr.Marital_Status;
                D.DOB = Dr.DOB;
                D.Mother_Language = Dr.Mother_Language;
                D.Office_Phone = Dr.Office_Phone;
                D.Personnal_Phone = Dr.Personnal_Phone;
                D.Picture = Dr.Picture;

                con.DRIVERs.Add(D);

                if (con.SaveChanges() > 0)
                {
                    msg = 1;
                }
                else
                {
                    msg = 0;
                }
            }


            return msg;
        }

        //UPDATE METHOD
        public int Update(Driver_Class Dr, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                DRIVER D = new DRIVER();
                D = con.DRIVERs.Where(x => x.DRIVER_ID == id).FirstOrDefault();

                if (D != null)
                {

                    D.Driver_Code = Dr.Driver_Code;
                    D.Full_Name = Dr.Full_Name;
                    D.CNI = Dr.CNI;
                    D.Address1 = Dr.Address1;
                    D.Address2 = Dr.Address2;
                    D.Address3 = Dr.Address3;
                    D.Driver_Type = Dr.Driver_Type;
                    D.Postal_code = Dr.Postal_code;
                    D.Email = Dr.Email;
                    D.Nationality = Dr.Nationality;
                    D.Gender = Dr.Gender;
                    D.Marital_Status = Dr.Marital_Status;
                    D.DOB = Dr.DOB;
                    D.Mother_Language = Dr.Mother_Language;
                    D.Office_Phone = Dr.Office_Phone;
                    D.Personnal_Phone = Dr.Personnal_Phone;
                    D.Picture = Dr.Picture;

                    if (con.SaveChanges() > 0)
                    {
                        con.DRIVERs.Add(D);
                        con.Entry(D).State = EntityState.Modified;

                        msg = 1;
                    }

                    else
                        msg = 0;
                }
            }


            return msg;
        }

        //DELETE METHOD
        public int Delete(int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = con.DRIVERs.Where(x => x.DRIVER_ID == id).First();

                if (con.Entry(obj).State == EntityState.Detached)
                {
                    con.DRIVERs.Attach(obj);

                }
                con.DRIVERs.Remove(obj);
                con.SaveChanges();
                return msg;
            }

        }

        //DELETE CHECK METHOD
        public int DeleteCheck(GridView gd, CheckBox chk, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                for (int i = 0; i < gd.Rows.Count; i++)
                {
                    CheckBox chkselect = (CheckBox)gd.Rows[i].FindControl("chk");
                    if (chkselect.Checked == true)
                    {
                        id = Convert.ToInt32(gd.Rows[i].Cells[i].Text);
                        var obj = con.DRIVERs.Where(x => x.DRIVER_ID == id).First();

                        if (con.Entry(obj).State == EntityState.Detached)
                        {
                            con.DRIVERs.Attach(obj);


                        }
                        con.DRIVERs.Remove(obj);
                        con.SaveChanges();
                    }
                }
                return msg;
            }

        }


        //DISPLAY METHOD
        public void Display(GridView gd)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from D in con.DRIVERs

                           select new
                           {
                               DRIVER_ID = D.DRIVER_ID,
                               Driver_Code= D.Driver_Code ,
                               Full_Name= D.Full_Name ,
                               CNI=D.CNI,
                               Address1= D.Address1,
                               Address2= D.Address2,
                               Address3= D.Address3,
                               Driver_Type=D.Driver_Type,
                               Postal_code=D.Postal_code,
                               Email = D.Email,
                               Nationality=D.Nationality,
                               Gender=D.Gender,
                               Marital_Status=D.Marital_Status,
                               DOB=D.DOB,
                               Mother_Language=D.Mother_Language,
                               Office_Phone=D.Office_Phone,
                               Personnal_Phone=D.Personnal_Phone,
                               Picture=D.Picture
            }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //PROVIDE METHOD
        public void provide(Driver_Class Dr, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                D = con.DRIVERs.Where(x => x.DRIVER_ID == id).FirstOrDefault();

                Dr.Driver_Code = D.Driver_Code;
                Dr.Full_Name = D.Full_Name;
                Dr.CNI = D.CNI;
                Dr.Address1 = D.Address1;
                Dr.Address2 = D.Address2;
                Dr.Address3 = D.Address3;
                Dr.Driver_Type = D.Driver_Type;
                Dr.Postal_code = D.Postal_code;
                Dr.Email = D.Email;
                Dr.Nationality = D.Nationality;
                Dr.Gender = D.Gender;
                Dr.Marital_Status = D.Marital_Status;
                Dr.DOB = D.DOB;
                Dr.Mother_Language = D.Mother_Language;
                Dr.Office_Phone = D.Office_Phone;
                Dr.Personnal_Phone = D.Personnal_Phone;
                Dr.Picture = D.Picture;

            }
        }

        //COUNT METHOD
        public int count()
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var D = (from l in con.DRIVERs
                         select l).Count();
                n = D;
            }
            return n;
        }

        //REASEARCH METHOD
        public void Research(GridView gd, string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from D in con.DRIVERs
                           where
                       D.Full_Name.StartsWith(SearchText) ||
                       D.Driver_Code.StartsWith(SearchText) ||
                       D.DOB.StartsWith(SearchText) ||
                       D.Personnal_Phone.StartsWith(SearchText) ||
                       D.Office_Phone.StartsWith(SearchText) ||
                       D.CNI.StartsWith(SearchText) ||
                       D.Driver_Type.StartsWith(SearchText)

                           select new
                           {
                               DRIVER_ID = D.DRIVER_ID,
                               Driver_Code = D.Driver_Code,
                               Full_Name = D.Full_Name,
                               CNI = D.CNI,
                               Address1 = D.Address1,
                               Address2 = D.Address2,
                               Address3 = D.Address3,
                               Driver_Type = D.Driver_Type,
                               Postal_code = D.Postal_code,
                               Email = D.Email,
                               Nationality = D.Nationality,
                               Gender = D.Gender,
                               Marital_Status = D.Marital_Status,
                               DOB = D.DOB,
                               Mother_Language = D.Mother_Language,
                               Office_Phone = D.Office_Phone,
                               Personnal_Phone = D.Personnal_Phone,
                               Picture = D.Picture

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;
using VehicleFleetManagment.FleetModel;

namespace VehicleFleetManagment.FleetImp
{
    public class Users_Imp: Users_Interface
    {


        int msg;
        USER U = new USER();
        MINISTRY M = new MINISTRY();

        //ADD METHOD
        public int Add(Users_Class Us)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                U.First_Name = Us.First_Name;
                U.Address = Us.Address;
                U.Phone = Us.Phone;
                U.Last_Name = Us.Last_Name;
                U.Code_Min = Us.Code_Min;
                U.User_Nme = Us.User_Nme;
                U.DOB = Us.DOB;
                U.MINISTRY_ID = Us.MINISTRY_ID;
                U.Password = Us.Password;
                U.Picture = Us.Picture;
                U.ROLE_ID = Us.ROLE_ID;
                U.Email = Us.Email;
                U.User_Code = Us.User_Code;
                U.State = Us.State;
                U.Saved_Date = Us.Saved_Date;

                con.USERS.Add(U);

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
        public int Update(Users_Class Us, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                USER U = new USER();
                U = con.USERS.Where(x => x.USERS_ID == id).FirstOrDefault();

                if (U != null)
                {

                    U.Code_Min = Us.Code_Min;
                    U.First_Name = Us.First_Name;
                    U.Address = Us.Address;
                    U.Phone = Us.Phone;
                    U.Last_Name = Us.Last_Name;
                    U.User_Nme = Us.User_Nme;
                    U.DOB = Us.DOB;
                    U.MINISTRY_ID = Us.MINISTRY_ID;
                    U.Password = Us.Password;
                    U.Picture = Us.Picture;
                    U.ROLE_ID = Us.ROLE_ID;
                    U.Email = Us.Email;
                    U.User_Code = Us.User_Code;
                    U.State = Us.State;
                    U.Saved_Date = Us.Saved_Date;

                    if (con.SaveChanges() > 0)
                    {
                        con.USERS.Add(U);
                        con.Entry(U).State = EntityState.Modified;

                        msg = 1;
                    }

                    else
                        msg = 0;
                }
            }


            return msg;
        }


        //Login Connection METHOD
        public int Connexion(Users_Class Us,Ministry_Class Min, string userName, string password)
        {
            string code;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                U = con.USERS.Where(x => x.User_Nme == userName && x.Password == password).FirstOrDefault();

                if (U != null )
                {
                    code = U.Code_Min;
                    M = con.MINISTRies.Where(x => x.Code_Min == code).FirstOrDefault();

                    Us.Code_Min = U.Code_Min;
                    Us.First_Name = U.First_Name;
                    Us.USERS_ID = U.USERS_ID;
                    Us.Address = U.Address;
                    Us.Phone = U.Phone;
                    Us.Last_Name = U.Last_Name;
                    Us.User_Nme = U.User_Nme;
                    Us.DOB = U.DOB;
                    Us.Email= U.Email;
                    Us.MINISTRY_ID = U.MINISTRY_ID;
                    Us.Password = U.Password;
                    Us.ROLE_ID = U.ROLE_ID;
                    Us.Picture = U.Picture;
                    Us.User_Code = U.User_Code;
                    Us.State = U.State;
                    Us.Saved_Date = U.Saved_Date;

                    Min.System_Title = M.System_Title;
                    Min.System_Name= M.System_Name;
                    Min.Ministry_Name = M.Ministry_Name;
                    Min.Code_Min = M.Code_Min;
                    Min.System_Email = M.System_Email;
                    Min.Logo = M.Logo;
                    Min.Fax = M.Fax;
                    Min.Postal_code = M.Postal_code;
                    Min.MINISTRY_ID = M.MINISTRY_ID;
                    Min.Slogan = M.Slogan;
                    Min.Theme = M.Theme;
                    Min.Picture = M.Picture;

                    return msg = 1;
                }
                else return msg = 0;

            }
        }

        //DELETE METHOD
        public int Delete(int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = con.USERS.Where(x => x.USERS_ID == id).First();

                if (con.Entry(obj).State == EntityState.Detached)
                {
                    con.USERS.Attach(obj);

                }
                con.USERS.Remove(obj);
                con.SaveChanges();
                return msg;
            }

        }

        //DISPLAY METHOD
        public void DisplayAll(GridView gd)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from U in con.USERS

                           select new
                           {
                               USERS_ID = U.USERS_ID,
                               ROLR_ID = U.ROLE.Role_Name,
                               Code_Min = U.Code_Min,
                               First_Name = U.First_Name,
                               Address = U.Address,
                               Phone = U.Phone,
                               Last_Name = U.Last_Name,
                               User_Nme = U.User_Nme,
                               Email = U.Email,
                               DOB = U.DOB,
                               MINISTRY_ID = U.MINISTRY.Ministry_Name,
                               ROLE_ID = U.ROLE.Role_Name,
                               Password = U.Password,
                               Picture = U.Picture,
                               User_Code = U.User_Code,
                               Saved_Date = U.Saved_Date,
                               State = U.State,
                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //DISPLAY METHOD
        public void Display(GridView gd,string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from U in con.USERS where U.Code_Min==codeMin

                           select new
                           {
                               USERS_ID = U.USERS_ID,
                               ROLR_ID = U.ROLE.Role_Name,
                               Code_Min = U.Code_Min,
                               First_Name = U.First_Name,
                               Address = U.Address,
                               Phone = U.Phone,
                               Last_Name = U.Last_Name,
                               User_Nme = U.User_Nme,
                               Email = U.Email,
                               DOB = U.DOB,
                               MINISTRY_ID = U.MINISTRY.Ministry_Name,
                               ROLE_ID = U.ROLE.Role_Name,
                               Password = U.Password,
                               Picture = U.Picture,
                               User_Code = U.User_Code,
                               Saved_Date = U.Saved_Date,
                               State = U.State,
                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //PROVIDE METHOD
        public void provide(Users_Class Us, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                U = con.USERS.Where(x => x.USERS_ID == id).FirstOrDefault();

                Us.Code_Min = U.Code_Min;
                Us.First_Name = U.First_Name;
                Us.Address = U.Address;
                Us.Phone = U.Phone;
                Us.Last_Name = U.Last_Name;
                Us.User_Nme = U.User_Nme;
                Us.DOB = U.DOB;
                Us.Email = U.Email;
                Us.MINISTRY_ID = U.MINISTRY_ID;
                Us.Password = U.Password;
                Us.ROLE_ID = U.ROLE_ID;
                Us.Picture = U.Picture;
                Us.Saved_Date = U.Saved_Date;
                Us.State = U.State;
                Us.User_Code = U.User_Code;

            }
        }

        //Profile METHOD
        public void Profile(Users_Class Us, string userName)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                U = con.USERS.Where(x => x.User_Nme == userName).FirstOrDefault();

                Us.Code_Min = U.Code_Min;
                Us.First_Name = U.First_Name;
                Us.Address = U.Address;
                Us.Phone = U.Phone;
                Us.Last_Name = U.Last_Name;
                Us.User_Nme = U.User_Nme;
                Us.DOB = U.DOB;
                Us.Email = U.Email;
                Us.MINISTRY_ID = U.MINISTRY_ID;
                Us.Password = U.Password;
                Us.Picture = U.Picture;
                Us.ROLE_ID = U.ROLE_ID;
                Us.User_Code = U.User_Code;
                Us.Saved_Date = U.Saved_Date;
                Us.State = U.State;

            }
        }

        //COUNT ALL METHOD
        public int countAll()
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var U = (from l in con.USERS
                         select l).Count();
                n = U;
            }
            return n;
        }

        //COUNT METHOD
        public int count(string codeMin)
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var M = (from l in con.USERS
                         where l.Code_Min == codeMin
                         select l).Count();
                n = M;
            }
            return n;
        }

        //REASEARCH METHOD
        public void ResearchAll(GridView gd, string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from U in con.USERS
                           where
                       U.First_Name.StartsWith(SearchText) ||
                       U.Last_Name.StartsWith(SearchText) ||
                       U.Address.StartsWith(SearchText) ||
                       U.ROLE.Role_Name.StartsWith(SearchText) ||
                       U.Code_Min.StartsWith(SearchText)

                           select new
                           {
                               USERS_ID = U.USERS_ID,
                               Code_Min = U.Code_Min,
                               ROLE_ID = U.ROLE.Role_Name,
                               First_Name = U.First_Name,
                               Address = U.Address,
                               Phone = U.Phone,
                               Last_Name = U.Last_Name,
                               User_Nme = U.User_Nme,
                               Email = U.Email,
                               DOB = U.DOB,
                               MINISTRY_ID = U.MINISTRY.Ministry_Name,
                               Password = U.Password,
                               Picture = U.Picture,
                               User_Code = U.User_Code,
                               Saved_Date = U.Saved_Date,
                               State = U.State,

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //REASEARCH METHOD
        public void Research(GridView gd, string codeMin, string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from U in con.USERS
                           where U.Code_Min== codeMin &&
                       U.First_Name.StartsWith(SearchText) ||
                       U.Last_Name.StartsWith(SearchText) ||
                       U.Address.StartsWith(SearchText) ||
                       U.ROLE.Role_Name.StartsWith(SearchText) ||
                       U.Code_Min.StartsWith(SearchText)

                           select new
                           {
                               USERS_ID = U.USERS_ID,
                               Code_Min = U.Code_Min,
                               First_Name = U.First_Name,
                               Address = U.Address,
                               Phone = U.Phone,
                               Last_Name = U.Last_Name,
                               User_Nme = U.User_Nme,
                               Email = U.Email,
                               DOB = U.DOB,
                               MINISTRY_ID = U.MINISTRY.Ministry_Name,
                               ROLR_ID = U.ROLE.Role_Name,
                               Password = U.Password,
                               Picture = U.Picture,
                               User_Code = U.User_Code,
                               Saved_Date = U.Saved_Date,
                               State = U.State,

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        public void DisplayMinistry(DropDownList drop, string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from M in con.MINISTRies
                           where M.Code_Min == codeMin

                           select new
                           {
                               MINISTRY_ID = M.MINISTRY_ID,
                               Ministry_Name = M.Ministry_Name,

                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "MINISTRY_ID";
                drop.DataTextField = "Ministry_Name";
                drop.DataBind();
            }

        }

        //DISPLAY METHOD All MINISTRY
        public void DisplayMinistryAll(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from M in con.MINISTRies

                           select new
                           {
                               MINISTRY_ID = M.MINISTRY_ID,
                               Ministry_Name = M.Ministry_Name,

                           }
                           ).ToList();

               
                drop.DataSource = obj;
                drop.DataValueField = "MINISTRY_ID";
                drop.DataTextField = "Ministry_Name";
                drop.DataBind();
            }

        }

        //UPDATE  STATE METHOD
        public int UpdateState(int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                USER U = new USER();
                U = con.USERS.Where(x => x.USERS_ID == id).FirstOrDefault();

                if (U != null)
                {
                    if (U.State == "ON")
                        U.State = "OFF";
                    else
                        U.State = "ON";

                    if (con.SaveChanges() > 0)
                    {
                        con.USERS.Add(U);
                        con.Entry(U).State = EntityState.Modified;

                        msg = 1;
                    }

                    else
                        msg = 0;
                }
            }


            return msg;
        }

        //Check if usernane is already used METHOD
        public int CheckInputUser(string userName)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                U = con.USERS.Where(x => x.User_Nme == userName).FirstOrDefault();

                if (U == null)
                {

                    msg = 1;
                }
                else msg = 0;

            }
            return msg;
        }
    }
}
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
    public class Provider_Imp : Provider_Interface
    {

        int msg;
        PROVIDER P = new PROVIDER();

        //ADD METHOD
        public int Add(Provider_Class Pr)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                P.Provider_Type = Pr.Provider_Type;
                P.Provider_Code = Pr.Provider_Code;
                P.Full_Name = Pr.Full_Name;
                P.Phone = Pr.Phone;
                P.Email = Pr.Email;
                P.DOB = Pr.DOB;
                P.CNI = Pr.CNI;
                P.Address = Pr.Address;
                P.Picture = Pr.Picture;
                P.Contract = Pr.Contract;
                P.Saved_Date = Pr.Saved_Date;
                P.Stat = Pr.Stat;
                P.Deleted ="False";

                con.PROVIDERs.Add(P);

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
        public int Update(Provider_Class Pr, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                PROVIDER P = new PROVIDER();
                P = con.PROVIDERs.Where(x => x.PROVIDER_ID == id).FirstOrDefault();

                if (P != null)
                {

                    P.Provider_Type = Pr.Provider_Type;
                    P.Provider_Code = Pr.Provider_Code;
                    P.Full_Name = Pr.Full_Name;
                    P.Phone = Pr.Phone;
                    P.Email = Pr.Email;
                    P.DOB = Pr.DOB;
                    P.CNI = Pr.CNI;
                    P.Address = Pr.Address;
                    P.Picture = Pr.Picture;
                    P.Contract = Pr.Contract;
                    P.Saved_Date = Pr.Saved_Date;
                    P.Stat = Pr.Stat;
                    P.Deleted = "False";

                    if (con.SaveChanges() > 0)
                    {
                        con.PROVIDERs.Add(P);
                        con.Entry(P).State = EntityState.Modified;

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
                var obj = con.PROVIDERs.Where(x => x.PROVIDER_ID == id).First();

                if (con.Entry(obj).State == EntityState.Detached)
                {
                    con.PROVIDERs.Attach(obj);

                }
                con.PROVIDERs.Remove(obj);
                con.SaveChanges();
                return msg;
            }

        }

        //CHANGE DELETE STATE METHOD
        public int DeleteState(int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                PROVIDER P = new PROVIDER();
                P = con.PROVIDERs.Where(x => x.PROVIDER_ID == id).FirstOrDefault();

                if (P != null)
                {
                    P.Deleted = "True";

                    if (con.SaveChanges() > 0)
                    {
                        con.PROVIDERs.Add(P);
                        con.Entry(P).State = EntityState.Modified;

                        msg = 1;
                    }

                    else
                        msg = 0;
                }
            }


            return msg;
        }

        //DISPLAY METHOD
        public void Display(GridView gd)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from P in con.PROVIDERs where P.Deleted=="False"

                           select new
                           {
                               PROVIDER_ID = P.PROVIDER_ID,
                               Provider_Type = P.Provider_Type,
                               Provider_Code = P.Provider_Code,
                               Full_Name = P.Full_Name,
                               Phone = P.Phone,
                               Email = P.Email,
                               Stat = P.Stat,
                               DOB = P.DOB,
                               CNI = P.CNI,
                               Address = P.Address,
                               Picture = P.Picture,
                               Contract = P.Contract,
                               Saved_Date = P.Saved_Date,
                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //PROVIDE METHOD
        public void provide(Provider_Class Pr, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                P = con.PROVIDERs.Where(x => x.PROVIDER_ID == id).FirstOrDefault();
                Pr.Provider_Type = P.Provider_Type;
                Pr.Provider_Code = P.Provider_Code;
                Pr.Full_Name = P.Full_Name;
                Pr.Phone = P.Phone;
                Pr.Email = P.Email;
                Pr.DOB = P.DOB;
                Pr.Address = P.Address;
                Pr.CNI = P.CNI;
                Pr.Picture = P.Picture;
                Pr.Contract = P.Contract;
                Pr.Stat = P.Stat;

            }
        }

        //DISPLAY METHOD Where CNI
        public int ProvideByCNI(Provider_Class Pr, string cni)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                P = con.PROVIDERs.Where(x => x.CNI == cni && x.Deleted == "False").FirstOrDefault();

                if (P != null)
                {
                    Pr.Provider_Type = P.Provider_Type;
                    Pr.Provider_Code = P.Provider_Code;
                    Pr.Full_Name = P.Full_Name;
                    Pr.Phone = P.Phone;
                    Pr.Email = P.Email;
                    Pr.DOB = P.DOB;
                    Pr.Address = P.Address;
                    Pr.CNI = P.CNI;
                    Pr.Picture = P.Picture;
                    Pr.Contract = P.Contract;
                    Pr.Stat = P.Stat;

                    return msg = 1;
                }
                else
                    return msg = 0;

            }

        }

        //COUNT METHOD
        public int count()
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var P = (from l in con.PROVIDERs where l.Deleted == "False"
                         select l).Count();
                n = P;
            }
            return n;
        }

        //REASEARCH METHOD
        public void Research(GridView gd, string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from P in con.PROVIDERs
                           where P.Deleted == "False" &&
                       P.Full_Name.StartsWith(SearchText) ||
                       P.Provider_Code.StartsWith(SearchText) ||
                       P.Stat.StartsWith(SearchText) ||
                       P.Phone.StartsWith(SearchText) ||
                       P.CNI.StartsWith(SearchText) ||
                       P.Address.StartsWith(SearchText) ||
                       P.Provider_Type.StartsWith(SearchText)

                           select new
                           {
                               PROVIDER_ID = P.PROVIDER_ID,
                               Provider_Type = P.Provider_Type,
                               Provider_Code = P.Provider_Code,
                               Full_Name = P.Full_Name,
                               Phone = P.Phone,
                               Email = P.Email,
                               Stat = P.Stat,
                               DOB = P.DOB,
                               CNI = P.CNI,
                               Address = P.Address,
                               Picture = P.Picture,
                               Contract = P.Contract,
                               Saved_Date = P.Saved_Date,

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using RoomsMgmtSystem.Models;
using System.Web.Security; 

namespace RoomsMgmtSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        string myConnectionString = "server=localhost;uid=root;" + "database=DB_ROOM_MGMT_SYSTEM; SslMode = none";
        public ActionResult Login()
        { 
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login obj)
        {
            RegistrationDetails RD = new RegistrationDetails();
            RD = AdoLogin(obj);

            if (RD != null)
            {
                Session["ID"] = RD.ID;
                Session["Role"] = RD.Roles;
                return RedirectToAction("Index", "Rooms");
            }
            return View();
        }

        public RegistrationDetails AdoLogin(Login obj)
        {
            RegistrationDetails RD = new RegistrationDetails();
            DataSet ds = new DataSet("Detail");
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString))
            {
                MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter("select * from tbl_Customer_DET o where o.Name= @userName and o.Password= @password", conn);
                da.SelectCommand.Parameters.AddWithValue("@userName", obj.userName);
                da.SelectCommand.Parameters.AddWithValue("@password", obj.password);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    FormsAuthentication.SetAuthCookie(ds.Tables[0].Rows[0]["Roles"].ToString(), false);
                    RD.ID = ds.Tables[0].Rows[0]["ID"].ToString(); 
                    RD.Roles = ds.Tables[0].Rows[0]["Roles"].ToString();
                }

            }
            return RD;
        }

        public ActionResult UserRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserRegistration(RegistrationDetails obj)
        { 
            string Flags = SaveUserDetail(obj);
            if (Flags == "Y")
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                ViewBag.Message = Flags;
            }
            return View();
        }


        public String SaveUserDetail(RegistrationDetails obj)
        {
            int count = 0;
            string Out = "";
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString))
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select Count(*) from tbl_Customer_DET o where o.Name = @username and Password = @password", conn);
                cmd.Parameters.AddWithValue("@username", obj.Name);
                cmd.Parameters.AddWithValue("@password", obj.Password);
                conn.Open();
                count = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                if (count > 0)
                {
                    Out = "User Already Exist.";
                }
                else
                {
                    MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("insert into tbl_Customer_DET(Name,FirstName,LastName,Email,Phone,Password,City,Address,Roles) values(@Name,@FirstName,@LastName,@Email,@Phone,@Password,@City,@Address,@Roles)", conn);
                    cmd1.Parameters.AddWithValue("@Name", obj.Name);
                    cmd1.Parameters.AddWithValue("@FirstName", obj.FirstName);
                    cmd1.Parameters.AddWithValue("@LastName", obj.LastName);
                    cmd1.Parameters.AddWithValue("@Email", obj.Email);
                    cmd1.Parameters.AddWithValue("@Phone", obj.Phone);
                    cmd1.Parameters.AddWithValue("@Password", obj.Password);
                    cmd1.Parameters.AddWithValue("@City", obj.City);
                    cmd1.Parameters.AddWithValue("@Address", obj.Address);
                    cmd1.Parameters.AddWithValue("@Roles", obj.Roles);
                    conn.Open(); 
                    count = cmd1.ExecuteNonQuery();
                    conn.Close();
                    if (count == 0)
                    {
                        Out = "Error While inserting Data.";
                    }
                    else
                    {
                        Out = "Y";
                    }
                }
                return Out;
            }

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
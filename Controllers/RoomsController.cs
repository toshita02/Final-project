using RoomsMgmtSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoomsMgmtSystem.Controllers
{
    [Authorize]
    public class RoomsController : Controller
    {
        // GET: Rooms
        string myConnectionString = "server=localhost;uid=root;" + "database=DB_ROOM_MGMT_SYSTEM; SslMode = none";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomerList()
        {
            List<RegistrationDetails> lstCust = new List<RegistrationDetails>();
            lstCust = GetCustomerDetail();
            return View(lstCust);
        }


        public List<RegistrationDetails> GetCustomerDetail()
        {
            List<RegistrationDetails> lstRD = new List<RegistrationDetails>();
            DataSet ds = new DataSet("Detail");
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString))
            {
                MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter("select * from tbl_Customer_DET o WHERE o.Roles='Tanants'", conn);
                da.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    RegistrationDetails RD = new RegistrationDetails();
                    RD.ID = dr["ID"].ToString();
                    RD.Name = dr["Name"].ToString();
                    RD.FirstName = dr["FirstName"].ToString();
                    RD.LastName = dr["LastName"].ToString();
                    RD.City = dr["City"].ToString();
                    RD.Address = dr["Address"].ToString();
                    RD.Email = dr["Email"].ToString();
                    RD.Phone = dr["Phone"].ToString();
                    RD.Roles = dr["Roles"].ToString();
                    lstRD.Add(RD);
                }
            }
            return lstRD;
        }

        public ActionResult RoomsDetails()
        {

            List<RoomDetails> lstRoomDetails = new List<RoomDetails>();
            lstRoomDetails = GetRoomsDetails();
            return View(lstRoomDetails);
        }

        public List<RoomDetails> GetRoomsDetails()
        {
            List<RoomDetails> lstRoomDetails = new List<RoomDetails>();
            DataSet ds = new DataSet("Detail");
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString))
            { 
                MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter("select * from tbl_rooms_details o order by o.Id", conn);
                da.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    RoomDetails RoomDetail = new RoomDetails();
                    RoomDetail.ID = dr["ID"].ToString();
                    RoomDetail.RoomCopacity = dr["RoomCopacity"].ToString();
                    RoomDetail.Rent = dr["Rant"].ToString();
                    RoomDetail.Electricity = dr["Electricity"].ToString();
                    RoomDetail.WaterSupply = dr["WaterSupply"].ToString();
                    RoomDetail.Total = dr["Total"].ToString();
                    RoomDetail.Image = dr["Image"].ToString();
                    lstRoomDetails.Add(RoomDetail);
                }

            }
            return lstRoomDetails;
        }

        public ActionResult RentDetails(string id)
        {
            RoomDetails RoomDetails = new RoomDetails();
            RoomDetails = GetRentDetails(id);
            return View(RoomDetails); 
        }

        public RoomDetails GetRentDetails(string id)
        {
            RoomDetails RoomDetail = new RoomDetails();
            DataSet ds = new DataSet("Detail");
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString))
            {
                MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter("select * from tbl_rooms_details o where o.ID="+id+" order by o.Id", conn);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count>0)
                {                
                    RoomDetail.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                    RoomDetail.RoomCopacity = ds.Tables[0].Rows[0]["RoomCopacity"].ToString();
                    RoomDetail.Rent = ds.Tables[0].Rows[0]["Rant"].ToString();
                    RoomDetail.Electricity = ds.Tables[0].Rows[0]["Electricity"].ToString();
                    RoomDetail.WaterSupply = ds.Tables[0].Rows[0]["WaterSupply"].ToString();
                    RoomDetail.Total = ds.Tables[0].Rows[0]["Total"].ToString();
                    RoomDetail.Image = ds.Tables[0].Rows[0]["Image"].ToString();
                }
            }
            return RoomDetail;
        }

        public ActionResult NewBooking(string id) 
        {           
            int count = 0;
            string Out = "";
            string CustId = "";
            if (Session["ID"] != null)
            {
                CustId = Session["ID"].ToString();
            }
            else
            {
                return RedirectToAction("Login");
            } 

            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString))
            {
                 MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("insert into tbl_PAYMENT_DETAIL(Cust_id,Room_id,StartDate,PayAmount) Select " + CustId + ", " + id + ", @StartDate, Total from tbl_rooms_details where id= @Room_id", conn); 
                 cmd1.Parameters.AddWithValue("@Room_id", id);
                 cmd1.Parameters.AddWithValue("@StartDate", DateTime.Now);
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
            //return Out;
            return View("Index");
        } 

        public ActionResult Payment() 
        {
            return View();
        }

        public ActionResult BillReport()
        {
            string CustId = "";
            string Role = "";
            string Query="";
            List<PayDetail> lstPayDetail = new List<PayDetail>();
            
            DataSet ds = new DataSet("Detail");
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString))
            {
                if (Session["ID"] != null)
                {
                    CustId = Session["ID"].ToString();
                    Role = Session["Role"].ToString(); 
                }
                else
                {
                    return RedirectToAction("Login","Login");
                }

                if (Role == "Tanants")
                {
                    Query = "SELECT P.ID ,C.FirstName,C.LastName ,C.Email ,C.Phone ,R.RoomCopacity,R.Total ,P.PayAmount , P.DueAmount FROM tbl_payment_detail P Inner Join tbl_customer_det C Inner Join tbl_rooms_details R On P.Cust_ID = C.ID AND P.Room_Id = R.ID AND C.Roles = 'Tanants' AND C.ID =" + CustId + " order by P.ID";
                }
                else
                {
                    Query = "SELECT P.ID ,C.FirstName,C.LastName ,C.Email ,C.Phone ,R.RoomCopacity,R.Total ,P.PayAmount , P.DueAmount FROM tbl_payment_detail P Inner Join tbl_customer_det C Inner Join tbl_rooms_details R On P.Cust_ID = C.ID AND P.Room_Id = R.ID AND C.Roles = 'Tanants' order by P.ID";
                }
                MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(Query, conn);

                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    PayDetail PayDetail = new PayDetail();
                    PayDetail.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                    PayDetail.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    PayDetail.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                    PayDetail.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                    PayDetail.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                    PayDetail.RoomCopacity = ds.Tables[0].Rows[0]["RoomCopacity"].ToString();
                    PayDetail.Total = ds.Tables[0].Rows[0]["Total"].ToString();
                    PayDetail.PayAmount = ds.Tables[0].Rows[0]["PayAmount"].ToString();
                    PayDetail.DueAmount = ds.Tables[0].Rows[0]["DueAmount"].ToString();
                    lstPayDetail.Add(PayDetail);
                }
            } 
            return View(lstPayDetail);
        }
    }
}
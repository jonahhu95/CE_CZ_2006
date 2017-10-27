using ASPWebsite.App_Code.Entity;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Control
{
    public class DatabaseManager
    {

        public Boolean getConnection()
        {
            string dbLocation = HttpContext.Current.Server.MapPath("/App_Data");
            dbLocation = dbLocation + "\\SqliteDatabase.db";
            SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + dbLocation + ";Version=3;");
            dbConnection.Open();
            return true;
        }

        public void saveCalculation(Calculation calculation, User user)
        {
            //try
            //{
            //    Connection con = getConnection();
            //    PreparedStatement update = con.prepareStatement("INSERT INTO score_t (username,datet,workLocation,workLongitude,workLatitude,workArea,homeLocation,homeLongitude,"
            //            + "homeLatitude,homeArea,salary,salarySat,medianSalary,jobInterest,commuteType,ridersArea,AvgRidersArea,commuteTime,AvgCommuteTime,monthCost) VALUES "
            //            + "('" + username + "','" + (new Timestamp(calculation.getCreatedTime())) + "','" + calculation.getWorkLocation().getLocationName() + "','" + calculation.getWorkLocation().getLongitude() + "','"
            //            + calculation.getWorkLocation().getLatitude() + "','" + calculation.getWorkLocation().getArea() + "','" + calculation.getHomeLoction().getLocationName() + "','"
            //            + calculation.getHomeLoction().getLongitude() + "','" + calculation.getHomeLoction().getLatitude() + "','" + calculation.getHomeLoction().getArea() + "','"
            //            + calculation.getSalary() + "','" + calculation.getSalarySatisfaction() + "','" + calculation.getMedianSalary() + "','" + calculation.getJobInterest() + "','" + calculation.getCommuteType() + "','"
            //            + calculation.getRidersArea() + "','" + calculation.getAveRidersArea() + "','" + calculation.getCommuteTime() + "','" + calculation.getAveCommuteTime() + "','"
            //            + calculation.getMonthlyCommuteCost() + "')");
            //    update.executeUpdate();
            //}
            //catch (Exception e)
            //{
            //    System.out.println(e);
            //}
        }

    }
}
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
        private SQLiteCommand command;
        private SQLiteConnection dbConnection;

        public Boolean getConnection()
        {
            string dbLocation = HttpContext.Current.Server.MapPath("/App_Data");
            dbLocation = dbLocation + "\\SqliteDatabase.db";
            dbConnection = new SQLiteConnection("Data Source=" + dbLocation + ";Version=3;");
            dbConnection.Open();
            return true;
        }

        public Boolean saveCalculation(Calculation calculation, User user)
        {
            try
            {
                if (getConnection())
                {
                    string sqlStatement = "INSERT INTO CALCULATION(user_name,created_time,work_location_lon,work_location_lat,work_location_name,work_location_area," +
                        "home_location_lon,home_location_lat,home_location_name,home_location_area,salary,commute_type,job_interest,salary_satisfaction,median_salary," +
                        "riders_area,ave_riders_area,commute_time,ave_commute_time,monthly_commute_cost) VALUES (" + user.getUsername() + "," + calculation.getCreatedTime() + " " + ")";
                    return insertToTable(sqlStatement);
                }

            }
            catch (Exception e)
            {

            }
            return false;
        }

        public Boolean saveUser(User user)
        {
            try
            {
                if (getConnection())
                {
                    string sqlStatement = "INSERT INTO USER(user_name,password) VALUES (" +
                        user.getUsername() + "," + user.getPassword() + ");";
                    return insertToTable(sqlStatement);
                }

            }
            catch (Exception e)
            {
                
            }
            return false;
        }
        public Boolean saveFeedback(Feedback feedback)
        {
            try
            {
                if (getConnection())
                {
                    string sqlStatement = "INSERT INTO FEEDBACK(user_name,message,submit_time) VALUES (" +
                        feedback.getSubmitter() + "," + feedback.getMessage() + "," + feedback.getSubmitTime() + ");";
                    return insertToTable(sqlStatement);
                }

            }
            catch (Exception e)
            {
                //Error Handling
            }
            return false;
        }
        public User getUser(string userName)
        {
            try
            {
                if (getConnection())
                {
                    string sql = "SELECT * from USER WHERE user_name = " + userName;
                    SQLiteDataReader ret = getFromTable(sql);
                    List<User> userList = new List<User>();
                    while (ret.Read())
                    {
                        userList.Add(new User((string)ret["user_name"], (string)ret["password"]));
                    }
                    if (userList.Count == 1)
                    {
                        return userList[0];
                    }
                }
            }
            catch (Exception e)
            {
                //Error Handling
            }
            return null;
        }
        public List<Calculation> getCalculationsOfUser(User user)
        {
            /*try
            {
                if (getConnection())
                {
                    string sql = "SELECT * from CALCULATION WHERE user_name = " + user.getUsername();
                    SQLiteDataReader ret = getFromTable(sql);
                    List<Calculation> calList = new List<Calculation>();
                    while (ret.Read())
                    {
                        Address home = new Address((string)ret["home_location_name"], (double)ret["home_location_lon"],
                            (double)ret["home_location_lat"], (string)ret["home_location_area"]);
                        Address work = new Address((string)ret["work_location_name"], (double)ret["work_location_lon"],
                            (double)ret["work_location_lat"], (string)ret["work_location_area"]);
                        Calculation get = new Calculation(work, home, (int)ret["salary"], (char)ret["commute_type"],
                            (int)ret["job_interest"], (int)ret["salary_satisfaction"], new DateTime(ret["created_time"]),
                            (int)ret["median_salary"], (int)ret["riders_area"], (int)ret["ave_riders_area"],
                            (double)ret["commute_time"], (double)ret["ave_commute_time"], (double)ret["monthly_commute_cost"]);
                        calList.Add(get);
                    }
                    return calList;
                }
            }
            catch (Exception e)
            {
                //Error Handling
            }*/
            return null;
        }
        public List<Feedback> getFeedback()
        {
            try
            {
                if (getConnection())
                {
                    string sql = "SELECT * from FEEDBACK";
                    SQLiteDataReader ret = getFromTable(sql);
                    List<Feedback> feedbackList = new List<Feedback>();
                    while (ret.Read())
                    {
                        feedbackList.Add(new Feedback((string)ret["user_name"], (string)ret["message"], (long)ret["submit_time"]));
                    }
                    return feedbackList;
                }
            }
            catch (Exception e)
            {
                //Error Handling
            }
            return null;
        }

        private Boolean insertToTable(string sqlStatement)
        {
            command = new SQLiteCommand(sqlStatement, dbConnection);
            int rowAffected = command.ExecuteNonQuery();
            if (rowAffected == 1)
            {
                return true;
            }
            return false;
        }
        private SQLiteDataReader getFromTable(string sqlStatement)
        {
            command = new SQLiteCommand(sqlStatement, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            return reader;
        }

    }
}
using ASPWebsite.App_Code.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ASPWebsite.App_Code.Control
{
    /// <summary>
    /// Database manager.
    /// Responsible for managing SQLite Database transactions.
    /// </summary>
    public class DatabaseManager
    {
        private SQLiteCommand command;
        private SQLiteConnection dbConnection;

        /// <summary>
        /// Gets connection to the local SQLite Database file
        /// </summary>
        /// <returns><c>true</c>, if successful, <c>false</c> otherwise.</returns>
        private Boolean getConnection()
        {
            try
            {
                string dbLocation = HttpContext.Current.Server.MapPath("/App_Data");
                dbLocation = dbLocation + "\\SqliteDatabase.db";
                dbConnection = new SQLiteConnection("Data Source=" + dbLocation + ";Version=3;");
                dbConnection.Open();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Saves the calculation.
        /// </summary>
        /// <returns><c>true</c>, if calculation was saved, <c>false</c> otherwise.</returns>
        /// <param name="calculation">Calculation.</param>
        /// <param name="userName">User name</param>
        public Boolean saveCalculation(Calculation calculation, string userName)
        {
            try
            {
                if (getConnection())
                {
                    string sqlStatement = "INSERT INTO CALCULATION(user_name,created_time,work_location_lon,work_location_lat,work_location_name,work_location_area," +
                        "home_location_lon,home_location_lat,home_location_name,home_location_area,salary,commute_type,job_interest,salary_satisfaction,median_salary," +
                        "riders_area,ave_riders_area,commute_time,ave_commute_time,monthly_commute_cost) VALUES ('" + userName + "'," +
                        calculation.getCreatedTime().Ticks + "," + calculation.getWorkLocation().getLongitude() + "," + calculation.getWorkLocation().getLatitude() + ",'" +
                        calculation.getWorkLocation().getLocationName() + "','" + calculation.getWorkLocation().getArea() + "'," + calculation.getHomeLocation().getLongitude() +
                        "," + calculation.getHomeLocation().getLatitude() + ",'" + calculation.getHomeLocation().getLocationName() + "','" + calculation.getHomeLocation().getArea() +
                        "'," + calculation.getSalary() + ",'" + calculation.getCommuteType() + "'," + calculation.getJobInterest() + "," + calculation.getSalarySatisfaction() +
                        "," + calculation.getMedianSalary() + "," + calculation.getRidersArea() + "," + calculation.getAveRidersArea() + "," + calculation.getCommuteTime() + "," +
                        calculation.getAveCommuteTime() + "," + calculation.getMonthlyCommuteCost() + ");";
                    return insertToTable(sqlStatement);
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);

            }
            return false;
        }

        /// <summary>
        /// Saves the user.
        /// </summary>
        /// <returns><c>true</c>, if user was saved, <c>false</c> otherwise.</returns>
        /// <param name="user">User.</param>
        public Boolean saveUser(User user)
        {
            try
            {
                if (getConnection())
                {
                    string sqlStatement = "INSERT INTO USER(user_name,password) VALUES ('" +
                        user.getUsername() + "','" + user.getPassword() + "');";
                    return insertToTable(sqlStatement);
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return false;
        }

        /// <summary>
        /// Saves the user home location.
        /// </summary>
        /// <returns><c>true</c>, if user home location was saved, <c>false</c> otherwise.</returns>
        /// <param name="user">User.</param>
        /// <param name="add">Add.</param>
        public Boolean saveUserHomeLocation(User user, Address add)
        {
            try
            {
                if (getConnection())
                {
                    string sqlStatement = "UPDATE USER SET" + " home_location_lon = " + add.getLongitude() + ", home_location_lat = " + add.getLatitude() +
                        ", home_location_name = '" + add.getLocationName() + "', home_location_area = '" + add.getArea() + "' WHERE user_name = '" + user.getUsername() + "';";
                    return insertToTable(sqlStatement);
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);

            }
            return false;

        }

        /// <summary>
        /// Saves the feedback.
        /// </summary>
        /// <returns><c>true</c>, if feedback was saved, <c>false</c> otherwise.</returns>
        /// <param name="feedback">Feedback.</param>
        public Boolean saveFeedback(Feedback feedback)
        {
            try
            {
                if (getConnection())
                {
                    string sqlStatement = "INSERT INTO FEEDBACK(user_name,message,submit_time) VALUES ('" +
                        feedback.getSubmitter() + "','" + feedback.getMessage() + "'," + feedback.getSubmitTime().Ticks + ");";
                    return insertToTable(sqlStatement);
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return false;
        }

        /// <summary>
        /// Saves the area.
        /// </summary>
        /// <returns><c>true</c>, if area was saved, <c>false</c> otherwise.</returns>
        /// <param name="area">Area.</param>
        /// <param name="riders">Riders.</param>
        /// <param name="expiry">Expiry.</param>
        public Boolean saveArea(string area, int riders, DateTime expiry)
        {
            try
            {
                if (getConnection())
                {
                    string sqlStatement = "INSERT INTO API(area,riders,expiry) VALUES ('" +
                        area + "', " + riders + "," + expiry.Ticks + ");";
                    return insertToTable(sqlStatement);
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return false;

        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <returns>The user.</returns>
        /// <param name="userName">User name.</param>
        public User getUser(string userName)
        {
            try
            {
                if (getConnection())
                {
                    string sql = "SELECT * from USER WHERE user_name = '" + userName + "'";
                    SQLiteDataReader ret = getFromTable(sql);
                    List<User> userList = new List<User>();
                    while (ret.Read())
                    {
                        if (ret["home_location_name"].GetType() != typeof(DBNull))
                        {
                            userList.Add(new User((string)ret["user_name"], (string)ret["password"],
                            new Address((string)ret["home_location_name"], (double)ret["home_location_lon"],
                            (double)ret["home_location_lat"], (string)ret["home_location_area"])));
                        }
                        else
                        {
                            userList.Add(new User((string)ret["user_name"], (string)ret["password"]));
                        }

                    }
                    if (userList.Count == 1)
                    {
                        return userList[0];
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            Debug.WriteLine("Error: Duplicate user in Database!!");
            return null;
        }

        /// <summary>
        /// Gets the calculations of user.
        /// </summary>
        /// <returns>The calculations of user.</returns>
        /// <param name="userName">User Name.</param>
        public List<Calculation> getCalculationsOfUser(string userName)
        {
            List<Calculation> calList = new List<Calculation>();
            try
            {
                if (getConnection())
                {
                    string sql = "SELECT * from CALCULATION WHERE user_name = '" + userName + "'";
                    SQLiteDataReader ret = getFromTable(sql);
                    while (ret.Read())
                    {
                        Address home = new Address((string)ret["home_location_name"], (double)ret["home_location_lon"],
                            (double)ret["home_location_lat"], (string)ret["home_location_area"]);
                        Address work = new Address((string)ret["work_location_name"], (double)ret["work_location_lon"],
                            (double)ret["work_location_lat"], (string)ret["work_location_area"]);
                        Calculation get = new Calculation(work, home, (int)(long)ret["salary"], ((string)ret["commute_type"])[0],
                            (int)(long)ret["job_interest"], (int)(long)ret["salary_satisfaction"], new DateTime((long)ret["created_time"]),
                            (int)(long)ret["median_salary"], (int)(long)ret["riders_area"], (int)(long)ret["ave_riders_area"],
                            (double)ret["commute_time"], (double)ret["ave_commute_time"], (double)ret["monthly_commute_cost"]);
                        calList.Add(get);
                    }
                    return calList;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return calList;
        }

        /// <summary>
        /// Gets the feedback.
        /// </summary>
        /// <returns>The feedback.</returns>
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
                        feedbackList.Add(new Feedback((string)ret["user_name"], (string)ret["message"], new DateTime((long)ret["submit_time"])));
                    }
                    return feedbackList;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }
       
        /// <summary>
        /// Gets the area.
        /// </summary>
        /// <returns>The area.</returns>
        public List<KeyValuePair<string, int>> getArea()
        {
            try
            {
                if (getConnection())
                {
                    string sql = "SELECT * from API";
                    int numOfData = 0;
                    SQLiteDataReader ret = getFromTable(sql);
                    List<KeyValuePair<string, int>> feedbackList = new List<KeyValuePair<string, int>>();
                    while (ret.Read())
                    {
                        if (new DateTime((long)ret["expiry"]).CompareTo(DateTime.Now) < 0)
                        {
                            clearTable("API");
                            return null;
                        }
                        feedbackList.Add(new KeyValuePair<string, int>((string)ret["area"], (int)(long)ret["riders"]));
                        numOfData++;
                    }
                    if (numOfData != 0)
                    {
                        return feedbackList;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        /// <summary>
        /// Inserts to table.
        /// </summary>
        /// <returns><c>true</c>, if to table was inserted, <c>false</c> otherwise.</returns>
        /// <param name="sqlStatement">Sql statement.</param>
        private Boolean insertToTable(string sqlStatement)
        {
            try
            {
                command = new SQLiteCommand(sqlStatement, dbConnection);
                int rowAffected = command.ExecuteNonQuery();
                if (rowAffected == 1)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return false;
        }

        /// <summary>
        /// Clears the table.
        /// </summary>
        /// <returns><c>true</c>, if table was cleared, <c>false</c> otherwise.</returns>
        /// <param name="tableName">Table name.</param>
        private Boolean clearTable(string tableName)
        {
            try
            {
                string sqlStatement = "DELETE * from " + tableName;
                command = new SQLiteCommand(sqlStatement, dbConnection);
                int rowAffected = command.ExecuteNonQuery();
                if (rowAffected <= 0)
                {
                    return false;
                }
            }
            catch (Exception e)
            {

            }

            return true;
        }

        /// <summary>
        /// Execute query statement from database
        /// </summary>
        /// <returns>Queried data.</returns>
        /// <param name="sqlStatement">Sql statement.</param>
        private SQLiteDataReader getFromTable(string sqlStatement)
        {
            try
            {
                command = new SQLiteCommand(sqlStatement, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

    }
}
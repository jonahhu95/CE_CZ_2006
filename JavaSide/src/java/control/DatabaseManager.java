package control;

import java.util.ArrayList;
import java.util.Scanner;

import entity.Address;
import entity.Calculation;

import java.sql.*;

import java.util.ArrayList;
import java.util.Scanner;
import java.sql.*;

/**
 * Created by jonah on 28/9/2017.
 */
public class DatabaseManager {

    private static ArrayList<String> name = new ArrayList<String>();

    //getCalculatedRecord = get past calculated record??
    /**
     *
     * @param username
     * @return
     */
    public Calculation getCalculation(String username, int count) {
        //SELECT score FROM score_t WHERE username='' ORDER BY DESC LIMIT 2
        //or
        //SELECT top 2 score FROM score_t WHERE username='' ORDER BY DESC
        //or
        //SELECT top(2) score FROM score_t WHERE username='' ORDER BY DESC
        ArrayList<Calculation> record = new ArrayList<Calculation>();
        try {
            Connection con = getConnection();
            PreparedStatement got = con.prepareStatement("SELECT top 2 datet,workLocation,workLongitude,workLatitude,workArea,homeLocation,homeLongitude,"
                    + "homeLatitude,homeArea,salary,salarySat,medianSalary,jobInterest,commuteType,ridersArea,AvgRidersArea,commuteTime,AvgCommuteTime,monthCost FROM score_t WHERE username='"
                    + username + "' ORDER BY datet DESC");
            ResultSet result = got.executeQuery();
            while (result.next()) {
                int salary = result.getInt("salary");
                char commuteType = result.getString("commuteType").charAt(0);
                int jobInterest = result.getInt("jobInterest");
                int salarySatisfaction = result.getInt("salarySat");
                long createdTime = (result.getTimestamp("datet")).getTime();
                int medianSalary = result.getInt("medianSalary");
                int ridersArea = result.getInt("ridersArea");
                int aveRidersArea = result.getInt("AvgRidersArea");
                double commuteTime = result.getDouble("commuteTime");
                double aveCommuteTime = result.getDouble("AvgCommuteTime");
                double monthlyCommuteCost = result.getDouble("monthCost");
                Address workLocation = new Address(result.getString("workLocation"), result.getDouble("workLongitude"), result.getDouble("workLatitude"), result.getString("workArea"));
                Address homeLocation = new Address(result.getString("homeLocation"), result.getDouble("homeLongitude"), result.getDouble("homeLatitude"), result.getString("homeArea"));

                Calculation calculation = new Calculation(workLocation, homeLocation, salary, commuteType,
                        jobInterest, salarySatisfaction, createdTime, medianSalary,
                        ridersArea, aveRidersArea, commuteTime, aveCommuteTime,
                        monthlyCommuteCost);

                record.add(calculation);
            }

        } catch (Exception e) {
            System.out.println(e);
        }
        if (count == 1) {
            return record.get(0);
        } else if (count == 2) {
            return record.get(1);
        } else {
            return null;
        }

    }

    /**
     *
     * @param score
     * @param username
     */
    public void storeCalculation(Calculation calculation, String username) {
        try {
            Connection con = getConnection();
            PreparedStatement update = con.prepareStatement("INSERT INTO score_t (username,datet,workLocation,workLongitude,workLatitude,workArea,homeLocation,homeLongitude,"
                    + "homeLatitude,homeArea,salary,salarySat,medianSalary,jobInterest,commuteType,ridersArea,AvgRidersArea,commuteTime,AvgCommuteTime,monthCost) VALUES "
                    + "('" + username + "','" + (new Timestamp(calculation.getCreatedTime())) + "','" + calculation.getWorkLocation().getLocationName() + "','" + calculation.getWorkLocation().getLongitude() + "','"
                    + calculation.getWorkLocation().getLatitude() + "','" + calculation.getWorkLocation().getArea() + "','" + calculation.getHomeLoction().getLocationName() + "','"
                    + calculation.getHomeLoction().getLongitude() + "','" + calculation.getHomeLoction().getLatitude() + "','" + calculation.getHomeLoction().getArea() + "','"
                    + calculation.getSalary() + "','" + calculation.getSalarySatisfaction() + "','" + calculation.getMedianSalary() + "','" + calculation.getJobInterest() + "','" + calculation.getCommuteType() + "','"
                    + calculation.getRidersArea() + "','" + calculation.getAveRidersArea() + "','" + calculation.getCommuteTime() + "','" + calculation.getAveCommuteTime() + "','"
                    + calculation.getMonthlyCommuteCost() + "')");
            update.executeUpdate();
        } catch (Exception e) {
            System.out.println(e);
        }
    }

    /**
     *
     * @param username
     * @param password
     * @return
     */
    public static boolean validateLogin(String username, String password) {
        String pws = null;
        try {
            Connection con = getConnection();
            PreparedStatement got = con.prepareStatement("SELECT pws FROM user_t WHERE username='" + username + "'");
            ResultSet result = got.executeQuery();
            while (result.next()) {
                pws = result.getString("pws");
            }

            if (pws.equals(password)) {
                return true;
            }
        } catch (Exception e) {
            System.out.println(e);
        }
        return false;
    }

    //auto increment is set for primary key(id)
    //assume no duplicate username
    /**
     *
     * @param username
     * @param password
     * @return
     */
    public boolean createAccount(String username, String password) {
        String un = null;
        try {
            Connection con = getConnection();

            //check if username exist in database
            PreparedStatement checkAccount = con.prepareStatement("SELECT username FROM user_t WHERE username='" + username + "'");
            ResultSet result = checkAccount.executeQuery();
            while (result.next()) {
                un = result.getString("username");
            }

            if (un.toString() != null) {
                return false;
            } else {
                PreparedStatement newAccount = con.prepareStatement("INSERT INTO user_t (username,pws) VALUES ('" + username + "','" + password + "')");
                newAccount.executeUpdate();
                name.add(username);
            }
        } catch (Exception e) {
            System.out.println(e);
        }
        return true;
    }

    /**
     *
     * @param username
     * @return
     */
    public boolean deleteAccount(String username) {
        try {
            Connection con = getConnection();
            PreparedStatement delete = con.prepareStatement("DELETE FROM user_t,score_t,optional_t WHERE username='" + username + "'");
            delete.executeUpdate();
        } catch (Exception e) {
            System.out.println(e);
        }
        return true;
    }

    /**
     *
     * @param username
     * @param password
     * @return
     */
    public boolean editAccount(String username, String password) {
        try {
            Connection con = getConnection();
            PreparedStatement change = con.prepareStatement("UPDATE user_t SET pws='" + password + "' WHERE username='" + username + "'");
            change.executeUpdate();
        } catch (Exception e) {
            System.out.println(e);
        }
        return true;
    }

    /**
     *
     * @param username
     * @param feedback
     * @return
     */
    public boolean addFeedback(String username, String feedback) {
        try {
            Connection con = getConnection();
            PreparedStatement comment = con.prepareStatement("INSERT INTO feedback_t (username,feedback) VALUES ('" + username + "','" + feedback + "')");
            comment.executeUpdate();
        } catch (Exception e) {
            System.out.println(e);
        }
        return true;
    }

    /**
     *
     * @return @throws Exception
     */
    public static Connection getConnection() throws Exception {
        //always check whether there is valid access to database
        try {
            String driver = "com.mysql.jdbc.Driver";
            String url = "jdbc:mysql://localhost:3306/job?autoReconnect=true&useSSL=false";
            String username = "root";
            String password = "joey";
            Class.forName(driver);

            Connection con = DriverManager.getConnection(url, username, password);
            System.out.println("Connected");
            return con;
        } catch (Exception e) {
            System.out.println(e);
        }

        return null;
    }

    /**
     *
     * @param username
     * @return
     * @throws Exception
     */
    public static String getPassword(String username) throws Exception {
        String name = null;
        try {
            Connection con = getConnection();
            PreparedStatement got = con.prepareStatement("SELECT pws FROM user_t WHERE username='" + username + "'");
            ResultSet result = got.executeQuery();
            while (result.next()) {
                name = result.getString("pws");
            }
            System.out.println(name);
        } catch (Exception e) {
            System.out.println(e);
        } finally {
            System.out.println("Gotten username");
        }
        return name;
    }

    /**
     *
     * @param username
     * @param pws
     * @throws Exception
     */
    public static void post(String username, String pws) throws Exception {
        try {
            Connection con = getConnection();
            PreparedStatement posted = con.prepareStatement("INSERT INTO user_t (id,username,pws) VALUES ('1','" + username + "','" + pws + "')");
            posted.executeUpdate();
        } catch (Exception e) {
            System.out.println(e);
        }
        //finally {System.out.println("Insert completed");}
    }

    //for testing case only
    /**
     *
     * @param arg
     * @throws Exception
     */
    public static void main(String arg[]) throws Exception {

        Scanner in = new Scanner(System.in);
        System.out.println("Username?");
        String u = in.next();
        System.out.println("Password?");
        String p = in.next();
        getConnection();
//        post(u, p);
//        getPassword(u);
        boolean t = validateLogin(u, p);
        System.out.println(t);
        in.close();

    }
}

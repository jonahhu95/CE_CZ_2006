package Controls;

import java.sql.*;

/**
 * Created by jonah on 28/9/2017.
 */
public class DatabaseManager {
    
    public DatabaseManager(){}
    
    public int getCalculatedRecord(String username){
        return 0;
    }
    public void storeCalculationResult(int score, String username){
        
    }
    public boolean validateLogin(String username, String password){
        return true;
    }
    public boolean createAccount(String username, String password){
        return true;
    }
    public static Connection getConnection() throws Exception{
    	try {
    		String driver= "com.mysql.jdbc.Driver";
    		String url="jdbc:mysql://localhost:3306/job?autoReconnect=true&useSSL=false";
    		String username="root";
    		String password="041100";
    		Class.forName(driver);
    		
    		Connection con=DriverManager.getConnection(url,username,password);
    		System.out.println("Connected");
    		return con;
    	}catch(Exception e) {System.out.println(e);}
    	
    	return null;
    }
    
  /*  testing purpose
    public static void createTable() throws Exception{
    	try {
    		Connection con=getConnection();
    		PreparedStatement create=con.prepareStatement("CREATE TABLE IF NOT EXISTS user_T(id INT NOT NULL,username	VARCHAR(40)	NOT NULL,pws				VARCHAR(20)	NOT NULL,\n" + 
    				"PRIMARY KEY (id)");
    		create.executeUpdate();
    	}catch(Exception e) {System.out.println(e);}
    	finally {System.out.println("Function has been completed");}
    }
    */
    public static String getPassword(String username) throws Exception{
    		String name=null;
    		try {
    			Connection con=getConnection();
    			PreparedStatement got=con.prepareStatement("SELECT pws FROM user_t WHERE username='"+username+"'");
    			ResultSet result=got.executeQuery();
    			while(result.next()) {
    			name=result.getString("pws");
    			}
    			System.out.println(name);
    		}catch(Exception e) {System.out.println(e);}
    		finally {System.out.println("Gotten username");}
    		return name;
    }
    
    public static void post(String username, String pws) throws Exception{	
    	try {
    		Connection con=getConnection();
    		PreparedStatement posted=con.prepareStatement("INSERT INTO user_t (id,username,pws) VALUES ('1','"+username+"','"+pws+"')");
    		posted.executeUpdate();
    	}catch(Exception e) {System.out.println(e);}
    	finally {System.out.println("Insert completed");}
    }
    
    public static void main(String arg[]) throws Exception {
    	String u="one";
    	String p="two";
    getConnection();
    	post(u,p);
    	getPassword(u);
    }
}

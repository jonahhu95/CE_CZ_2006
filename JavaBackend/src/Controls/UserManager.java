package Controls;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.ArrayList;

import Entities.User;

/**
 * Created by jonah on 28/9/2017.
 */
public class UserManager {
	private static ArrayList<String> UserList= new ArrayList<String>();

	public boolean createUser() {
		//prompt for input
		String username=null;
		String password=null;
		//
		for(int i=0;i<UserList.size();i++) {
			if(username==UserList.get(i))
				return false;
		}
		DatabaseManager valid=new DatabaseManager();
		boolean result= valid.createAccount(username, password);
		return result;
	}
	
	
	 public static Connection getConnection() throws Exception{
	    	//always check whether there is valid access to database
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
}

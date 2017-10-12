package control;
import java.util.ArrayList;
import java.util.Scanner;
import java.sql.*;

/**
 * Created by jonah on 28/9/2017.
 */
public class DatabaseManager {
    
	private static ArrayList<String> name= new ArrayList<String>();
    
    //getCalculatedRecord = get past calculated record??
	public int getCalculatedRecord(String username){ 
        	int score=-1;
        	//-1 condition if the user don't have past record
    		//create table to store all the scores
    		//username and datetime as primary key
    		//sql statement to compare overall score
    		//SELECT score FROM score_t WHERE username='' ORDER BY DESC LIMIT 2
    		//or
    		//SELECT top 2 score FROM score_t WHERE username='' ORDER BY DESC
    		//or
		//SELECT top(2) score FROM score_t WHERE username='' ORDER BY DESC
    		ArrayList<Integer> mark=new ArrayList<Integer>();
    		try {
    			Connection con=getConnection();
    			PreparedStatement got=con.prepareStatement("SELECT top 2 score FROM score_t WHERE username='"+username+"' ORDER BY DESC");
    			ResultSet result=got.executeQuery();
    			while(result.next()) {
    			mark.add(result.getInt("score"));
    			}
    			//assumption made such that new calculation record will be appended before retrieve past calculated record
    			//the second record is the one that we are looking for
    			score=mark.get(1);
    		}catch(Exception e) {System.out.println(e);}
    		return score;
    }
	
	
    public void storeCalculationResult(int score, String username){
    	try {
    		Connection con=getConnection();
    		PreparedStatement update=con.prepareStatement("INSERT INTO score_t (username,score) VALUES ('"+username+"','"+score+"')");
    		update.executeUpdate();
    	}catch(Exception e) {System.out.println(e);}
    }
    
    
    public static boolean validateLogin(String username, String password){
    		String pws=null;
		try {
			Connection con=getConnection();
			PreparedStatement got=con.prepareStatement("SELECT username, pws FROM user_t WHERE username='"+username+"'");
			ResultSet result=got.executeQuery();
			while(result.next()) {
			pws=result.getString("pws");
			}
			if(pws==password)
				return true;
		}catch(Exception e) {System.out.println(e);}
        return false;
    }
    
    public boolean createAccount(String username, String password){
    		//auto increment is set for primary key(id)
    		//check for duplicate username 
    		for(int i=0;i<name.size();i++) {
    			if(username==name.get(i))
    				return false;
    		}
    		
    	try {
    		Connection con=getConnection();
    		PreparedStatement newAccount=con.prepareStatement("INSERT INTO user_t (username,pws) VALUES ('"+username+"','"+password+"')");
    		newAccount.executeUpdate();
    		name.add(username);
    	}catch(Exception e) {System.out.println(e);}
    	return true;
    }
    public static Connection getConnection() throws Exception{
    	//always check whether there is valid access to database
    	try {
    		String driver= "com.mysql.jdbc.Driver";
    		String url="jdbc:mysql://localhost:3306/job?autoReconnect=true&useSSL=false";
    		String username="root";
    		String password="joey";
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
    	//finally {System.out.println("Insert completed");}
    }
    
    
    //for testing case only
    public static void main(String arg[]) throws Exception {
    
    	Scanner in=new Scanner(System.in);
    System.out.println("Username?");
    	String u=in.next();
    	System.out.println("Password?");
    	String p=in.next();
    getConnection();
    	post(u,p);
    	getPassword(u);
    	in.close();
        
    }
}

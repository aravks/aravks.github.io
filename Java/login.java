import javax.swing.*;
import java.awt.*;
import java.sql.*;
import java.awt.event.*;

class login extends Frame
{
	login()
	{
		JFrame f=new JFrame();
		JLabel l=new JLabel("ADMIN LOGIN");

 		f.setLayout(new FlowLayout());
 		f.setSize(300,300);
 		f.setVisible(true);

 		f.add(l);
    	
	}
	public static void main(String[] args) 
	{
		new login();
	}
}
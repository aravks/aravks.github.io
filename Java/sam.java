import javax.swing.*;
import java.awt.*;
import java.sql.*;
import java.awt.event.*;

class sam
{
	JFrame f= new JFrame();
	JLabel l1;
	sam()
	{

	f.setSize(1000,800);
	f.setVisible(true);
	f.setLayout(null);
	f.setContentPane(new JLabel(new ImageIcon("D:/firstblog/bank6.jpg")));
	f.setBackground(Color.BLACK);

	JLabel l = new JLabel("THANK YOU FOR BEING A PART OF OUR BANK ! ! !");
	l.setBounds(790,430,1000,20);

	f.add(l);
	}
	public static void main(String ar[])
	{
		new sam();
	}
	
	
}
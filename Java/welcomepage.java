import javax.swing.*;
import java.awt.*;
import java.sql.*;
import java.awt.event.*;

class welcomepage implements ActionListener
{
		JFrame f1=new JFrame("Welcome");
		JLabel l=new JLabel("WELCOME TO MITTECH BANK OF INDIA");
		JButton b1=new JButton("New Customer Registration");
		JButton b2=new JButton("Loan Section");
		JButton b3=new JButton("Customer Details");

	welcomepage()
	{

 		f1.setLayout(null);
 		f1.setSize(1000,800);
 		f1.setVisible(true);
 		f1.setContentPane(new JLabel(new ImageIcon("D:/firstblog/bank4.jpg")));
 		f1.setBackground(Color.BLACK);



 		l.setBounds(690,250,300,30);
 		b1.setBounds(640,350,300,30);
 		b2.setBounds(640,400,300,30);
 		b3.setBounds(640,450,300,30);

 		f1.add(l);
 		f1.add(b1);
 		f1.add(b2);
 		f1.add(b3);
 		b1.addActionListener(this);
 		b2.addActionListener(this);
 		b3.addActionListener(this);
    	
	}
	public static void main(String[] args) 
	{
		new welcomepage();
	}
	public void actionPerformed(ActionEvent a)
	{
		if(a.getSource()==b1)
		{
				new register();
				f1.dispose();
		}
		if(a.getSource()==b3)
		{
				 new detail();
				f1.dispose();
		}	
		if(a.getSource()==b2)
		{
				new loan();
				f1.dispose(); 
		}	
	}	
}
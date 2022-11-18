import javax.swing.*;
import java.awt.*;
import java.sql.*;
import java.awt.event.*;
class register implements ActionListener
{
	JButton buttonaccept;
	JButton buttondelete;
	JButton buttonupdate;
	JButton buttonclear;
	JButton buttonclose;
	JButton buttonback;
	JFrame frame;
	JPanel panel;
	JLabel labelhead;
	JLabel labelacctname;
	JLabel labelacctno;
	JLabel labelaccttype;
	JLabel labeldate;
	JLabel labeladdress;
	JLabel labelphone;
	JLabel labelemail;
	JTextField textacctname;
	JTextField textacctno;
	JTextField textaccttype;
	JTextField textdate;
	JTextField textaddress;
	JTextField textphone;
	JTextField textemail;
	public register()
	{

		panel=new JPanel();
		panel.setLayout(null);
		frame=new JFrame("New Customer Registration");
		frame.setSize(1000,800);
		frame.setVisible(true);
		frame.getContentPane().add(panel);
		panel.setBackground(Color.LIGHT_GRAY);
		


		labelhead=new JLabel("REGISTRATION FORM");
		labelacctname=new JLabel("ACCOUNT NAME");
		labelacctno=new JLabel("ACCOUNT NUMBER");	
		labelaccttype=new JLabel("ACCOUNT TYPE");
		labeldate=new JLabel("DATE OPENED");
		labeladdress=new JLabel("ADDRESS");
		labelphone=new JLabel("PHONE NUMBER");
		labelemail=new JLabel("EMAIL");
		textacctname=new JTextField(20);
		textacctno=new JTextField(20);
		textaccttype=new JTextField(30);
		textdate=new JTextField(30);
		textaddress=new JTextField(30);
		textphone=new JTextField(30);
		textemail=new JTextField(30);
		panel.add(labelhead);
		panel.add(labelacctname);
		panel.add(textacctname);
		panel.add(labelacctno);
		panel.add(textacctno);
		panel.add(labelaccttype);
		panel.add(textaccttype);
		panel.add(labeldate);
		panel.add(textdate);
		panel.add(labeladdress);
		panel.add(textaddress);
		panel.add(labelphone);
		panel.add(textphone);
		panel.add(labelemail);
		panel.add(textemail);

		buttonaccept=new JButton("Add");
		panel.add(buttonaccept);
		buttonaccept.addActionListener(this);

		buttondelete=new JButton("Delete");
		panel.add(buttondelete);
		buttondelete.addActionListener(this);

		buttonupdate=new JButton("Update");
		panel.add(buttonupdate);
		buttonupdate.addActionListener(this);

		buttonclear=new JButton("Clear");
		panel.add(buttonclear);
		buttonclear.addActionListener(this);

		buttonclose=new JButton("Close");
		panel.add(buttonclose);
		buttonclose.addActionListener(this);

		buttonback=new JButton("Back");
		panel.add(buttonback);
		buttonback.addActionListener(this);


		labelhead.setBounds(690,70,120,10);
		labelacctname.setBounds(570,150,120,20);
		textacctname.setBounds(840,150,120,20);
		labelacctno.setBounds(570,200,120,20);
		textacctno.setBounds(840,200,120,20);
		labelaccttype.setBounds(570,250,120,20);
		textaccttype.setBounds(840,250,120,20);
		labeldate.setBounds(570,300,120,20);
		textdate.setBounds(840,300,120,20);
		labeladdress.setBounds(570,350,120,20);
		textaddress.setBounds(840,350,120,20);
		labelphone.setBounds(570,400,120,20);
		textphone.setBounds(840,400,120,20);
		labelemail.setBounds(570,450,120,20);
		textemail.setBounds(840,450,120,20);

		buttonaccept.setBounds(270,550,120,20);
		buttondelete.setBounds(470,550,120,20);
		buttonupdate.setBounds(670,550,120,20);
		buttonclear.setBounds(870,550,120,20);
		buttonclose.setBounds(1070,550,120,20);
		buttonback.setBounds(1270,550,120,20);
	}
	public static void main(String ar[])
	{
		new register();
	}
	public void actionPerformed(ActionEvent ae)
	{
		if(ae.getSource()==buttonaccept)
		{
			try
			{
				Class.forName("com.mysql.jdbc.Driver").newInstance();
				Connection c=DriverManager.getConnection("jdbc:mysql://localhost/college","root","root");
				PreparedStatement stat2=c.prepareStatement("insert into student (acctname,acctno,accttype,date,adddress,phone,email)values(?,?,?,?,?,?,?)");

				stat2.setString(1,textacctname.getText());
				stat2.setString(2,textacctno.getText());
				stat2.setString(3,textaccttype.getText());
				stat2.setString(4,textdate.getText());
				stat2.setString(5,textaddress.getText());
				stat2.setString(6,textphone.getText());
				stat2.setString(7,textemail.getText());
				stat2.executeUpdate();
				JOptionPane.showMessageDialog(frame,new String("U'r details have been registered"));

			}
			catch(Exception e)
			{
				JOptionPane.showMessageDialog(frame,new String("error encountered"+e));	
			}
		}
		if(ae.getSource()==buttonclear)
		{
			textacctname.setText("");
			textacctno.setText("");
			textaccttype.setText("");
			textdate.setText("");
			textaddress.setText("");
			textphone.setText("");
			textemail.setText("");
		}
		if(ae.getSource()==buttonclose)
		{
			new sam();
			frame.dispose();
		}
		if(ae.getSource()==buttondelete)
		{
			try
			{
				Class.forName("com.mysql.jdbc.Driver").newInstance();
				Connection c=DriverManager.getConnection("jdbc:mysql://localhost/college","root","root");
				PreparedStatement stat2=c.prepareStatement("delete from student where acctname='"+textacctname.getText()+"'");

				stat2.executeUpdate();
				JOptionPane.showMessageDialog(frame,new String("U'r details have been deleted"));
			}
			catch(Exception e)
			{
				JOptionPane.showMessageDialog(frame,new String("error encountered"+e));	
			}
		}
		if(ae.getSource()==buttonupdate)
		{
			try
			{
				Class.forName("com.mysql.jdbc.Driver").newInstance();
				Connection c=DriverManager.getConnection("jdbc:mysql://localhost/college","root","root");
				PreparedStatement stat2=c.prepareStatement("update student Set acctno='"+textacctno.getText()+"',accttype='"+textaccttype.getText()+"',date='"+textdate.getText()+"',address='"+textaddress.getText()+"',phone='"+textphone.getText()+"',email='"+textemail.getText()+"'");

				stat2.executeUpdate();
				JOptionPane.showMessageDialog(frame,new String("U'r details have been updated"));	
			}
			catch(Exception e)
			{
				JOptionPane.showMessageDialog(frame,new String("error encountered"+e));
			}
		}		
		if(ae.getSource()==buttonback)
		{
			new welto();
			frame.dispose();
		}

	}
	
}
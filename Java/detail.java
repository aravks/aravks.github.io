import javax.swing.*;
import java.awt.*;
import java.sql.*;
import java.awt.event.*;
class detail implements ActionListener
{
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
	JLabel textacctname;
	JLabel textacctno;
	JLabel textaccttype;
	JLabel textdate;
	JLabel textaddress;
	JLabel textphone;
	JLabel textemail;

	public detail()
	{

		panel=new JPanel();
		panel.setLayout(null);
		frame=new JFrame("Customer Details");
		frame.setSize(1000,800);
		frame.setVisible(true);
		frame.getContentPane().add(panel);
		panel.setBackground(Color.LIGHT_GRAY);
		


		labelhead=new JLabel("CUSTOMER DETAILS");
		labelacctname=new JLabel("ACCOUNT NAME");
		labelacctno=new JLabel("ACCOUNT NUMBER");	
		labelaccttype=new JLabel("ACCOUNT TYPE");
		labeldate=new JLabel("DATE OPENED");
		labeladdress=new JLabel("ADDRESS");
		labelphone=new JLabel("PHONE NUMBER");
		labelemail=new JLabel("EMAIL");
		textacctname=new JLabel("Admin");
		textacctno=new JLabel("17MIT0910");
		textaccttype=new JLabel("EDUCATIONAL");
		textdate=new JLabel("29 DEC 2018");
		textaddress=new JLabel("20,YYY STREET,MAIN ROAD,PUDUCHERRY,605 001");
		textphone=new JLabel("985-788-4358");
		textemail=new JLabel("Admin@gmail.com");
		buttonback=new JButton("Back");

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
		textaddress.setBounds(840,350,290,20);
		labelphone.setBounds(570,400,120,20);
		textphone.setBounds(840,400,120,20);
		labelemail.setBounds(570,450,120,20);
		textemail.setBounds(840,450,120,20);
		buttonback.setBounds(870,550,120,20);

	}

	public static void main(String ar[])
	{
		new detail();
	}
	public void actionPerformed(ActionEvent ae)
	{
		if(ae.getSource()==buttonback)
		{
			new welto();
			frame.dispose();
		}
	}
}
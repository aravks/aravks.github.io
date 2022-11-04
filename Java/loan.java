import javax.swing.*;
import java.awt.*;
import java.sql.*;
import java.awt.event.*;

class loan implements ActionListener
{
	JFrame f;
	JLabel l,l1,l2,l3;
	JTextField t;
	JButton b,b1;
	Choice ch;
	loan()
	{
		f=new JFrame("Loan section");
		l=new JLabel("LOAN SECTION");
		l1=new JLabel("Choose the type of loan"); 
		b=new JButton("Back");
		b1=new JButton("Submit");
		ch=new Choice();
		ch.add("Home");
		ch.add("Educational");
		ch.add("Personal");
		l2=new JLabel("Enter the amount");
		t=new JTextField(20);

		f.setLayout(null);
		f.setVisible(true);
		f.setSize(1000,1000);
		f.setContentPane(new JLabel(new ImageIcon("D:/firstblog/bank14.jpg")));
		f.setBackground(Color.LIGHT_GRAY);


		l.setBounds(690,250,300,30);
		l1.setBounds(580,300,200,30);
		ch.setBounds(780,300,200,30);
		l2.setBounds(580,350,200,30);
		t.setBounds(780,350,200,20);
		b1.setBounds(760,400,100,20);
		b.setBounds(910,400,100,20);

		b.addActionListener(this);

		f.add(l);
		f.add(l1);
		f.add(ch);
		f.add(l2);
		f.add(t);
		f.add(b1);
		f.add(b);


		}
	     public static void main(String ar[])
		{
				new loan();
		}
		public void actionPerformed(ActionEvent ae)
		{
			if(ae.getSource()==b)
			{
				new welto();
				f.dispose();
			}
		}

}
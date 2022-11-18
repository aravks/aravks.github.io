import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
class login implements ActionListener
{
	JLabel title,head,l1,l2,i;
	JTextField t1,t2;
	JButton b1;
	JFrame f;
	login()
	{
		f=new JFrame();
		f.setVisible(true);
		f.setSize(1000,800);
		f.setLayout(null);
		f.setContentPane(new JLabel(new ImageIcon("D:/firstblog/bank2.jpg")));
		f.setBackground(Color.BLACK);


		title=new JLabel("MITTECH BANK OF INDIA");
		head=new JLabel("ADMIN LOGIN");
		l1=new JLabel("Username");
		l2=new JLabel("Password");
		t1=new JTextField(20);
		t2=new JTextField(20);
		b1=new JButton("LOGIN");
		title.setBounds(1120,250,200,30);
		head.setBounds(1150,290,200,30);
		l1.setBounds(1050,340,200,30);
		l2.setBounds(1050,390,200,30);
		t1.setBounds(1180,340,200,30);
		t2.setBounds(1180,390,200,30);
		b1.setBounds(1150,490,100,30);
		f.add(title);
		f.add(head);
		f.add(l1);
		f.add(l2);
		f.add(t1);
		f.add(t2);
		f.add(b1);
		b1.addActionListener(this);
	}
	public static void main(String ar[])
	{
		new login();
	}
	public void actionPerformed(ActionEvent a)
	{
		if(a.getSource()==b1)
		{
			String str="";
			String str1="";
			str = t1.getText();
			str1 = t2.getText();
			if(str.equals("Admin")&&str1.equals("12345"))
			{
				new welcomepage();
				f.dispose();
			} 
		}
	}

}
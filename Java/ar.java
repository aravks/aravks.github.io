import java.awt.*;
import java.awt.event.*;
class my implements ActionListener
{
	Label head,l1,l2,l3;
	TextField t1,t2,t3;
	Button b1;
	Frame f;
	my()
	{
		f=new Frame();
		f.setVisible(true);
		f.setSize(500,500);
		f.setLayout(null);
		head=new Label("MY FRAME");
		l1=new Label("value1");
		l2=new Label("value2");
		l3=new Label("add");
		t1=new TextField(20);
		t2=new TextField(20);
		t3=new TextField(20);
		b1=new Button("Find");
		head.setBounds(300,50,100,30);
		l1.setBounds(200,100,100,30);
		l2.setBounds(200,150,100,30);
		l3.setBounds(200,200,100,30);
		t1.setBounds(330,100,100,30);
		t2.setBounds(330,150,100,30);
		t3.setBounds(330,250,100,30);
		b1.setBounds(300,250,100,30);
		f.add(head);
		f.add(l1);
		f.add(l2);
		f.add(l3);
		f.add(t1);
		f.add(t2);
		f.add(t3);
		f.add(b1);
		b1.addActionListener(this); 
	}
	public void actionPerformed(ActionEvent a)
	{
		if(a.getSource()==b1)
		{
			int n=Integer.parseInt(t1.getText());
			int n1=Integer.parseInt(t2.getText());
			int r=n+n1;
			t3.setText(""+r);
		}
	}
	public static void main(String ar[])
	{
		new my();
	}

}
import java.awt.*;
class sample extends Frame
{
	sample()
	{
		Frame f=new Frame();
		Label l=new Label("Name");
		TextField t=new TextField();
		Button b=new Button("click");
		f.setLayout(new FlowLayout());
		f.setVisible(true);
		f.setSize(100,100);
		l.setBounds(100,100,80,50);
		t.setBounds(150,100,80,50);
		t.setBounds(200,200,80,50);
		f.add(l);
		f.add(t);
		f.add(b);
	}
	public static void main(String ar[])
	{
		sample ob=new sample();
	}
}
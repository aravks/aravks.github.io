import java.awt.*;
class sample extends Frame
{
	Frame f;
	Label l;
	TextField t;
	Button b;
	Checkbox c1,c2,c3,c4;
	CheckboxGroup cg;
	List li;
	Choice ch;
	sample()
	{
		f=new Frame();
		l=new Label("name");
		t=new TextField();
		b=new Button("click");
		c1=new Checkbox("java");
		c2=new Checkbox("c++");
		c3=new Checkbox("male",false,cg);
		c4=new Checkbox ("female",false,cg);
		ch=new Choice();
		ch.add("CSE");
		ch.add("IT");
		ch.add("EEE");
		li=new List(4,false);
		li.add("CHENNAI");
		li.add("MADURAI");
		li.add("PUDUCHERRY");
		li.add("SELAM");
		li.add("KARAIKAL");
		f.setLayout(new FlowLayout());
		f.setVisible(true);
		f.setSize(1000,1000);
		f.add(l);
		f.add(b);
		f.add(ch);
		f.add(c1);
		f.add(c2);
		f.add(c3);
		f.add(c4);
		f.add(li);
		}
	     public static void main(String ar[])
		{
				sample ob=new sample();
		}
		
}
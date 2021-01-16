using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OW[] country =
            {
               new OW("Великобритания",67808573,244820,2625,"Евразия","Монархия","Первый мир",0.922),
               new OW("США", 333336805,9519431,19391,"Северная Америка","Республика","Первый мир",0.924),
               new OW("Япония",126220000,377385,4872,"Евразия","Монархия","Первый мир", 0.852),
               new OW("Россия",146781095,17125191,1578,"Евразия","Республика", "Первый мир",0.852),
               new OW("Германия",83213591,357021,3685,"Евразия","Республика","Первый мир",0.936),
               new OW("Иран",82990192,1648000,377,"Евразия","Республика","Третий мир",0.798),
               new OW("Франция",68859599,547030,2584,"Евразия","Республика","Первый мир",0.901),
               new OW("Австралия", 25339000, 7686850,1380,"Австралия","Монархия","Первый мир",0.929),
               new OW("КНДР",28490965,120540, 17,"Евразия", "Республика","Второй мир",0.766),
               new OW("Куба",11658566,110860,96,"Северная Америка","Республика","Второй мир",0.777),
               new OW("Сомали",3864937,637657,1.37,"Африка","Республика","Второй мир",0.284),
               new OW("Эфиопия",98665000,1127127,72.5,"Африка","Республика","Второй мир",0.463),
               new OW("ОАЭ",9541615,82880,371,"Африка","Монархия","Первый мир",0.863),
               new OW("Китай",1395961000,9598962,12015,"Евразия","Республика","Второй мир",0.816),
               new OW("Турция",79463663,780580,857,"Евразия","Республика","Первый мир",0.791),
               new OW("Бразилия",209768490,8514877,2055,"Южная Америка","Республика","Третий мир",0.759),
               new OW("Индия",1360238000,3287263,2611,"Евразия","Республика","Третий мир",0.624),
			   new OW("Колумбия",48400388,1141748,427,"Южная Америка","Республика","Первый мир",0.719),
			   new OW("Мьянма",52885223,678500,74.53,"Южная Америка","Республика","Третий мир",0.498),
			   new OW("Саудовская Аравия",33000000, 2149690,173,"Африка","Монархия","Третий мир",0.853),
			   new OW("Канада", 36048521, 9984670,151,"Северная Америка","Монархия","Первый мир",0.926),
			   new OW("Шри-Ланка",21675648, 65610, 82,"Евразия", "Республика","Третий мир",0.715),
			   new OW("Руанда",12012589,26338,9.1,"Африка","Республика","Третий мир",0.498),
			   new OW("Новая Зеландия",4894100,268680,150,"Австралия","Монархия","Первый мир",0.917),
			   new OW("Мадагаскар",24823539,587041,10,"Африка","Республика","Третий мир",0.512),
			   new OW("Италия",59589445,301340,183,"Евразия","Республика","Первый мир",0.872),
			   new OW("Республика Корея",51732586,997202,145,"Евразия","Республика","Третий мир",0.903),
			   new OW("Ватикан",1000,1,0,"Евразия","Монархия","Первый мир",0),
			   new OW("Ямайка",2930050,10991,14,"Южная Америка","Монархия","Третий мир",0.730),
			   new OW("Гаити",9893934,27750,12,"Северная Америка","Республика","Третий мир",0.496),

			};
            
            double[] WWP1 = { 371, 72.5, 1.37, 96, 17, 1380, 2584, 2625, 4872,12015, 1578, 19391, 2611, 2055, 3685 , 377, 857 };
            string[] world = { "Первый мир", "Второй мир", "Третий мир" };//массив для группировки Мир
             var nok = "";
            switch (comboBox1.SelectedIndex)
            {
                case 0: nok = "Евразия"; break;
                case 1: nok = "Северная Америка"; break;
                case 2: nok = "Южная Америка"; break;
                case 3: nok = "Африка"; break;
                case 4: nok = "Австралия"; break;
                
            }
            if (comboBox2.SelectedIndex == 0) //запрос 1, простой, выбор Мира
            {
                textBox2.Text = string.Empty;
                if (comboBox3.SelectedIndex == -1)
                { MessageBox.Show("ВЫБЕРИТЕ МИР"); return; }
                textBox1.Text = string.Empty;
                string worldnum = " ";
                switch (comboBox3.SelectedIndex)
                {
                    case 0: worldnum = "Первый мир"; break;
                    case 1: worldnum = "Второй мир"; break;
                    case 2: worldnum = "Третий мир"; break;
                }
                var wn = from w in country
                         where w.World == worldnum
                         select w.CountryName + " - это " + w.World ;
                foreach (var i in wn) { textBox1.Text += (i) + Environment.NewLine; }
            }
            else if (comboBox2.SelectedIndex == 1)//запрос 2 с несколькими условиями (Максимальное население и Континент)
            {
                if (comboBox1.SelectedIndex == -1 && !checkBox1.Checked)
                { MessageBox.Show("ВЫБЕРИТЕ КОНТИНЕНТ"); return; }
                string pop1 = textBox2.Text;
                if (textBox2.Text == String.Empty)
                { MessageBox.Show("Введите максимальное население"); return; }
                int pop = int.Parse(pop1);
                textBox1.Text = string.Empty;
                var numpop = from p in country
                             where p.Population < pop && p.Region.StartsWith(nok, StringComparison.Ordinal)
                             select p.CountryName + " на континенте " + p.Region + " имеет население " + p.Population;
                foreach (var i in numpop) { textBox1.Text += (i) + Environment.NewLine; }
                if (checkBox1.Checked)
                {
                    pop = int.Parse(pop1);
                    textBox1.Text = string.Empty;
                    numpop = from p in country
                             where p.Population < pop
                             select p.CountryName + " на континенте " + p.Region + " имеет население " + p.Population;
                    foreach (var i in numpop) { textBox1.Text += (i) + Environment.NewLine; }
                }
            }
            else if (comboBox2.SelectedIndex == 2)//запрос 3, многоуровневая сортировка запроса 2 по убыванию населения
            {
                if (comboBox1.SelectedIndex == -1)
                { MessageBox.Show("ВЫБЕРИТЕ КОНТИНЕНТ"); return; }
                string pop1 = textBox2.Text;
                if (textBox2.Text == String.Empty)
                { MessageBox.Show("Введите максимальное население"); return; }
                int pop = int.Parse(pop1);
                textBox1.Text = string.Empty;
                var numpop = from p in country
                             where p.Population < pop && p.Region.StartsWith(nok, StringComparison.Ordinal)
                             orderby p.Population descending
                             select p.CountryName + " на континенте " + p.Region + " имеет население " + p.Population;
                foreach (var i in numpop) { textBox1.Text += (i) + Environment.NewLine; }
                if (checkBox1.Checked)
                {
                    pop = int.Parse(pop1);
                    textBox1.Text = string.Empty;
                    numpop = from p in country
                             where p.Population < pop
                             orderby p.Population descending
                             select p.CountryName + " на континенте " + p.Region + " имеет население " + p.Population;
                    foreach (var i in numpop) { textBox1.Text += (i) + Environment.NewLine; }
                }
            }
            else if (comboBox2.SelectedIndex == 3)// запрос 4, анонимные типы, группировка по Миру
            {
                textBox2.Text = string.Empty;
                textBox1.Text = string.Empty;//чистит текстобокс
                var x = from n in world
                        join m in country
                        on n equals m.World
                        into nm
                        select new { world = n, NM = nm };
                foreach (var i in x)
                {
                    textBox1.Text += ("Страна категории " + i.world + ":") + Environment.NewLine;
                    foreach (var i1 in i.NM) { textBox1.Text += (" " + i1.CountryName) + Environment.NewLine; }
                    textBox1.Text += (" ") + Environment.NewLine;
                }
            }
            else if (comboBox2.SelectedIndex == 4)//запрос 5 группировка
            {
                if (comboBox4.SelectedIndex == -1)//ловит на ошибке, если не было выбрано направление
                {
                    MessageBox.Show("ВЫБЕРИТЕ ФОРМУ ПРАВЛЕНИЯ");
                    return;
                }
                var fpg = "";
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                switch (comboBox4.SelectedIndex)//группировка по названию дисциплины
                {
                    case 0: fpg = "Монархия"; break;
                    case 1: fpg = "Республика"; break;
                }
                var t = from n in country
                        where n.For.LastIndexOf(fpg) != -1
                        group  fpg + " "+n.CountryName +" с площадью " + n.Square + " км^2" by n.For.Substring(n.For.LastIndexOf(fpg));
                foreach (var i in t)
                {
                    textBox1.Text += ("Форма правления " + fpg + " существует в странах:") + Environment.NewLine;
                    foreach (var ii in i) { textBox1.Text += (ii) + Environment.NewLine; }
                }

            }
            else if (comboBox2.SelectedIndex == 5)//запрос 6 метод расширения
            {
                try
                {
                    int zz = Convert.ToInt32(textBox2.Text);
                    textBox1.Text = string.Empty;
					textBox1.Text = "Наименший ВВП - 0 (млрд) в стране Ватикан."+ Environment.NewLine+"Страны, ВВП которых больше Ватикана на "+textBox2.Text+" млдр: "+ Environment.NewLine+ Environment.NewLine;
					var x = from n in country
                            let z = WWP1.Min()
                            where n.WWP < (z + zz)
                            select n.CountryName;
                    foreach (var i in x) { textBox1.Text += (i) + Environment.NewLine; }
                }
                catch { MessageBox.Show("Введите ВВП"); }
            }
            else//не был выбран запрос
            {
                MessageBox.Show("Выберите интересующий вас запрос"); return;
            }
            comboBox1.Text = "Континент";
            comboBox3.Text = "Мир";
            comboBox4.Text = "Форма правления";
        }
    


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                    e.Handled = true;
                if (textBox2.Text.Length == 0)//
                    if (e.KeyChar == '0') e.Handled = true;//запрещает писать 0 первым числом
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {            
          if ( e.KeyChar != 8)
              e.Handled = true;                
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
            if (textBox2.Text.Length == 0)//
                if (e.KeyChar == '0') e.Handled = true;//запрещает писать 0 первым числом

        }

		private void label9_Click(object sender, EventArgs e)
		{

		}
	}


	public abstract class FormaP:CN
    {
        public string For; //форма правления
        
        public FormaP(string cn, int p, int s, double wwp,string r, string f): base(cn,p,s,wwp,r)
        {
            For = f;
        }
        public FormaP() { }

    }
    
    
    public class OW:FormaP
    {
        
        public double ICHR; //Индекс Человеческого Развития
        public string World;// мир
        public OW(string cn, int p, int s, double wwp, string r,string f, string w, double ic) : base(cn, p, s, wwp,r,f)
        {
            
            World = w;
            ICHR = ic;
        }
        public OW() { }
    }
    
        public class CN
        {
            public string CountryName; // название страны
            public int Population; // население
            public int Square;// площадь                     
            public double WWP;//ввп
            public string Region; // континент
            public CN(string cn, int p, int s, double wwp, string r) 
            {
                CountryName = cn;
                Population = p;
                Square = s;                             
                WWP = wwp;
            Region = r;
            }
        public CN() { }
        }
    }


    


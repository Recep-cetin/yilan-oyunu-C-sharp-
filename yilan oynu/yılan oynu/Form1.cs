using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yılan_oynu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*burada bşta keydown yapmadaan once butonlarla yonlendırıyorduk
         * private void button3_Click(object sender, EventArgs e)
          {
              yon = "sol";
          }

          private void button4_Click(object sender, EventArgs e)
          {
              yon = "sag ";
          }

          private void button5_Click(object sender, EventArgs e)
          {
              yon = "yukarı ";
          }

          private void button6_Click(object sender, EventArgs e)
          {
              yon = "asagı";
          }
          private void button1_Click(object sender, EventArgs e)
          {

          }*/
        
        //burada degişkenlerimizzin her fongüde ve privaye de calışabilmesi için globl ypıyoruz
       
        string yon = "sag";//burada oyun başladıgındda otomatık olarak bır yone gitmesi için sol tarafı gostertık
        Random konum = new Random();//burada yem'in (label2) yeinini belirlemek iö,in random kulanık
        int yilanx, yilany, yemx, yemy, yilanx1, yilany1, yemx1, yemy1;
        //yukarıda tanıtıgımız degişkenler yılan ve yemın hem portl uzerındekı yerlerını ve kendi buyukluklerı tanımlamak ıcın kuladık
        Boolean sart1, sart2;//burada şart kştuk herhagi birinin çalışması için
        int puan = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {  //burada girilen degere gor yılanımızı(label1) yolendırmek ıcın kurlanık
            if (yon == "sol") label1.Left -= 5;
            else if (yon == "asagı") label1.Top += 5;
            else if (yon == "sag") label1.Left += 5;
            else if (yon == "yukarı") label1.Top -= 5;

            //burada tanıtıgımız degşkenlerle lınanın bir yere carptıgında oyunu bitirmesini istiyoruz
            if (label1.Left + label2.Width >= this.Width && yon == "sag")//saga gidiyorsa
                Bitir();
            else if (label1.Left <= 0 && yon == "sol")//yılanın 0 ın altındakı degerlerde çalımasını engeler
                Bitir();
            else if (label1.Top + label2.Height >= this.Height && yon == "asagı")//asagı gidiyorsa
                Bitir();
            else if (label1.Top <= 0 && yon == "yukarı")
                Bitir();

            //*burada tanıtıgımız degişkenlerimizin neyeler karşılık geldigini gösteriyoruz

            yilanx = label1.Location.X + label1.Width;//burada yilan x in x katmanındakı degersel buyuklugunu tanımlıyoruz
            yilany = label1.Location.Y + label1.Height;//burada yilan y nin y katmanındakı degersel buyuklugunu tanımlıyoruz

            yemx = label2.Location.X + label2.Width;//buradada yukarıa belıtıgımız gıbı yemın x ve y uzerındekı
            yemy = label2.Location.Y + label2.Height;//degersel buyuklugunu tanımlıyoruz

            yilanx1 = label1.Location.X;//burada yılanın(label1) kendı konumunu tanıtıyoruz 
            yilany1 = label1.Location.Y;

            yemx1 = label2.Location.X;//burada yemin (label2) kendı konumunu tanıtıyoruz 
            yemy1 = label2.Location.Y;

            //buradaki şartlar labelerin ust uste geldiginde algılanabilmesi için gerekenleri soyluyor
            sart1 = yilanx >= yemx1 && yilanx <= yemx && yilany >= yemy1 && yilany <= yemy;

            sart2 = yilanx1 >= yemx1 && yilanx1 <= yemx && yilany1 >= yemy1 && yilany1 <= yemy;



            //buada yukarıdakı şarlardan herhangi brinin çalışması yani
            //lablelerın denk gelmesı sonucu ne yapması gerektıgını soyluyor
            if (sart1 || sart2)
            {
                puan = puan + 1;
                this.Text = "puanı :" + puan.ToString();//burada bitir class ı calıtgında yazılacak
                                                        //komutu(this.Text)tanımlıyor
                label2.Left = konum.Next(0, 270);//buradakı komutlar lyemın(label2) nın yılan tarafında
                label2.Top = konum.Next(0, 270);//yenıldıkten sonra erede canlanacagını goterıyor

                if (timer1.Interval > 5) timer1.Interval = timer1.Interval - 5;//burada yılanın kac px şaklinde ilerleyeecegi aktarıl mış
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;//buradakı kot butonlardan calıştırdıgımız
                                  //zaman proframı acmaya yarıyordu
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {  //buradakı kotlar keydowndan acıldıgı ıcın pogram sızın
           //bastıgınız yukaı asagı tuları algılyabılıyor
            byte tus;
            tus = (byte)e.KeyCode;
            if (tus == 37 || tus == 38 || tus == 39 || tus == 40)//nurada tusların ascii kodları var
                timer1.Enabled = true;
            else if (tus == 27) timer1.Enabled = false;//burada esc tusuna basınca oyun sayacını durduryor
            if (tus == 37) yon = "sol";
            else if (tus == 38) yon = "yukarı";
            else if (tus == 39) yon = "sag";
            else if (tus == 40) yon = "asagı";
        }

        private void Bitir()
        {
            timer1.Enabled = false;//burada oyun bitir kısmına geldiginde yazılacak b-ve ounacak bılgılerı gonderır
            MessageBox.Show("Oyun biti punanınız ::" + puan.ToString());
        }
    }


}

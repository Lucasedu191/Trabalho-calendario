using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabalhoCalendáriov1
{
    public partial class FormFeriados : Form
    {
        public FormFeriados()
        {
            InitializeComponent();
        }
        private int Ano = 0;


        //calculo para saber se o ano é Bissexto tendo como base o leapyear na forma boleana
        private bool AnoBissesto(int Ano)
        {
            bool leapYear = false;
            leapYear = (((Ano % 4) == 0) && ((Ano % 100) != 0) || ((Ano % 400) == 0));
            if (leapYear.Equals(true))
                 return true;

            else
                return false;
        }
        private int[] GeraTabelaMeses(int Ano)
        {
            //calculo de meses, após realizar o array com os dias dos meses, tem um if que identifica se ele for bissesto ele adiciona o numero 29 na posição dois do array
            int[] Meses = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (AnoBissesto(Ano) == true)
            {
                Meses[1] = 29;
            }
            return Meses;
        }   
        private int[] GeraTabelaOrdinais(int Ano)
        {            
    //realizar array de int com 12 posiçoes para calculo dos dias e realiza a conta dos dias dos meses diminuindo uma posição por causa do zero
            int[] ordinal=new int[12]; 
            int[] meses= GeraTabelaMeses(Ano);
            int a = 0;
            ordinal[0] = 0;
            for (int i = 1; i <12; i++)
             {
                a=a + meses[i-1];
                ordinal[i] = a;
             }
            return ordinal;
        }
        // ele transforma a data para um numero que forma uma data para ordinal
        private int DataparaOrdinal(int Ano, int mes, int dia)
        {
            int[] ordinal =GeraTabelaOrdinais(Ano);
            
            return ordinal[mes-1]+dia;
        }
        //faz o calculo do numero de dias no ano e transforma em uma data ex: 170 para 20/05
         private DateTime OrdinalParaData(int DiaOrdinal, int Ano)
         {
            int[] ordinal = GeraTabelaOrdinais(Ano);
            int[] meses = GeraTabelaMeses(Ano);
            int dia = 0; 
            int  i;
            for ( i = 0; i < 12; i++)
            {
                if (ordinal[i+1] >= DiaOrdinal)
                {
                    dia = DiaOrdinal - ordinal[i];
                    
                    
                    break;
                }

            }
            return new DateTime( Ano, i+1, dia);
        }
        private DateTime Pascoa(double Ano)
        {
            //Calcular o dia que vai cair a pascoa(usar math floor)
            double a, b, c, d, e, f, g, h, i, k, l, m, p, q;
                a = (Ano % 19);
                b = Math.Floor(Ano / 100);
                c = (Ano % 100);
                d = Math.Floor(b / 4);
                e = (b % 4);
                f = Math.Floor((b + 8) / 25);
                g = Math.Floor(1 + b - f) / 3; 
                h = ((19 * a +b + 15 - (d + g)) % 30);
                i = Math.Floor(c / 4);
                k = (c % 4);
                l = (((32 + 2 * e + 2 * i - (h + k))) % 7);
                m = Math.Floor((a + (11 * h) + (22 * l)) / 451);
                p = Math.Floor((h + l - (7 * m) + 114) / 31);
                q = ((h + l - (7 * m) + 114) % 31) +1;
            DateTime pascoa = new DateTime(Convert.ToInt16(Ano), 
                                            Convert.ToInt16(p), 
                                            Convert.ToInt16(q));
            return pascoa;
        }
        //faz o calculo do dia da semana de acordo com o resultado da formula abaixo
         private string DiaDaSemana (double Ano, double mes, double dia)
         {
            double a = 0, b, c, d, e, f, g, h, i, r;
            string[] DiaDaSemana = new string[] { "Sábado", "Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta" };
            a = Math.Floor((12.0 - mes) / 10);
            b = Ano -  a;
            c = mes + (12 * a);
            d = Math.Floor(b / 100);
            e = Math.Floor(d / 4);
            f = e + 2 - d;
            g = Math.Floor(365.25 * b);
            h = Math.Floor(30.6001 * (c + 1));
            i = f + g + h + dia + 5;
            r = i % 7;

            return DiaDaSemana[Convert.ToInt16(r)];

         }
        private void ButtonCalcular_Click(object sender, EventArgs e)
        {
            //erro se pesquisar ano menor que 1587
            richTextBoxFeriados.Clear();
            Ano = Convert.ToInt16(maskedTextBoxAno.Text);
            int[] chamaordinal = GeraTabelaOrdinais(Ano);
            DateTime pascoa = Pascoa(Ano);
            if (Ano < 1587)
            {
                MessageBox.Show("Não é permitido antes do 1587.", "Erro");
            }
            // faz o print na tela do feriados
            int Pascoa2 = DataparaOrdinal(pascoa.Year, pascoa.Month, pascoa.Day);
            richTextBoxFeriados.AppendText("Pascoa: " + DiaDaSemana(pascoa.Year, pascoa.Month, pascoa.Day) + " " + pascoa.ToShortDateString() + Environment.NewLine);

            //com base na pascoa é feito o calculo diminuindo ou aumentando dias. 
            int SextaFeiraSantaOrdinal = DataparaOrdinal(pascoa.Year, pascoa.Month, pascoa.Day) - 2;
            DateTime SextafeiraSanta = OrdinalParaData(SextaFeiraSantaOrdinal, Ano);
            richTextBoxFeriados.AppendText("Sexta-feira Santa: " + DiaDaSemana(SextafeiraSanta.Year, SextafeiraSanta.Month, SextafeiraSanta.Day) + " " + SextafeiraSanta.ToShortDateString() + Environment.NewLine);

            int CorpusChristi= DataparaOrdinal(pascoa.Year, pascoa.Month, pascoa.Day) + 60;
            DateTime CorpusC = OrdinalParaData(CorpusChristi, Ano);
            richTextBoxFeriados.AppendText("CorpusChristi: " + DiaDaSemana(CorpusC.Year, CorpusC.Month, CorpusC.Day) + " " + CorpusC.ToShortDateString() + Environment.NewLine);

            int Carnaval = DataparaOrdinal(pascoa.Year, pascoa.Month, pascoa.Day) - 47;
            DateTime Carna = OrdinalParaData(Carnaval, Ano);
            richTextBoxFeriados.AppendText("Carnaval: " + DiaDaSemana(Carna.Year, Carna.Month, Carna.Day) + " " + Carna.ToShortDateString() + Environment.NewLine);


            richTextBoxFeriados.AppendText("Confraternização Universal: " + DiaDaSemana(Ano, 01, 01) + " " + new DateTime(Ano, 01, 01).ToShortDateString() + Environment.NewLine);

            richTextBoxFeriados.AppendText("Tiradentes: " + DiaDaSemana(Ano, 04, 21) + " " + new DateTime(Ano, 04, 21).ToShortDateString() + Environment.NewLine);

            richTextBoxFeriados.AppendText("Independencia: " + DiaDaSemana(Ano, 09, 07)  + " " + new DateTime(Ano, 09, 07).ToShortDateString() + Environment.NewLine);

            richTextBoxFeriados.AppendText("Dia do Trabalhador: " + DiaDaSemana(Ano, 05, 01)  + " " + new DateTime(Ano, 05, 01).ToShortDateString() + Environment.NewLine);

            richTextBoxFeriados.AppendText("Finados: " + DiaDaSemana(Ano, 11, 02) + " " + new DateTime(Ano, 11, 02).ToShortDateString() + Environment.NewLine);

            richTextBoxFeriados.AppendText("Proclamação da republica: " + DiaDaSemana(Ano, 11, 15) + " " + new DateTime(Ano, 11, 15 ).ToShortDateString() + Environment.NewLine);

            richTextBoxFeriados.AppendText("Natal: " + DiaDaSemana(Ano, 12, 25) + " " + new DateTime(Ano, 12, 25).ToShortDateString() + Environment.NewLine);

        }

    }
}

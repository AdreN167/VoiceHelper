using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Speech.Recognition;
using Microsoft.Speech.Recognition;



namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        static TextBox textBox = new TextBox();

        public Form1()
        {
            InitializeComponent();

        }

        static void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence > 0.82) textBox.Text = e.Result.Text;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            textBox = textBox1;
            try
            {
                System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ru-ru");
                SpeechRecognitionEngine sre = new SpeechRecognitionEngine(ci);
                sre.SetInputToDefaultAudioDevice();

                sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);


                Choices numbers = new Choices();
                numbers.Add(new string[] { "один", "два", "три", "четыре", "пять" });


                GrammarBuilder gb = new GrammarBuilder();
                gb.Culture = ci;
                gb.Append(numbers);


                Grammar g = new Grammar(gb);
                sre.LoadGrammar(g);

                sre.RecognizeAsync(RecognizeMode.Multiple);
            }catch(Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Speech.Recognition;
using VoiceHelper.Forms;
using VoiceHelper.Data;
using VoiceHelper.Models;


namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        static string command = ""; // строка с командой

        static void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence > 0.7) // коэф совпадения сказанного 0.7 от оригинала
            {
                command = e.Result.Text; // запись скзанного в переменную с командой
            }
            newForm form = new newForm();
            switch (command) // обработчик команд
            {
                // список команд 
                case "Открой новую форму": 
                    {
                        form.Show();
                    }
                    break;
                case "com2":
                    {

                    }
                    break;
                case "com3":
                    {

                    }
                    break;
                case "com4":
                    {

                    }
                    break;
                case "com5":
                    {

                    }
                    break;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ru-ru"); // Создание обработчика языка (русская версия)
            SpeechRecognitionEngine sre = new SpeechRecognitionEngine(ci);
            sre.SetInputToDefaultAudioDevice(); // использование средства ввода по умолчанию

            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized); // создание события распознавания речи

            Choices numbers = new Choices();
            numbers.Add(new string[] { "Открой новую форму", "com2", "com3", "com4", "com5" }); // список команд введенных голосом

            // грамматика
            // ---------------------
            GrammarBuilder gb = new GrammarBuilder();
            gb.Culture = ci;
            gb.Append(numbers);

            Grammar g = new Grammar(gb);
            sre.LoadGrammar(g);
            // ---------------------

            sre.RecognizeAsync(RecognizeMode.Multiple); // множественное - multiple распознавание текста
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new RequestContext())
            {
                context.Add(new WriteRequest { Message = "Hello, world!", Path = "A.txt" });
                context.SaveChanges();
            }
        }
    }
}

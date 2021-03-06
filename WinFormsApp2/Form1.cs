using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Speech.Recognition;
using VoiceHelper.Data;
using VoiceHelper.Models;
using VoiceHelper.Services;


namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        static string command = ""; // строка с командой
        static Service service = new Service();
        bool isWork = true;

        public void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence > 0.85) // коэф совпадения сказанного 0.7 от оригинала
            {
                command = e.Result.Text; // запись скзанного в переменную с командой
            }
            command.ToLower();
            if (isWork)
            {
                label_Status.Text = "Ева работает!";
            }
            else
            {
                label_Status.Text = "Ева спит!";

            }
            switch (command) // обработчик команд
            {
                // список команд 
                case "ева, перезапиши в файл":
                    {
                        if (isWork)
                        {
                            service.ReWriteInFile(textBox1, saveFileDialog1);
                        }
                    }
                    break;
                case "ева, добавь в файл":
                    {
                        if (isWork)
                        {
                            service.AddToFile(textBox1, saveFileDialog1);
                        }
                    }
                    break;
                case "ева, врубись":
                case "ева, привет":
                case "ева, появись":
                case "ева, привызваю тебя":
                    {
                        isWork = true;
                    }
                    break;
                case "ева, открой оперу":
                    {
                        if (isWork)
                        {
                            Process.Start("C:\\Users\\andre\\AppData\\Local\\Programs\\Opera GX\\launcher.exe");
                        }
                    }
                    break;
                case "command4":
                    {
                        if (isWork)
                        {
                            
                        }
                    }
                    break;
                case "ева плохая уйди":
                case "ева, андрей сказал тебе иди нахуй!":
                case "ева, андрей сказал тебе иди в попу!":
                    {
                        isWork = false;
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

            Choices commands = new Choices();
            commands.Add(new string[] {
                "ева, перезапиши в файл", "ева, добавь в файл",
                "ева плохая уйди", "ева, андрей сказал тебе иди нахуй!", "ева, андрей сказал тебе иди в попу!",
                "ева, врубись", "ева, появись", "ева, привызваю тебя",
                "ева, открой оперу"
            }); // список команд введенных голосом

            // грамматика
            // ---------------------
            GrammarBuilder gb = new GrammarBuilder();
            gb.Culture = ci;
            gb.Append(commands);

            Grammar g = new Grammar(gb);
            sre.LoadGrammar(g);
            // ---------------------

            sre.RecognizeAsync(RecognizeMode.Multiple); // множественное - multiple распознавание текста
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new RequestContext())
            {
                label1.Text = "";

                var requests = context.writeRequests;
                foreach (var request in requests)
                {
                    label1.Text += request.Message + " " + request.Path + " \n";
                }
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            if (isWork)
            {
                label_Status.Text = "Ева работает!";
            }
            else
            {
                label_Status.Text = "Ева спит!";

            }
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            using (var context = new RequestContext())
            {
                context.RemoveRange(context.writeRequests);
                context.SaveChanges();
            }
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var context = new RequestContext())
            {
                label1.Text = "";

                var requests = context.writeRequests;
                foreach (var request in requests)
                {
                    label1.Text += request.Message + " " + request.Path + " \n";
                }
            }
        }
    }
}

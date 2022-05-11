using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;


namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine speechEngine;
        public Form1()
        {
            InitializeComponent();

            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("ru-ru"); /* Язык распознования */
            speechEngine = new SpeechRecognitionEngine(culture);
            speechEngine.LoadGrammar(new DictationGrammar()); // Dictation mode.
            speechEngine.SetInputToDefaultAudioDevice();

            speechEngine.SpeechRecognized += SpeechEngine_SpeechRecognized; /* Событие завершения распознования текста */

            Choices choices = new Choices(); /* Выбор распознования (комманды) */
            choices.Add(new string[] { "Открой", "файл", "test" });

            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append(choices);
            Grammar grammar = new Grammar(grammarBuilder);
            speechEngine.LoadGrammar(grammar);

            speechEngine.SpeechRecognized += (sender, args) =>
            {
                // Ваш обработчик.
                MessageBox.Show(string.Join(", ", args.Result.Words));
            };
        }


        private void SpeechEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            MessageBox.Show(e.Result.Text);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}

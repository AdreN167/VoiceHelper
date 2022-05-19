using System;
using System.Windows.Forms;
using VoiceHelper.Data;
using VoiceHelper.Models;

namespace VoiceHelper.Forms
{
    public partial class newForm : Form
    {
        public newForm()
        {
            InitializeComponent();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    using (var context = new RequestContext())
        //    {
        //        context.Add(new WriteRequest { Message = "Hello, world!", Path = "A.txt" });
        //        context.SaveChanges();
        //    }
        //} я проебал кнопку, поэтому закомментил это событие :)

        private void newForm_Load(object sender, EventArgs e)
        {

        }
    }
}

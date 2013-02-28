// http://ashishkhandelwal.arkutil.com/design-patterns-technical/quick-and-short-mediator-pattern/

using System;
using System.Windows.Forms;

namespace MediaPattern
{
    public partial class Form1 : Form
    {
        Mediator mediator = new Mediator();

        public Form1()
        {
            InitializeComponent();
            mediator.RegisterSearch(button1);
            mediator.RegisterView(button2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mediator.Search();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mediator.View();
        }
    }
}

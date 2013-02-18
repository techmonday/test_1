using System;
using System.Drawing;
using System.Windows.Forms;

namespace MvpAppConsole
{
    /// <summary>
    /// Presenter as middle man, handle application logic
    /// 
    ///     View                Presenter             Model
    ///      |------------------>|                      |
    ///      | 1. user trigger   |                      |
    ///      |                   |--------------------->|
    ///      |                   | 2.  LoadData         |
    ///      |                   |                      |
    ///      |                   |                      |
    ///      |                   |                      |
    ///      |                   |<---------------------|
    ///      |                   | 3.  return Data      |
    ///      |                   |                      |
    ///      |<------------------|                      |
    ///      | 4  update GUI     |                      |
    ///      
    /// </summary>
    public class SamplePresenter
    {
        ISampleModel model;
        ISampleView view;

        public SamplePresenter(ISampleView _view) 
        {
            view = _view;
            model = new SampleModel();
        }

        public void LoadCustomerData(string customerId)
        {
            view.CustomerName = model.LoadData(customerId);
        }
    }


    public interface ISampleModel
    {
        string LoadData(string id);
    }


    /// <summary>
    /// SampleModel handles bussiness logic
    /// </summary>
    public class SampleModel : ISampleModel
    {
        public string LoadData(string id)
        {
            return "hello";            
        }
    }


    /// <summary>
    /// ISampleView map to GUI control
    /// </summary>
    public interface ISampleView
    {
        string Id { get; set; }
        string CustomerName { get; set; }
    }


    /// <summary>
    /// Gui Form
    /// For Mocking Test Please read 
    ///  http://coding.infoconex.com/post/(MVP)-Model-View-Presenter-Passive-View.aspx
    /// </summary>
    public class SampleView : Form, ISampleView
    {
        public string Id { get; set; }
        public string CustomerName { get { throw new NotImplementedException(); } set { txtBoxName.Text = value; } }

        SamplePresenter presenter;

        TextBox txtBoxId, txtBoxName;
        Button btnSearch;


        public SampleView()
        {
            InitComponent();
            presenter = new SamplePresenter(this);
        }

        public void InitComponent()
        {
            txtBoxId = new TextBox { Text = "", Size = new Size(150, 30), Location = new Point(40, 30) };
            btnSearch = new Button { Text = "Search", Size = new Size(150, 30), Location = new Point(40, 80) };
            txtBoxName = new TextBox { Text = "", Size = new Size(150, 30), Location = new Point(40, 130) };

            this.Controls.Add(txtBoxId);
            this.Controls.Add(btnSearch);
            this.Controls.Add(txtBoxName);

            btnSearch.Click += btnSearch_Click;
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            presenter.LoadCustomerData(Id);
        }
    }


    public class Program
    {
        [STAThread]
        static void Main()
        {
            Application.Run(new SampleView());
        }
    }
}

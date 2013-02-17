using System;
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
            view.Name = model.LoadData(customerId);
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
        string Name { get; set; }
    }


    /// <summary>
    /// Gui Form
    /// </summary>
    public class SampleView : Form, ISampleView
    {
        //declare Button, TextBox for Id, Name

        public string Id { get; set; }
        public string Name { get; set; }

        SamplePresenter presenter;

        public SampleView()
        {
            //create ui
            //bind  Button to button1_Click
            presenter = new SamplePresenter(this);
        }

        private void button1_Click(object sender, EventArgs e)
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

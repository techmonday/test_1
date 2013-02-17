using System;
using System.Windows.Forms;

namespace MVP
{
    public partial class Form1 : Form, ICustomerView
    {
        CustomerViewPresenter custumerViewPresenter;
        
        public Form1()
        {
            InitializeComponent();
            custumerViewPresenter = new CustomerViewPresenter(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            custumerViewPresenter.LoadCustomer();
        }

        #region ICustomerView Members
        public string CustomerIdInput
        {
            get
            {
                return _CustomerIdInput.Text;
            }
            set
            {
                throw new NotImplementedException();                
            }
        }

        public string CustomerName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                _CustomerName.Text = value;
            }
        }    
        #endregion

    }
}

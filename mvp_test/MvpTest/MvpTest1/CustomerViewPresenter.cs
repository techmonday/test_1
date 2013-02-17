
namespace MVP
{
    class CustomerViewPresenter
    {
        ICustomerView customerView;
        CustomerData data;
        
        public CustomerViewPresenter(ICustomerView customerView) :this(customerView, new CustomerData())
        {
        }

        public CustomerViewPresenter(ICustomerView view, CustomerData customerData)
        {
            customerView = view;
            data = customerData;
        }


        public void LoadCustomer()
        {
            // Business Logic
            string name = data.ReadData(customerView.CustomerIdInput).CustomerName;

            // update gui
            customerView.CustomerName = name;
        }
    }
}

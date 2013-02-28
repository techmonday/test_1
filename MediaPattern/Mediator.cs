using System.Windows.Forms;

namespace MediaPattern
{
    //Col
    public interface IMediator
    {
        void View();
        void Search();
        void RegisterView(Button v);
        void RegisterSearch(Button s);
    }


    //Concrete mediator
    public class Mediator : IMediator {
 
        Button btnView;
        Button btnSearch;
 
        public void RegisterView(Button v) 
        {
            btnView = v;
        }
 
        public void RegisterSearch(Button s) 
        {
            btnSearch = s;
        }
  
        public void View() 
        {
            btnView.Enabled = false;
            btnSearch.Enabled = true;
            //show.setText("viewing...");
        }
 
        public void Search() 
        {
            btnSearch.Enabled = false;
            btnView.Enabled = true;
            //show.setText("searching...");
        }
    }
}

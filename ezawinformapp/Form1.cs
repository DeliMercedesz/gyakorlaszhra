using ezawinformapp.BookModels;

namespace ezawinformapp
{
    public partial class Form1 : Form
    {
        FunnyDatabaseContext context = new FunnyDatabaseContext();
        public Form1()
        {
            InitializeComponent();

            var lista = (from x in context.Books
                        select x).ToList();

            bookBindingSource.DataSource = lista;
        }
    }
}

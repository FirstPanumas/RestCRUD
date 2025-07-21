namespace RestCRUD
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CustomerDetail), typeof(CustomerDetail));
        }
    }
}

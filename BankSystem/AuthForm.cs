namespace BankSystem
{
    public partial class AuthForm : Form
    {
        private BankSystemContext context;

        public AuthForm()
        {
            InitializeComponent();
            context = new BankSystemContext();
        }

        public bool Auth(string email, string password)
        {
            User? user = context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
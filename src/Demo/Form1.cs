using Demo.Services;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        private readonly UserServices _userServices;

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(UserServices userServices)
        {
            _userServices = userServices;
            InitializeComponent();
        }


        private async void Form1_Load(object sender, System.EventArgs e)
        {
            var users = await _userServices.GetAllUsers();


            MessageBox.Show($"Quantidade de itens de usuario {users.Count}");

        }
    }
}

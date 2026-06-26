using ShoesProject.Models;

namespace ShoesProject
{
    public partial class FormMenu : Form
    {

        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }
        public FormMenu(User user, bool guest)
        {
            InitializeComponent();

            CurrentUser = user;
            IsGuest = guest;

            lblUserName.Text = IsGuest ? "Гость" : CurrentUser.FullName;
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            FormProducts formProducts = new FormProducts(CurrentUser, IsGuest, this);
            formProducts.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (IsGuest == true)
            {
                MessageBox.Show("Необходимо быть авторизованным!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                FormOrders formOrders = new FormOrders(CurrentUser, this);
                formOrders.Show();
            }
        }

        private void btnLogut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoLib;
using DemoLib.Models.Clients;

namespace SimpleDemoWin
{
    public partial class ClientOrdersForm : Form
    {
        private Client client_;
        private MySQLClientsModel model_;
        public ClientOrdersForm(Client client, MySQLClientsModel model)
        {
            InitializeComponent();
            client_ = client;
            model_ = model;
        }

        private void ClientOrdersForm_Load(object sender, EventArgs e)
        {
            OrdersTable.DataSource = null;
            OrdersTable.DataSource = client_.order.GetRecords();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OrderAddForm orderAddForm = new OrderAddForm();
            DialogResult result = orderAddForm.ShowDialog();
            if (result == DialogResult.OK)
            {

            }
        }
    }
}

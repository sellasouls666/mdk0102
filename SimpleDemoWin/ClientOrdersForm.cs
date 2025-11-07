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
        List<OrderRecord> orders_;
        public ClientOrdersForm(Client client, MySQLClientsModel model)
        {
            InitializeComponent();
            client_ = client;
            model_ = model;
        }

        private void ClientOrdersForm_Load(object sender, EventArgs e)
        {
            RefreshOrdersTable();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OrderAddForm orderAddForm = new OrderAddForm();
            DialogResult result = orderAddForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                model_.AddOrder(orderAddForm.GetNewRecord(), client_.ID);
                client_.order.AddRecord(orderAddForm.GetNewRecord());
                RefreshOrdersTable();

            }
        }

        private void RefreshOrdersTable()
        {
            OrdersTable.DataSource = null;
            orders_ = client_.order.GetRecords();
            OrdersTable.DataSource = orders_;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }
    }
}

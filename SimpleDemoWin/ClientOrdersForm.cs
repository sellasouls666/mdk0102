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
            this.Text = "Заказы клиента " + client_.Name;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OrderAddForm orderAddForm = new OrderAddForm();
            orderAddForm.Text = "Добавление заказа клиента " + client_.Name;
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
            if (OrdersTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ для удаления", "Информация",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = OrdersTable.SelectedRows[0];

            OrderRecord order = selectedRow.DataBoundItem as OrderRecord;
            if (order == null)
            {
                MessageBox.Show("Не удалось получить данные заказа", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Вы уверены, что хотите удалить заказ?\nАртикул: {order.NameProduct}",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                try
                {
                    model_.DeleteOrder(order);
                    client_.order.RemoveRecord(order);
                    RefreshOrdersTable();

                    MessageBox.Show("Заказ успешно удален", "Успех",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении заказа: {ex.Message}", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

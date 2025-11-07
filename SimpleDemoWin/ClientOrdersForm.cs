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
                MessageBox.Show("Выберите заказы для удаления", "Информация",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<OrderRecord> selectedOrders = new List<OrderRecord>();

            foreach (DataGridViewRow row in OrdersTable.SelectedRows)
            {
                OrderRecord order = row.DataBoundItem as OrderRecord;
                if (order != null)
                {
                    selectedOrders.Add(order);
                }
            }

            if (selectedOrders.Count == 0)
            {
                MessageBox.Show("Не удалось получить данные заказов", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string message;
            if (selectedOrders.Count == 1)
            {
                message = $"Вы уверены, что хотите удалить заказ?\nАртикул: {selectedOrders[0].NameProduct}";
            }
            else
            {
                message = $"Вы уверены, что хотите удалить {selectedOrders.Count} заказов?\n\n";
                message += "Выбранные заказы:\n";
                foreach (var order in selectedOrders.Take(5)) // Показываем первые 5 для краткости
                {
                    message += $"- {order.NameProduct}\n";
                }
                if (selectedOrders.Count > 5)
                {
                    message += $"- ... и еще {selectedOrders.Count - 5} заказов\n";
                }
            }

            DialogResult result = MessageBox.Show(
                message,
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int successCount = 0;
                    foreach (var order in selectedOrders)
                    {
                        try
                        {
                            model_.DeleteOrder(order);
                            client_.order.RemoveRecord(order);
                            successCount++;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при удалении заказа {order.NameProduct}: {ex.Message}");
                        }
                    }

                    RefreshOrdersTable();

                    string resultMessage = successCount == selectedOrders.Count
                        ? $"Успешно удалено {successCount} заказов"
                        : $"Удалено {successCount} из {selectedOrders.Count} заказов. Некоторые заказы не были удалены.";

                    MessageBox.Show(resultMessage, "Результат удаления",
                                    MessageBoxButtons.OK,
                                    successCount == selectedOrders.Count ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении заказов: {ex.Message}", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            List<OrderRecord> sortedOrders = orders_.OrderByDescending(order => order.Count).ToList();

            OrdersTable.DataSource = null;
            OrdersTable.DataSource = sortedOrders;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            RefreshOrdersTable();
        }
    }
}

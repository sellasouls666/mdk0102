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

namespace SimpleDemoWin
{
    public partial class OrderAddForm : Form
    {
        private OrderRecord newRecord_;
        public OrderAddForm()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameBox.Text))
            {
                MessageBox.Show("Поле 'Имя' не может быть пустым!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                nameBox.Focus();
                return;
            }

            newRecord_ = new OrderRecord();
            newRecord_.NameProduct = nameBox.Text;
            newRecord_.Price = (double)priceBox.Value;
            newRecord_.Count = (int)countBox.Value;
            newRecord_.SaleDate = DateTime.Now;
            
            DialogResult = DialogResult.OK;
        }

        public OrderRecord GetNewRecord()
        {
            return newRecord_;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OrderAddForm_Load(object sender, EventArgs e)
        {
        }
    }
}

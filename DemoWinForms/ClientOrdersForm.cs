using DemoLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoProject
{
    public partial class ClientOrdersForm: Form
    {
        private User currentUser_ = null;
        public ClientOrdersForm(User user)
        {
            InitializeComponent();
            currentUser_ = user;
        }

        private bool isMiddleRoleUser()
        {
            return currentUser_.Role == UserRole.Manager;
        }

        public void SetOrder(Order order)
        {
            /// Д.З. Сделать масштабирование колонок таблицы по размеру окна
            /// Добавить строку Итого
            /// По цене: средняя цена, по стоимости - общая сумма, остальные - прочерки
            OrdersTable.DataSource = null;
            OrdersTable.DataSource = order.GetRecords();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
            if (isMiddleRoleUser())
            {
                MessageBox.Show("У Вас не хватает прав, чтобы добавлять заказ.\n" +
                                "Обратитесь, пожалуйста, к администратору",
                                "Сообщение",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
         
            if (isMiddleRoleUser())
            {
                MessageBox.Show("У Вас не хватает прав, чтобы удалить заказ.\n" +
                                "Обратитесь, пожалуйста, к администратору",
                                "Сообщение",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }
    }
}

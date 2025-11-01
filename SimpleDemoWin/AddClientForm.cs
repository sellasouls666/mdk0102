using DemoLib.Presenters;
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
using DemoLib.Models.Clients;

namespace SimpleDemoWin
{
    public partial class AddClientForm : Form
    {
        private Client newClient_;
        private string selectedImagePath_;
        private MySQLClientsModel model_;

        public AddClientForm(MySQLClientsModel model)
        {
            InitializeComponent();
            model_ = model;
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

            if (string.IsNullOrWhiteSpace(desBox.Text))
            {
                MessageBox.Show("Поле 'Описание' не может быть пустым!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                desBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(phoneBox.Text))
            {
                MessageBox.Show("Поле 'Телефон' не может быть пустым!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                phoneBox.Focus();
                return;
            }

            string phone = phoneBox.Text.Trim();
            if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^[\d\s\-\+\(\)]+$"))
            {
                MessageBox.Show("Некорректный формат телефона!\nТелефон должен содержать только цифры и символы: - + ( )",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                phoneBox.Focus();
                phoneBox.SelectAll();
                return;
            }

            if (string.IsNullOrWhiteSpace(mailBox.Text))
            {
                MessageBox.Show("Поле 'Email' не может быть пустым!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                mailBox.Focus();
                return;
            }

            string email = mailBox.Text.Trim();
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Некорректный формат email!\nПример: example@mail.ru",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mailBox.Focus();
                mailBox.SelectAll();
                return;
            }

            if (string.IsNullOrEmpty(selectedImagePath_))
            {
                MessageBox.Show("Необходимо выбрать изображение клиента!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                imageBtn.Focus();
                return;
            }

            Client addClient = new Client(model_.GenerateNextID());
            addClient.Name = nameBox.Text;
            addClient.Description = desBox.Text;
            addClient.Phone = phoneBox.Text;
            addClient.Mail = mailBox.Text;
            addClient.ImagePath = selectedImagePath_;
            newClient_ = (Client)addClient;
            DialogResult = DialogResult.OK;
        }

        private void imageBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Выберите изображение клиента";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = openFileDialog.FileName;

                    selectedImagePath_ = imagePath;

                    MessageBox.Show($"Выбрано изображение: {imagePath}", "Успех",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public Client GetNewClient()
        {
            return newClient_;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}


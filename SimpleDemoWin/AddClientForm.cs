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
using System.IO;

namespace SimpleDemoWin
{
    public partial class AddClientForm : Form
    {
        private Client newClient_;
        private string selectedImagePath_;
        private MySQLClientsModel model_;
        private int type_;

        public AddClientForm(MySQLClientsModel model, int type, Client client)
        {
            InitializeComponent();
            model_ = model;
            type_ = type;
            newClient_ = client;
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

            if (type_ == 0)
            {
                Client addClient = new Client(model_.GenerateNextID());
                addClient.Name = nameBox.Text;
                addClient.Description = desBox.Text;
                addClient.Phone = phoneBox.Text;
                addClient.Mail = mailBox.Text;
                addClient.ImagePath = selectedImagePath_;
                newClient_ = (Client)addClient;
                DialogResult = DialogResult.OK;
            }

            if (type_ == 1)
            {
                newClient_.Name = nameBox.Text;
                newClient_.Description = desBox.Text;
                newClient_.Phone = phoneBox.Text;
                newClient_.Mail = mailBox.Text;
                newClient_.ImagePath = selectedImagePath_;
                DialogResult = DialogResult.OK;
            }
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

                    try
                    {
                        string solutionDir = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
                        string resourcesDir = Path.Combine(solutionDir, "Resources", "img");

                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imagePath);
                        string destinationPath = Path.Combine(resourcesDir, fileName);

                        File.Copy(imagePath, destinationPath, true);

                        selectedImagePath_ = $"../../../Resources/img/{fileName}";

                        MessageBox.Show($"Изображение успешно загружено!", "Успех",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);

                        avatarBox.ImageLocation = selectedImagePath_;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}", "Ошибка",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

        private void AddClientForm_Load(object sender, EventArgs e)
        {
            if (type_ == 0)
            {
                nameBox.Text = string.Empty;
                desBox.Text = string.Empty;
                phoneBox.Text = string.Empty;
                mailBox.Text = string.Empty;
                selectedImagePath_ = null;
            }

            if (type_ == 1)
            {
                nameBox.Text = newClient_.Name;
                desBox.Text = newClient_.Description;
                phoneBox.Text = newClient_.Phone;
                mailBox.Text = newClient_.Mail;
                selectedImagePath_ = newClient_.ImagePath;
                avatarBox.ImageLocation = selectedImagePath_;
                this.Text = "Редактирование клиента " + newClient_.Name;
            }
        }
    }
}


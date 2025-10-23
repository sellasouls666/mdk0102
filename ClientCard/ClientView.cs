﻿using System.Windows.Forms;
using DemoLib.Views;
using DemoLib;
using System.Drawing;
using System;

namespace ClientCard
{
    public partial class ClientView: UserControl, IClientView
    {
        private Color defaultColor = Color.FromArgb(255, 255, 255);
        private Color enteringColor = Color.FromArgb(219, 211, 216);
        private Client client_;

        public event Action<Client> SelectedClient;

        public ClientView()
        {
            InitializeComponent();

            foreach (Control control in this.Controls)
            {
                control.MouseEnter += ClientView_MouseEnter;
                control.MouseLeave += ClientView_MouseLeave;
                control.MouseClick += ClientView_MouseClick;
            }
        }

        public void ShowClientInfo(Client client)
        {
            client_ = client;

            TitleLabel.Text = client.Name;
            DescriptionLabel.Text = client.Description;
            PhoneLabel.Text = client.Phone;
            MailLabel.Text = client.Mail;
            AvatarBox.Load(client.ImagePath);
        }

        public Client GetClientInfo()
        {
            return client_;
        }

        public void ShowView()
        {
            Visible = true;
        }
        public void HideView()
        {
            Visible = false;
        }

        private void ClientView_MouseEnter(object sender, System.EventArgs e)
        {
            this.BackColor = enteringColor;
        }

        private void ClientView_MouseLeave(object sender, System.EventArgs e)
        {
            this.BackColor = defaultColor;
        }

        private void ClientView_MouseClick(object sender, MouseEventArgs e)
        {
            SelectedClient?.Invoke(client_);
        }
    }
}

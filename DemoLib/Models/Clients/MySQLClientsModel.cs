﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace DemoLib.Models.Clients
{
    public class MySQLClientsModel : IClientsModel
    {
        private List<Client> clients = new List<Client>();
        private const string connStr = "server=localhost;user=root;database=clients_db;password=1234567;port=3307;";
        public int GetClientsCount()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connStr))
                {
                    connection.Open();

                    string sql = "SELECT COUNT(id) FROM clientsinfo";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    int result = Convert.ToInt32(command.ExecuteScalar().ToString());

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Client> ReadAllClients()
        {

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connStr))
                {
                    connection.Open();

                    string sql = "SELECT id, clientName, phone, mail, description, imagePath FROM clientsinfo";
                    MySqlCommand command = new MySqlCommand(sql, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Client client = new Client(reader.GetInt32(0));

                            client.Name = reader.GetString(1);
                            client.Phone = reader.GetString(2);
                            client.Mail = reader.GetString(3);
                            client.Description = reader.GetString(4);
                            client.ImagePath = reader.GetString(5);

                            clients.Add(client);
                        }
                    }

                    foreach (Client client in clients)
                    {
                        string orderQuery = "SELECT article, date, price, count FROM orders WHERE idclient = " + client.ID;
                        MySqlCommand orderCommand = new MySqlCommand(orderQuery, connection);
                        using (MySqlDataReader orderReader = orderCommand.ExecuteReader())
                        {
                            while (orderReader.Read())
                            {
                                OrderRecord orderRecord = new OrderRecord();
                                orderRecord.NameProduct = orderReader.GetString(0);
                                orderRecord.SaleDate = orderReader.GetDateTime(1);
                                orderRecord.Price = orderReader.GetDouble(2);
                                orderRecord.Count = orderReader.GetInt32(3);

                                client.order.AddRecord(orderRecord);
                            }
                        }
                    }

                    return clients;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GenerateNextID()
        {
            return clients.Count + 1;
        }

        public void AddClient(Client client)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connStr))
                {

                    connection.Open();
                    string addClientSql = 
                                "INSERT INTO clientsinfo (id, clientName, phone, mail, description, imagePath)"
                                + " VALUES (@id, @clientName, @phone, @mail, @description, @imagePath)";

                    MySqlCommand command = new MySqlCommand(addClientSql, connection);

                    command.Parameters.AddWithValue("@id", client.ID);
                    command.Parameters.AddWithValue("@clientName", client.Name);
                    command.Parameters.AddWithValue("@phone", client.Phone);
                    command.Parameters.AddWithValue("@mail", client.Mail);
                    command.Parameters.AddWithValue("@description", client.Description);
                    command.Parameters.AddWithValue("@imagePath", client.ImagePath);

                    command.ExecuteNonQuery();

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
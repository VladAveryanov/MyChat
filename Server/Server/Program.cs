using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    public class Client
    {
        public int ID { get; set; }
        public TcpClient client { get; set; }
    }
    public class ClientWorking
    {
        private Client currentClient;
        private List<Client> clients;
        public ClientWorking(Client client, List<Client> clients)
        {
            currentClient = client;
            this.clients = clients;
        }

        public void Work()
        {
            Console.WriteLine("Client" + " " + currentClient.ID + " " + "connected");

            byte[] buffer = new byte[1024];

            NetworkStream stream = currentClient.client.GetStream();

            var db = new MyDB();

            while (currentClient.client.Connected)
            {
                
                int streamLength = stream.Read(buffer, 0, buffer.Length);
                string mess = System.Text.Encoding.UTF8.GetString(buffer, 0, streamLength);

                
                if (mess == "end")
                {
                    currentClient.client.Close();
                    clients.Remove(currentClient);
                    break;

                }

                if (mess.Substring(0, 11) == "Подключился")
                {
                    // здесь будет проверка на существующего юзера
                    int chek = db.ChekUser(mess.Substring(12));

                    if (chek == 0)
                    {
                        string alreadyExisted = "not existed";
                        var responseChek = new byte[1024];
                        responseChek = System.Text.Encoding.UTF8.GetBytes(alreadyExisted);
                        stream.Flush();
                        stream.Write(responseChek, 0, responseChek.Length);
                        //db.SaveToDB(mess.Substring(12));
                    }
                    else
                    {
                        string alreadyExisted = "existed";
                        var responseChek = new byte[1024];
                        responseChek = System.Text.Encoding.UTF8.GetBytes(alreadyExisted);
                        stream.Flush();
                        stream.Write(responseChek, 0, responseChek.Length);
                    }
                }

                Console.WriteLine(mess);

                foreach (var e in clients)
                {
                    if (e != currentClient)
                    {
                        NetworkStream stream1 = e.client.GetStream();
                        var buff = new byte[1024];
                        buff = System.Text.Encoding.UTF8.GetBytes(mess);
                        stream1.Write(buff, 0, buff.Length);
                        Console.WriteLine("Отправил данные " + e.ID);

                    }
                }
            }
            currentClient.client.Close();
        }
    }

   

    public class MyDB
    {
        public SqlConnection sqlConnection;

        public MyDB()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString);

            sqlConnection.Open();

            if (sqlConnection.State == ConnectionState.Open)
                Console.WriteLine("Получилось!");
        }

        public void SaveToDB(string userName)
        {
            SqlCommand sqlCommand = new SqlCommand(
                $"INSERT INTO [Users] (UserName) VALUES (@UserName)", sqlConnection);

            sqlCommand.Parameters.AddWithValue("UserName", userName);

            int kek = sqlCommand.ExecuteNonQuery();
        }

        public int ChekUser(string username)
        {
            string sqlExpression = "SELECT COUNT(UserName) FROM Users WHERE UserName = '" + username + "'";
            SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
            
            var result = sqlCommand.ExecuteScalar();
            
            return (int)result;
        }
    }

    public class Program
    {
        public static int ID { get; set; }

        static void Main()
        {
            TcpListener socketServer = new TcpListener(IPAddress.Any, 7991);

            Console.WriteLine("Server started");

            socketServer.Start();

            List<Client> clients = new List<Client>();

            ID = 1;

           
            

            while (true)
            {
                TcpClient client = socketServer.AcceptTcpClient();

                Client testClient = new Client();

                testClient.ID = ID;
                ID++;
                testClient.client = client;

                clients.Add(testClient);

                ClientWorking clientWorking = new ClientWorking(testClient, clients);

                Thread thread = new Thread(new ThreadStart(clientWorking.Work));

                thread.Start();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace CMSProjectMP.App_Code
{
    public class ConnectionClass
    {
        ////static void Main(string[] args) { 
        public static SqlConnection conn;
        public static SqlCommand command;

        static ConnectionClass()
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            conn = new SqlConnection(connectionString);
            command = new SqlCommand("", conn);
        }

        public static ArrayList GetItemByType(string itemType)
        {
            ArrayList list = new ArrayList();
            string query = string.Format("SELECT * FROM Item WHERE type ='Shirt'", itemType);

            try
            {
                conn.Open();
                command.CommandText = query;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string type = reader.GetString(2);
                    int price = reader.GetInt32(3);
                    string description = reader.GetString(4);
                    string image = reader.GetString(5);
                    int selectionid = reader.GetInt32(6);

                    Item item = new Item(name, type, price, description, image, selectionid);
                    list.Add(item);
                }
            }
            finally
            {
                conn.Close();
            }

            return list;
        }
        public static void AddItem(Item item)
        {
            string query = $"INSERT INTO Item(Name,Type,Price,Image,Description,SelectionId) values ('{item.name}', '{item.type}', {item.price}, '{item.image}','{item.description}', {item.selectionid})";
                //item.name, item.type, item.price, item.image, item.description, item.selectionid);
            command.CommandText = query;
            command.Parameters.Add(new SqlParameter("price", item.price));
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                command.Parameters.Clear();
            }
        }

        public static List<Item> GetRelevantItems(int selectionId)
        {
            List<Item> items = new List<Item>();
            string query = $"SELECT * FROM Item where selection id = {selectionId}";
            //item.name, item.type, item.price, item.image, item.description, item.selectionid);
            command.CommandText = query;
            try
            {
                conn.Open();
                command.ExecuteReader();
            }
            finally
            {
                conn.Close();
                command.Parameters.Clear();
            }
            return items;
        }

        /*
        public static ArrayList<Joke> GetRelevantJokes(int selectionId)
        {
            ArrayList<Joke> jokes = new ArrayList<Joke>();
            string query = $"SELECT * FROM Joke where selection id = {selectionId}";
            //item.name, item.type, item.price, item.image, item.description, item.selectionid);
            command.CommandText = query;
            try
            {
                conn.Open();
                command.ExecuteReader();
            }
            finally
            {
                conn.Close();
                command.Parameters.Clear();
            }

            return jokes;
        }*/
    }

    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public int selectionid { get; set; }



        public Item(string name, string type, int price, string description, string image, int selectionId)
        {
            //this.id = id;
            this.name = name;
            this.type = type;
            this.price = price;
            this.description = description;
            this.image = image;
            this.selectionid = selectionId;
        }
    }
}
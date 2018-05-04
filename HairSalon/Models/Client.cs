using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalonApp;
using System;

namespace HairSalonApp.Models
{
  public class Client
  {
    private int _id;
    private string _name;
    // List<Client> allClients = new List<Client> {};

    public Client(string Name, int Id = 0)
    {
      _id = Id;
      _name = Name;
    }
    public override bool Equals(System.Object otherClient)
    {
        if (!(otherClient is Client))
        {
          return false;
        }
        else
        {
          Client newClient = (Client) otherClient;
          bool idEquality = (this.GetId() == newClient.GetId());
          bool nameEquality = (this.GetName() == newClient.GetName());
          return (idEquality && nameEquality);
        }
    }
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public static List<Client> GetAll()
    {
        List<Client> allClients = new List<Client> {}; //new Client("test client")
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM clients;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int clientId = rdr.GetInt32(0);
          string clientName = rdr.GetString(1);
          Client newClient = new Client(clientName, clientId);
          allClients.Add(newClient);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allClients;
    }
    public static void DeleteAll()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM clients;";

        cmd.ExecuteNonQuery();

        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
    }
    public void Save()
    {
       MySqlConnection conn = DB.Connection();
       conn.Open();

       var cmd = conn.CreateCommand() as MySqlCommand;
       cmd.CommandText = @"INSERT INTO clients (name) VALUES (@ClientName);";

       MySqlParameter name = new MySqlParameter();
       name.ParameterName = "@ClientName";
       name.Value = _name;
       cmd.Parameters.Add(name);

       cmd.ExecuteNonQuery();
       _id = (int) cmd.LastInsertedId;  // Notice the slight update to this line of code!

        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
    }
    public static Client Find(int id)
   {
       MySqlConnection conn = DB.Connection();
       conn.Open();

       var cmd = conn.CreateCommand() as MySqlCommand;
       cmd.CommandText = @"SELECT * FROM `clients` WHERE id = @thisId;";

       MySqlParameter thisId = new MySqlParameter();
       thisId.ParameterName = "@thisId";
       thisId.Value = id;
       cmd.Parameters.Add(thisId);

       var rdr = cmd.ExecuteReader() as MySqlDataReader;

       int clientId = 0;
       string clientName = "";

       while (rdr.Read())
       {
           clientId = rdr.GetInt32(0);
           clientName = rdr.GetString(1);
       }

       Client foundClient= new Client(clientName, clientId);  // This line is new!

        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }

       return foundClient;  // This line is new!

   }




  }
}

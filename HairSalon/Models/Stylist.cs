using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalonApp;
using System;
namespace HairSalonApp.Models
{
  public class Stylist
  {
    private static List<Stylist> _stylists = new List<Stylist> {};
    private string _name;
    private int _id;

    public Stylist(string stylistName, int Id = 0)
    {
      _name = stylistName;
      // _stylists.Add(this);
      _id = Id;
      // _stylists = new List<Stylist>{};
    }
    public List<Stylist> GetStylist()
    {
      return _stylists;
    }
    public void AddStylist(Stylist stylist)
    {
      _stylists.Add(stylist);
    }

    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Stylist> GetAll()
    {
        List<Stylist> allStylists = new List<Stylist> {}; //new Stylist("test stylist")
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM stylists;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int stylistId = rdr.GetInt32(0);
          string stylistName = rdr.GetString(1);
          Stylist newStylist = new Stylist(stylistName, stylistId);
          allStylists.Add(newStylist);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allStylists;
    }
    public static void Clear()
    {
      _stylists.Clear();
    }
    public static void DeleteAll()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM stylists;";

        cmd.ExecuteNonQuery();

        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
    }
    public static Stylist Find(int id)
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM `stylists` WHERE id = @thisId;";

        MySqlParameter thisId = new MySqlParameter();
        thisId.ParameterName = "@thisId";
        thisId.Value = id;
        cmd.Parameters.Add(thisId);

        var rdr = cmd.ExecuteReader() as MySqlDataReader;

        int stylistId = 0;
        string stylistDescription = "";

        while (rdr.Read())
        {
            stylistId = rdr.GetInt32(0);
            stylistDescription = rdr.GetString(1);
        }

        Stylist foundStylist= new Stylist(stylistDescription, stylistId);  // This line is new!

         conn.Close();
         if (conn != null)
         {
             conn.Dispose();
         }

        return foundStylist;  // This line is new!

    }
    //beginning of database code
    public void Save()
    {
       MySqlConnection conn = DB.Connection();
       conn.Open();

       var cmd = conn.CreateCommand() as MySqlCommand;
       cmd.CommandText = @"INSERT INTO stylists (stylistName) VALUES (@StylistDescription);";

       MySqlParameter stylistName = new MySqlParameter();
       stylistName.ParameterName = "@StylistDescription";
       stylistName.Value = _name;
       cmd.Parameters.Add(stylistName);

       cmd.ExecuteNonQuery();
       _id = (int) cmd.LastInsertedId;  // Notice the slight update to this line of code!

        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
    }
  }
}

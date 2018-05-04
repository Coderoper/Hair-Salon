using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalonApp.Models
{
  public class Stylist
  {
    private static List<Stylist> _instances = new List<Stylist> {};
    private string _name;
    private int _id;
    private List<Stylist> _stylists;

    public Stylist(string stylistName)
    {
      _name = stylistName;
      _instances.Add(this);
      _id = _instances.Count;
      _stylists = new List<Stylist>{};
    }
    public List<Stylist> GetStylists()
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
      return _instances;
    }
    public static void Clear()
    {
      _instances.Clear();
    }
    public static Stylist Find(int searchId)
    {
      return _instances[searchId-1];
    }
    //beginning of database code
    public void Save()
    {
       MySqlConnection conn = DB.Connection();
       conn.Open();

       var cmd = conn.CreateCommand() as MySqlCommand;
       cmd.CommandText = @"INSERT INTO clients (stylistName) VALUES (@StylistDescription);";

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

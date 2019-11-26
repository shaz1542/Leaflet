using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace HolidayDestinations.Controllers
{
    public class HolidaysController : Controller
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        public IActionResult Index()
        {
            //Create("test location", "22.33", "33.22");

            //Get All the destinations
            List<Destination> dest = GetAll();
            //load the map

            return View();
        }
        public List<Destination> GetAll()
        {
            List<Destination> destinations = new List<Destination>();
            string insertQuery = string.Format("select * from holiday_destination.destinations");
            MySqlCommand mySqlCommand = new MySqlCommand(insertQuery, connection);
            connection.Open();
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    Destination d = new Destination
                    {
                        title = reader.GetString("note"),
                        lat = double.Parse(reader.GetString("latitude")),
                        lng = double.Parse(reader.GetString("longitude"))
                    };
                    destinations.Add(d);
                }
            }

            catch (Exception ex)
            {
                var p = ex.ToString();
            }
            connection.Close();
            return destinations;
        }

        public void Create(string note, string lat, string lng)
        {
            string insertQuery = string.Format("insert into holiday_destination.destinations(latitude,longitude,note)values({0},{1},'{2}')", lat, lng, note);
            connection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand(insertQuery, connection);
            try
            {
                if (mySqlCommand.ExecuteNonQuery() == 1)
                {

                }
                else
                {
                    //failed
                }
            }
            catch (Exception ex)
            {
                var p = ex.ToString();
            }
            connection.Close();
        }

        public void Delete(int id)
        {
            string query = string.Format("DELETE  from holiday_destination.destinations where id ='{0}')", id);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }

    public class Destination
    {
        public string title;
        public double lat;
        public double lng;
    }

}
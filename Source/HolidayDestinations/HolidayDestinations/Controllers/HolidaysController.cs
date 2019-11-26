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
            Create("test location", "22.33", "33.22");
            return View();

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
        public void Delete(Destination d)
        {

        }

    }

    public class Destination
    {
        public string title;
        public double lat;
        public double lng;
    }

}
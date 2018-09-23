using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace gardenBox
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\meaga\source\repos\gardenBox\gardenBox\Database1.mdf;Integrated Security=True");
            connection.Open();
            SqlDataReader reader;

            Console.WriteLine("What is the length of your box?");
            int length = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What is the width of your box?");
            int width = Convert.ToInt32(Console.ReadLine());

            int area = (length * width);

            Console.WriteLine($"The area of your box is:  {area} sqft");

            SqlCommand plantQuery = new SqlCommand("Select Id, plants from Crops", connection);
            reader = plantQuery.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Id"]}) {reader["plants"]}");
                }
                
            }
            reader.Close();

            Console.WriteLine("Which crop would you like to plant? Please choose an ID.");
            int userCrop = Convert.ToInt32(Console.ReadLine());

            SqlCommand userPlantQuery = new SqlCommand($"Select numpersq as num from Crops where Id ='{userCrop}'", connection);
            reader = userPlantQuery.ExecuteReader();
            decimal num = 0;
            if (reader.HasRows)
            {
                reader.Read();
                num = Convert.ToDecimal(reader["num"]);
                Console.WriteLine("You can plant: " + num * area + " plants in your box!");


            }
            reader.Close();






            connection.Close();
            Console.ReadLine();

        }
    }
}

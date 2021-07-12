using MySql.Data.MySqlClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWithNUnit
{
    class DataBase
    {

        public static List<TestCaseData> ReadTestData()
        {
            string dbname = "testdata";
            string tablename = "googlesearch";
            string query = "SELECT * FROM " + dbname + "." + tablename;

            string connectionstring = @"server=localhost;userid=ameya;password=ameya123;database=" + dbname;

            var connection = new MySqlConnection(connectionstring);

            connection.Open();

            Console.WriteLine($"MySQL version : {connection.ServerVersion}");

            //string query = "SELECT searchstring, searchtitle FROM testdata.googlesearch";

            var command = new MySqlCommand(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            var data = new List<TestCaseData>();

            while (reader.Read())
            {
                string searchstring = reader.GetString(0);
                string searchtitle = reader.GetString(1);

                //data.Add(new TestCaseData(searchstring).Returns(searchtitle));
                data.Add(new TestCaseData(searchstring, searchtitle));
                Console.WriteLine(searchstring + " " + searchtitle);
            }
            return data;
        }

        [TestCaseSource("ReadTestData")]
        public void Test_DB_ReadWithoutExpected(string search, String title)
        {
            Console.WriteLine(search + " : " + title);
            
        }

        [TestCaseSource("ReadTestData")]
        public string Test_DB_Read(string searchstring)
        {
            Console.WriteLine(searchstring);
            return searchstring + " - Google Search";
        }

        public static void Read(string dbname, string tablename)
        {
            string connectionstring = @"server=localhost;userid=ameya;password=ameya123;database=" + dbname;

            var connection = new MySqlConnection(connectionstring);

            connection.Open();

            Console.WriteLine($"MySQL version : {connection.ServerVersion}");

            string query = "SELECT searchstring, searchtitle FROM testdata.googlesearch";

            var command = new MySqlCommand(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0) + " " + reader.GetString(1));
            }
        }

        [Test]
        public void Test_DB_Connectivity()
        {
            Read("testdata", "googlesearch");
        }
    }
}

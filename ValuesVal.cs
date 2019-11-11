using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ugh.Models;
using System.Collections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlTypes;

namespace ugh
{
    public class ValuesVal
    {
        private MySql.Data.MySqlClient.MySqlConnection conn;
        public ValuesVal()
        {
            string connStr = "server=localhost;user=root;database=ebgamedb;port=3306;password=reggie15";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = connStr;
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM Products";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " - " + rdr[2] + " - " + rdr[1] + " - -" + rdr[4]);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            Console.WriteLine("Done.");







        }

        public Values getValues(int id)
        {
            Values v = new Values();
            MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;
            string sqlString = $"SELECT * FROM Products WHERE id ={id}";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            mySQLReader = cmd.ExecuteReader();

            if (mySQLReader.Read())
            {
                v.id = mySQLReader.GetInt32(0);
                v.product_name = mySQLReader.GetString(1);
                v.stock_quantity = mySQLReader.GetInt32(2);
                v.des_box = mySQLReader.GetString(3);
                v.URL = mySQLReader.GetString(4);
                v.categories = mySQLReader.GetString(5);
                return v;

            }
            else
            {
                return null;
            }



        }
        public ArrayList allValues()
        {
            ArrayList valueArray = new ArrayList();

            MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;
            string sqlString = $"SELECT * FROM Products";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            mySQLReader = cmd.ExecuteReader();

            while (mySQLReader.Read())
            {
                Values v = new Values();
                v.id = mySQLReader.GetInt32(0);
                v.product_name = mySQLReader.GetString(1);
                v.stock_quantity = mySQLReader.GetInt32(2);
                v.des_box = mySQLReader.GetString(3);
                v.URL = mySQLReader.GetString(4);
                v.categories = mySQLReader.GetString(5);
                valueArray.Add(v);

            }
            return valueArray;



        }

        //public long saveToPerson(Values personToSave)
        //{
        //    string sql = "SELECT * FROM Products";
        //    //string sqlStering = "INSERT INTO Products(product_name,stock_quantity,url,des_box,categories) VALUES ('" + personToSave.product_name + "', '" + personToSave.stock_quantity + "', " + personToSave.URL + "' , '" + personToSave.des_box + "', '" + personToSave.categories + ")";
        //    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);

        //    cmd.ExecuteNonQuery();
        //    long id = cmd.LastInsertedId;
        //    return (int)id;


        //}
        public int allPeople(Values personToSave)
        {

            string query = $"INSERT INTO Products (product_name,stock_quantity,URL,des_box,categories) VALUES('{personToSave.product_name}','{personToSave.stock_quantity}','{personToSave.URL}','{personToSave.des_box}','{personToSave.categories}')";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;
            return (int)id;









        }

        public bool deleteVal (int id)
        {
            
            MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;
            string sqlString = $"SELECT * FROM Products WHERE id ={id}";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            mySQLReader = cmd.ExecuteReader();

            if (mySQLReader.Read())
            {
                mySQLReader.Close();
                sqlString = $"DELETE FROM Products WHERE id ={id}";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                return true;

            }
            else
            {
                return false;
            }


        }
        public bool updateVal(int id, Values personToSave)
        {
            Values v = new Values();
            MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;
            string sqlString = $"SELECT * FROM Products WHERE id ={id}";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            mySQLReader = cmd.ExecuteReader();

            if (mySQLReader.Read())
            {
                mySQLReader.Close();
                sqlString = $"UPDATE Products SET product_name = '{personToSave.product_name}',stock_quantity ='{personToSave.stock_quantity}', URL =' {personToSave.URL}',des_box='{personToSave.des_box}',categories='{personToSave.categories}' WHERE id ={id} ";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                return true;

            }
            else
            {
                return false;
            }


        }



    }

   
    }






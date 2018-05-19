using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using Mono.Data.Sqlite;

public class testDataSQLite : MonoBehaviour {

    /// <summary>  
    /// SQLite数据库辅助类  
    /// </summary>  
    private SQLiteHelper sql;

    // Use this for initialization
    void Start () {
        print("start");
        //创建名为sqlite4unity的数据库  
        sql = new SQLiteHelper("data source=sqlite4unity.db");

        /*** 
         * run once for create table
         *
        //创建名为results的数据表  
        sql.CreateTable("results", new string[] { "id", "name", "result", "date" }, new string[] { "INTEGER", "TEXT", "INTEGER", "TEXT" });
         */

        /***
         * Insert four items of data
         * We can insert repeatedly, because we don't use primary key or unique in the table results
         */
        print(System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        sql.InsertValues("results", new string[] { "'1'", "'a'", "'0'",
            "'" + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'" });
        sql.InsertValues("results", new string[] { "'2'", "'b'", "'10'", "'2018-05-19 16:00:00'" });
        sql.InsertValues("results", new string[] { "'3'", "'c'", "'20'", "'2018-05-19 17:00:00'" });
        sql.InsertValues("results", new string[] { "'4'", "'d'", "'50'", "'2018-05-19 18:00:00'" });

        //update data, change the datetime which name is "d" to Now
        sql.UpdateValues("results", new string[] { "date" }, 
            new string[] { "'" + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'" }, 
            "name", "=", "'d'");

        // delete data, delete the data which name is "b" AND result is "10"
        sql.DeleteValuesAND("results", new string[] { "name", "result" }, new string[] { "=", "=" }, 
            new string[] { "'b'", "'10'" });

        //read all data of a specific table
        SqliteDataReader reader = sql.ReadFullTable("results");
        while (reader.Read())
        {
            //读取ID
            Debug.Log(reader.GetInt32(reader.GetOrdinal("id")));
            //读取Name
            Debug.Log(reader.GetString(reader.GetOrdinal("name")));
            //读取Age
            Debug.Log(reader.GetInt32(reader.GetOrdinal("result")));
            //读取Email
            Debug.Log(reader.GetString(reader.GetOrdinal("date")));
        }

        //read the data of table which result is higher than 40
        reader = sql.ReadTable("results", new string[] { "id", "name" }, new string[] { "result" }, 
            new string[] { ">" }, new string[] { "'40'" });
        while (reader.Read())
        {
            print("====================================================");
            //读取ID
            Debug.Log(reader.GetInt32(reader.GetOrdinal("id")));
            //读取Name
            Debug.Log(reader.GetString(reader.GetOrdinal("name")));
            print("====================================================");
        }

        //自定义SQL
        //delete all the data which name = "a"
        sql.ExecuteQuery("DELETE FROM results WHERE NAME='a'");

        //关闭数据库连接
        sql.CloseConnection();
        print("finish");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

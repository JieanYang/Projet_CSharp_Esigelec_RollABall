using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using System.IO;
using Mono.Data.Sqlite;
using TMPro;

public class mainmenu : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject time1;
    public GameObject time2;
    public GameObject time3;
    private SQLiteHelper sql;
	// Use this for initialization
	void Start () {
	
        
	}

    public void GetTopList (){
        
    }
	public void QuitGame (){
        Application.Quit();
    }
    
	// Update is called once per frame
	void Update () {
		//UsernameGlobal = usernameLogin.GetComponent<InputField>().text;
        //print(UsernameGlobal);
        	sql = new SQLiteHelper("data source=sqlite4unity.db");
        SqliteDataReader reader;
        
        reader = sql.ExecuteQuery("SELECT name,result FROM results ORDER BY result ASC");
        int i=0;
        
        while (reader.Read())
        {
            if(i==0){
                i++;
                player1.GetComponent<TextMeshProUGUI> ().text=reader.GetString(reader.GetOrdinal("name"));
                time1.GetComponent<TextMeshProUGUI>().text=reader.GetString(reader.GetOrdinal("result"));
            }else if(i==1){
                i++;
                  player2.GetComponent<TextMeshProUGUI> ().text=reader.GetString(reader.GetOrdinal("name"));
                time2.GetComponent<TextMeshProUGUI>().text=reader.GetString(reader.GetOrdinal("result"));
            }else if(i==2){
                  player3.GetComponent<TextMeshProUGUI> ().text=reader.GetString(reader.GetOrdinal("name"));
                time3.GetComponent<TextMeshProUGUI>().text=reader.GetString(reader.GetOrdinal("result"));
            }
            
            
           // Debug.Log(reader.GetString(reader.GetOrdinal("name")));
            //读取Age
            //Debug.Log(reader.GetInt32(reader.GetOrdinal("result")));
           
        }

        //close the connection
        //sql.CloseConnection();
	}
}

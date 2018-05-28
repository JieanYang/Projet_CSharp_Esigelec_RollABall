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
    
    //fonction qui permet de quitter l'application
	public void QuitGame (){
        Application.Quit();
    }
    
	// Update is called once per frame
	void Update () {
        
        //sql qui permet d'afficher la liste du top 3 joueurs
        sql = new SQLiteHelper("data source=sqlite4unity.db");
        SqliteDataReader reader;
        
        reader = sql.ExecuteQuery("SELECT name,result FROM results ORDER BY result ASC");
        int i=0;
        
        while (reader.Read())
        {
            if(i==0){
                player1.GetComponent<TextMeshProUGUI> ().text=reader.GetString(reader.GetOrdinal("name"));
                time1.GetComponent<TextMeshProUGUI>().text=reader.GetString(reader.GetOrdinal("result"));
                i++;
            }else if(i==1){
                player2.GetComponent<TextMeshProUGUI> ().text=reader.GetString(reader.GetOrdinal("name"));
                time2.GetComponent<TextMeshProUGUI>().text=reader.GetString(reader.GetOrdinal("result"));
                i++;
            }else if(i==2){
                player3.GetComponent<TextMeshProUGUI> ().text=reader.GetString(reader.GetOrdinal("name"));
                time3.GetComponent<TextMeshProUGUI>().text=reader.GetString(reader.GetOrdinal("result"));
                i++;
            }
            
        }
        //close the connection
        //sql.CloseConnection();
	}
}

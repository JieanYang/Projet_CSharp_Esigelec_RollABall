using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;

public class BallController_labyrinth : MonoBehaviour
{
   //initialisation de la vitesse de balle
    public float speed = 15;
    public Text userName;
    public Text countText;
    public Text winText;
    public Text timeText;
    public GameObject BackButton;
    private Rigidbody rb;
    private SQLiteHelper sql;

    private int count;
    private System.DateTime date_start = System.DateTime.Now;
    private System.DateTime date_finish;
    //resultat en seconde du niveau 2
    public static System.TimeSpan result_level2;
    
    //Fonction d'initialisation
    void Start()
    {
        print("start -> BallController_labyrinth");
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        userName.text = okButton.UsernameGlobal;
        winText.text = "";
        timeText.text = "";
        result_level2 = System.DateTime.Now - System.DateTime.Now;
    }
    
//Control de la vitesse et la direction de balle
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    //Si balle touche un objet, point++
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
    //Rafraichir l'affichage
    void SetCountText()
    {
        countText.text = "Goal: " + count.ToString() + "/3";
        if (count >= 3)
        {
            date_finish = System.DateTime.Now;
            string time_row = (date_finish - date_start).ToString();
            string time_game = time_row.Substring(0, time_row.IndexOf("."));

            winText.text = "You win, " + userName.text + "!";
            timeText.text = "Time : " + time_game;
            BackButton.SetActive(true);
            result_level2 = date_finish - date_start;
            print("result2 ->" + result_level2);

            // result total
            string time_total_row = (BallController.result_level1 + result_level2).ToString();
            string time_game_total = time_total_row.Substring(0, time_total_row.IndexOf("."));
            
            //enregistrer le resultat dan sla base de donnees: nom du joueur et son resultat en seconde
            sql = new SQLiteHelper("data source=sqlite4unity.db");
            try
            {
                sql.CreateTable("results", new string[] { "id", "name", "result", "date" }, 
                    new string[] { "INTEGER", "TEXT", "INTEGER", "TEXT" });
            }
            catch
            {
                print("There have had the tabel results");
            }
            finally
            {
                sql.InsertValues("results", new string[] { "''", "'" + userName.text + "'",
                "'" + time_game_total + "'", "'" + System.DateTime.Now.ToString("yyyy/MM/dd") + "'" });

                print("result total ->" + time_game_total);

                sql.CloseConnection();
            }
        }
    }



}

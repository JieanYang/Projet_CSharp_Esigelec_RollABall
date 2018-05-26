using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using System.IO;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;

public class BallController_labyrinth : MonoBehaviour
{

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
    public static System.TimeSpan result_level2 = System.DateTime.Now - System.DateTime.Now;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        userName.text = okButton.UsernameGlobal;
        winText.text = "";
        timeText.text = "";

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString() + "/12";
        if (count >= 1)
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

            sql = new SQLiteHelper("data source=sqlite4unity.db");
            sql.InsertValues("results", new string[] { "''", "'" + userName.text + "'",
                "'" + time_game_total + "'", "'" + System.DateTime.Now.ToString("yyyy/MM/dd") + "'" });
            sql.CloseConnection();

            print("result total ->" + time_game_total);

            // reset value of result in the level 1 and the level 2
            //BallController.result_level1 = System.DateTime.Now - System.DateTime.Now;
            //result_level2 = System.DateTime.Now - System.DateTime.Now;
        }
    }



}

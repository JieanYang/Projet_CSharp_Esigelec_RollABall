using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using System.IO;
using Mono.Data.Sqlite;

public class BallController : MonoBehaviour {

    public float speed = 15;
    public Text userName;
    public Text countText;
    public Text winText;
    public Text timeText;
    public GameObject levelButton;

    private Rigidbody rb;
    private SQLiteHelper sql;

    private int count;
    private System.DateTime date_start = System.DateTime.Now;
    private System.DateTime date_finish;
    public static System.TimeSpan result_level1;

    void Start ()
    {
        print("start -> BallController");
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        userName.text = okButton.UsernameGlobal;
        winText.text = "";
        timeText.text = "";
        result_level1 = System.DateTime.Now - System.DateTime.Now;
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
    
    void SetCountText(){
        countText.text = "Goal: " + count.ToString() + "/3";
        if (count >= 3)
        {
            date_finish = System.DateTime.Now;
            string time_row = (date_finish - date_start).ToString();
            string time_game = time_row.Substring(0, time_row.IndexOf("."));

            // sql = new SQLiteHelper("data source=sqlite4unity.db");
            // sql.InsertValues("results", new string[] { "''", "'" + userName.text + "'",
            // "'" + time_game + "'", "'" + System.DateTime.Now.ToString("yyyy/MM/dd") + "'" });
            // sql.CloseConnection();

            winText.text = "You win, " + userName.text + "!";
            timeText.text = "Time : " + time_game;
            levelButton.SetActive(true);
            result_level1 = date_finish - date_start;
            print("result1 ->" + result_level1);

        }
    }

    
	// Update is called once per frame
	void Update () {
		
	}
}

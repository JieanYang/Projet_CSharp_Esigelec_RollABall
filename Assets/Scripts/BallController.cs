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
    private Rigidbody rb;
    private SQLiteHelper sql;

    private int count;
    private System.DateTime date_start = System.DateTime.Now;
    private System.DateTime date_finish;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        userName.text = okButton.UsernameGlobal;
        winText.text = "";
        timeText.text = "";
        print("start");

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
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            date_finish = System.DateTime.Now;
            string time_row = (date_finish - date_start).ToString();
            string time_game = time_row.Substring(0, time_row.IndexOf("."));
            print("time:" + time_game);

            sql = new SQLiteHelper("data source=sqlite4unity.db");
            sql.InsertValues("results", new string[] { "''", "'" + userName.text + "'",
                "'" + time_game + "'", "'" + System.DateTime.Now.ToString("yyyy/MM/dd") + "'" });
            sql.CloseConnection();

            winText.text = "You win, " + userName.text + "!";
            timeText.text = "Time : " + time_game;
        }
    }

    
	// Update is called once per frame
	void Update () {
		
	}
}

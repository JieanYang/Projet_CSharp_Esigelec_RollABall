using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel_Button : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}

    public void NextGame (){
        if(BallController.result_level1 == (System.DateTime.Now - System.DateTime.Now))
        {
            Debug.LogWarning("Username empty");
        }
        else
        {
            print("button next level");
            SceneManager.LoadScene("Labyrinth");   
        }
        
    }

    // Update is called once per frame
    void Update () {
     /*   if (Input.GetKeyDown(KeyCode.Return))
        {
            print("button next level");
            NextGame ();
        }*/
    }
}

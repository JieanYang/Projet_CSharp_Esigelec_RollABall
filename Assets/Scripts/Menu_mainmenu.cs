using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour {
    public static string username = "Unknown";
	// Use this for initialization
	void Start () {
		
	}
    public void PlayGame (){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
	public void QuitGame (){
        Application.Quit();
    }
	// Update is called once per frame
	void Update () {
		
	}
}

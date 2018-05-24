using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Text.RegularExpressions;

public class okButton : MonoBehaviour {
    public GameObject username;
    public static string UsernameGlobal;
   
	// Use this for initialization
	void Start () {
		
	}
    public void PlayGame (){
        if(UsernameGlobal == ""){
            Debug.LogWarning("Username empty");
            
        }else{
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   
            print(UsernameGlobal);
        }
        
    }
    
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return)){
            if (UsernameGlobal != ""){
                PlayGame ();
            }
        }
		UsernameGlobal = username.GetComponent<InputField>().text;
        //print(UsernameGlobal);
	}
}

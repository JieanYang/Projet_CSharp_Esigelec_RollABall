﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class mainmenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    /*public void PlayGame (){
        if(UsernameGlobal == ""){
            Debug.LogWarning("Username empty");
            
        }else{
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   
            print(UsernameGlobal);
        }
        
    }*/
    
	public void QuitGame (){
        Application.Quit();
    }
    
	// Update is called once per frame
	void Update () {
		//UsernameGlobal = usernameLogin.GetComponent<InputField>().text;
        //print(UsernameGlobal);
	}
}
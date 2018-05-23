using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;


public class register : MonoBehaviour {
    
    public GameObject username;
    public GameObject password;
    private string Username;
    private string Password;
    private string form;
    private bool UserExtist = false;
	// Use this for initialization
	void Start () {
		
	}
	public void RegisterButton () {
        if(Username == ""){
            Debug.LogWarning("Username empty");
        }
        
        
        if(Password == ""){
            Debug.LogWarning("Password empty");
        }
        
    }
    
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab)){
            if (username.GetComponent<InputField>().isFocused){
                password.GetComponent<InputField>().Select();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Return)){
            if (Password != "" && Username != ""){
                RegisterButton ();
            }
        }
		Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
	}
}

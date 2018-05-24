using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_mainMenu : MonoBehaviour {

	public void scene_top3()
    {
        SceneManager.LoadScene("TOP 3");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour {

    // Next level button
    public void NextLevel()
    {
        if (BallController.result_level1 == (System.DateTime.Now - System.DateTime.Now))
        {
            Debug.LogWarning("Username empty");
        }
        else
        {
            print("button next level");
            SceneManager.LoadScene("Labyrinth");
        }

    }

    // Back button
    public void BackMenu()
    {
        SceneManager.LoadScene("menu");
    }


}

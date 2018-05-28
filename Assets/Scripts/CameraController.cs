using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject ball;

    private Vector3 offset;
    
    //Initialisation de la variable offset qui est la difference de position entre la camera et la balle
	void Start () {
        offset = transform.position - ball.transform.position;
	}
    //Fonction pour que la camera bouge avec la balle
	void LateUpdate () {
        transform.position = ball.transform.position + offset;
	}
}

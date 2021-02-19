﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTemplateProjects;

public class Arrow_Controller : MonoBehaviour
{
    public GameObject rotaionCamera;
    public GameObject arrow;
    public GameManager gameManager;
    public GameObject club;
    public GameObject golfBall;
    public GameObject xrrig;
 public GameObject camOffset;
    public Vector3 forceDirection;
    public GameObject golfball;
    // Start is called before the first frame update
    void Start()
    {
         arrow.SetActive(false);                                        // Deaktiviert den Pfeil
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.aimPhase())                             // Wenn man in der Aimphase ist ( Richungsauswahl)
        {
             
            followCamera();                                     // Funktion followCamera wird ausgeführt 
            arrow.SetActive(true);                              // Pfeil wird aktiviert
            club.SetActive(false);                              // Golfschläger wird deaktiviert
        } 

        if(gameManager.overAimPhase())
        {
            //Debug.Log("Pfeil verschwindet");
         
            arrow.SetActive(false);                                  //Pfeil wird deaktiviert
        }
        
    }
    public void followCamera()
    {
        
        transform.rotation = rotaionCamera.transform.rotation;   // Der Pfeil erhält die Rotation der Kamera
        var rot = transform.rotation;                            // Variable rot erhält die aktuelle Rotation
        transform.rotation = new Quaternion(0, rot.y, 0, rot.w); // Die Rotation wird auf der X und Z Achse gesperrt    
        xrrig.transform.position = golfBall.transform.position;  // XR Rig wird auf die Position des Balls gesetzt
       camOffset.transform.position =new Vector3( golfBall.transform.position.x,golfBall.transform.position.y+1,golfBall.transform.position.z    );



        
    }
}

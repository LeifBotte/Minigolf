﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GolfHoleScript : MonoBehaviour {
    public AudioClip sound;
    public BallController ballcontroller;
    public GameObject planeWin;
    public static bool holeWon;
    public float winTime = 10;
    public float timer = 10;
    public bool holeTrigger = false;
    public static int holeCounter;

    void Start(){
        planeWin.SetActive (false);
    }


    void Update () {
        if (!holeWon) //Wenn der Ball noch nicht im Ziel ist
        {
           // planeWin.SetActive (false); //bleibt die Gewinnerplane deaktiviert
        }

        if (holeTrigger) // wenn der Ball ins Ziel trifft
        {

            holeWon = true;
            holeTrigger = false;
            holeCounter ++;
            if (holeCounter == 9) {
                holeCounter = 0;
            }
            Debug.Log("LochCount: "+holeCounter);

        }
    }

    void OnTriggerEnter (Collider other) {
        if (other.name == "Golfball") { //wenn der Ball in das Loch fällt
            planeWin.transform.position = new Vector3(transform.position.x,transform.position.y+1,transform.position.z);
            planeWin.SetActive (true); //setzt die Win Plane true
            AudioSource.PlayClipAtPoint (sound, transform.position, 0.7f); //Spiel Sound ab
            holeTrigger = true; //setzte holeTrigger auf true
            ballcontroller.StopBall (); //führe die funktion stopball() aus dem BallController aus
        }
    }
}
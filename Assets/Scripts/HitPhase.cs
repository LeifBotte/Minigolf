using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityTemplateProjects;

public class HitPhase : MonoBehaviour
{
    public GameObject arrowManager;
    public GameObject club;
    public GameManager gameManager;
    public GameObject camOffset;
    public GameObject golfBall;
    public GameObject cam;
    public float x = 0;

    // Update is called once per frame
    void Update()
    {
        //funktion wird ausgeführt
        PhaseIt();
    }

    public void enableClub()
    {
        
        //Debug.Log("Golfschläger erscheint");

        club.SetActive(true);

    }


    //Mit dieser Funktion drehen wir uns nach der Richtungsauswahl um 90 Grad um den Ball
    public void PhaseIt()
    {
        if (gameManager.rotationRXRig())                                                    //Wenn Richtungswahl abgeschlossen ist
        {
            // Debug.Log("directioooooooooooooooooooooon");
            //    camOffset.transform.position = transform.position + new Vector3(0,1.13f,-1.13f);
         
            camOffset.transform.position = new Vector3(golfBall.transform.position.x - 1.2f, golfBall.transform.position.y + 1.32f, golfBall.transform.position.z);
            transform.rotation = arrowManager.transform.rotation;
            Debug.Log("yoyoyo" + arrowManager.transform.rotation);                       //XR Rig erhält die Rotation des Pfeiles
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);      //XR Rig dreht sich um 90 Grad 
            Debug.Log("Rotation: " + transform.rotation);
            enableClub();                                                               //Schläger erscheint

        }
    }

}
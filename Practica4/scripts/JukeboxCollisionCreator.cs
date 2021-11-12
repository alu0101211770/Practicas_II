using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeboxCollisionCreator : MonoBehaviour
{
    public delegate void jukebox();
    public static event jukebox jukeBoxCollision;

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Player") 
        {
            jukeBoxCollision();
        }
    }
}

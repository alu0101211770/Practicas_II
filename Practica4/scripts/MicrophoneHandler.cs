using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneHandler : MonoBehaviour
{
    AudioSource microphone;
    public float distanceThreshold = 5f;
    GameObject player;
    
    int collisionCount = 0;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        microphone = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        JukeboxCollisionCreator.jukeBoxCollision += audioRecorder;
    }


    void OnDisable()
    {
        JukeboxCollisionCreator.jukeBoxCollision -= audioRecorder;
    }

    // On the first collision, start recording, on the second collision, stop recording and on the third collision reproduce the recording
    void audioRecorder()
    {
        if (collisionCount == 0)
        {
            microphone.clip = Microphone.Start(null, true, 10, 44100);
        }
        else if (collisionCount == 1)
        {
            Microphone.End(null);
        }
        else if (collisionCount == 2)
        {
            microphone.loop = true;
            microphone.Play();
            collisionCount = -1;
        }
        collisionCount++;
    }
}

using UnityEngine;
using System.Collections;

public class CameraHandler : MonoBehaviour
{
    WebCamTexture webcamTexture;
    GameObject player;
    public float distanceThreshold = 5f;
    Texture initialTexture;
    
    void Awake()
    {
        initialTexture = GetComponent<Renderer>().material.mainTexture;
        player = GameObject.FindGameObjectWithTag("Player");
        webcamTexture = new WebCamTexture();
    }

    void Update()
    {
        Vector3 playerPos = player.transform.position;
        float distance = Vector3.Distance(playerPos, transform.position);
        if (distance < distanceThreshold)
        {
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.mainTexture = webcamTexture;
            webcamTexture.Play();        
        } else 
        {
            webcamTexture.Stop();
            GetComponent<MeshRenderer>().material.mainTexture = initialTexture;
        }
    }
}
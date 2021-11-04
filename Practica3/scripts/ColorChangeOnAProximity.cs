using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeOnAProximity : MonoBehaviour
{
    GameObject player;
    Color objectColor;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void OnEnable()
    {
        GameManager.OnAProximity += ChangeColor;
    }


    void OnDisable()
    {
        GameManager.OnAProximity -= ChangeColor;
    }


    void ChangeColor()
    {
        objectColor = GetComponent<Renderer>().material.color;
        Color newColor = new Color(objectColor.r * Random.Range(0.95f, 1.05f), 
            objectColor.g * Random.Range(0.95f, 1.05f), 
            objectColor.b * Random.Range(0.95f, 1.05f), 
            1f);
        GetComponent<Renderer>().material.SetColor("_Color", newColor);
    }
}

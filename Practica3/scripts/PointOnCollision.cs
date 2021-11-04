using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointOnCollision : MonoBehaviour
{
    public Text text;
    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Player" && text != null)
        {
            text.text = (int.Parse(text.text) + 1).ToString();
        }
    }
}

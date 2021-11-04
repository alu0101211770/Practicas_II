using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    
    public delegate void ACollision();
    public static event ACollision OnACollision;
    public delegate void BCollision();
    public static event BCollision OnBCollision;
    public delegate void AProximity();
    public static event AProximity OnAProximity;

    void Awake()
    {
        if (manager == null) {
            manager = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void ThrowACollision()
    {
        OnACollision();
    }

    public void ThrowBCollision()
    {
        OnBCollision();
    }
    
    public void ThrowAProximity()
    {
        OnAProximity();
    }
}

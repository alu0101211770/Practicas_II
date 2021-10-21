using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display_Object_Info : MonoBehaviour {
    public int id = 0;
    int count = 0;
    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {
        Debug.Log("name: " + gameObject.name + " id: " + id + " iteration: " + count);
        count++;
    }
}

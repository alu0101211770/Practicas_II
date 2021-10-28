using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increase_size_on_collision : MonoBehaviour {
    public float scale_change = 1.2f;

    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "Cube Player"){
            transform.localScale *= scale_change;
        }
    }
}

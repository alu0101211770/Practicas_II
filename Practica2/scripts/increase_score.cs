using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increase_score : MonoBehaviour {
    static int score = 0;

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Cube Player") {
            score++;
            Debug.Log("Score: " + score);
        }
    }
}

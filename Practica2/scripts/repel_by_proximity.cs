using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repel_by_proximity : MonoBehaviour {
    Rigidbody rigid_body;
    GameObject player;

    public float force_multiplier = 250f;
    public float threshold = 10f;

    void Awake() {
        rigid_body = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Cube Player");
    }

    void FixedUpdate()  {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < threshold) {
            Vector3 force_direction = Vector3.Normalize(transform.position - player.transform.position);
            rigid_body.AddForce(force_direction * (1 - dist/threshold) * force_multiplier);
        }
    }
}
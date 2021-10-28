using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repel_on_space : MonoBehaviour {
    Rigidbody rigid_body;
    GameObject player;
    public float force_multiplier = 500f;
    public float threshold = 20f;

    void Awake() {
        rigid_body = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Cube Player");
    }

    void FixedUpdate()  {
       if (Input.GetKey("space")) {
            float dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist < threshold) {
                Vector3 force_direction = Vector3.Normalize(transform.position - player.transform.position);
                rigid_body.AddForce(force_direction * (1 - dist/threshold) * force_multiplier);
            }
       }
    }
}

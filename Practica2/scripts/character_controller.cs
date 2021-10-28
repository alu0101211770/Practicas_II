using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_controller : MonoBehaviour {
    Rigidbody rigidBody;
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";

    void Awake() {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        float translation = Input.GetAxis(verticalAxis) * speed;
        float rotation = Input.GetAxis(horizontalAxis) * rotationSpeed;

        Vector3 deltaPosition = transform.TransformDirection(translation * Vector3.forward * Time.fixedDeltaTime);
        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * rotation * Time.fixedDeltaTime);     

        rigidBody.MovePosition(transform.position + deltaPosition);

        rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
    }
}

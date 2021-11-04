using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float rotationSpeed = 100;

    void FixedUpdate()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        body.MovePosition(body.position + transform.TransformDirection(new Vector3(
            Input.GetAxis("X") * speed * Time.fixedDeltaTime,
            0,
            Input.GetAxis("Z") * speed * Time.fixedDeltaTime
        ))); 
        body.MoveRotation(body.rotation * Quaternion.Euler(new Vector3(
            0,
            Input.GetAxis("Y-Rotation") * rotationSpeed * Time.fixedDeltaTime,
            0
        )));
    }
}

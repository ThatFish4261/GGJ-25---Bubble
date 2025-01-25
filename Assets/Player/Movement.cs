using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector2 horizontalInput;

    Rigidbody rb;

    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 11f;

    void Start (){
        rb = GetComponentInChildren<Rigidbody>();
    }

    void Update () {
        Vector3 horizontalVelocity = (Vector3.right * horizontalInput.x + Vector3.forward * horizontalInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);

        transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
    }

    public void RecieveInput(Vector2 input){
        horizontalInput = input;
        print(horizontalInput);
    }
}

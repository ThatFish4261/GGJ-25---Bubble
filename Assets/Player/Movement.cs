using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector2 horizontalInput;

    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 11f;

    void Update () {
        Vector3 horizontalVelocity = (Vector3.right * horizontalInput.x + Vector3.forward * horizontalInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);
    }

    public void RecieveInput(Vector2 input){
        horizontalInput = input;
        print(horizontalInput);
    }
}

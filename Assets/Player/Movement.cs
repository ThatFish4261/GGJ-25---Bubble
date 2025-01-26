using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector2 horizontalInput;

    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 11f;

    [SerializeField] Transform playerModel;

    MainManager mainManager;

    [SerializeField] Animator animator;

    [SerializeField] AudioClip footstepSound;

    void Start(){
        mainManager = FindAnyObjectByType<MainManager>();
        animator = GetComponentInChildren<Animator>();
        AudioSource audio = GetComponent<AudioSource>();
    }

    void Update() {

        Vector3 horizontalVelocity = (Vector3.right * horizontalInput.x + Vector3.forward * horizontalInput.y) * speed;
        
        animator.speed = 0f;

        controller.Move(horizontalVelocity * Time.deltaTime);

        if (horizontalVelocity.magnitude > 0.1f) {
            animator.speed = 2f;
            Quaternion targetRotation = Quaternion.LookRotation(horizontalVelocity);
            playerModel.rotation = Quaternion.Slerp(playerModel.rotation, targetRotation, Time.deltaTime * 10f);
        }

        if (mainManager.livesRemaining < 0){
            mainManager.GameOver();
        }
    }

    public void RecieveInput(Vector2 input){
        horizontalInput = input;
        print(horizontalInput);
    }
}

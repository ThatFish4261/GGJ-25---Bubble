using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] Movement movement;

    PlayerControls controls;
    PlayerControls.GroundMovementActions groundMovement;

    Vector2 horizontalInput;

    void Awake () {
        controls = new PlayerControls();
        groundMovement = controls.GroundMovement;

        //groundMovement.[action].performed += context => do something;
        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
    }

    void Update(){
        movement.RecieveInput(horizontalInput);
    }

    void OnEnable(){
        controls.Enable();
    }

    void OnDisable(){
        controls.Disable();
    }
}

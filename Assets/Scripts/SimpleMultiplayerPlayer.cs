    using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;

public class SimpleMultiplayerPlayer : MonoBehaviour
{

    private const float MOVEMENT_MODIFIER = 0.05f;
    private Vector2 movement, lookDirection;
    private Gamepad gamepad;

    private void Start() {
        gamepad = Gamepad.current;
    }

    public void Update() {
        transform.position = new Vector3(
            transform.position.x + movement.x * MOVEMENT_MODIFIER,
            transform.position.y,
            transform.position.z + movement.y * MOVEMENT_MODIFIER
        );
        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x + lookDirection.y * -MOVEMENT_MODIFIER, 
            transform.eulerAngles.y + lookDirection.x * MOVEMENT_MODIFIER,
            transform.eulerAngles.z
        );
    }

    public void OnMovementDPad() {
        movement = gamepad.dpad.ReadValue();
    }

    public void OnMovementAnalog() {
        movement = gamepad.leftStick.ReadValue();
    }

    public void OnLookAnalog() {
        //movement = gamepad.leftStick.ReadValue();
        lookDirection = gamepad.rightStick.ReadValue();
    }

}

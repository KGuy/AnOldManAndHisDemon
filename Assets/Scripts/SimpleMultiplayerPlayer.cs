using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;

public class SimpleMultiplayerPlayer : MonoBehaviour
{

    private const float MOVEMENT_MODIFIER = 0.5f, LOOK_MODIFIER = 2;
    private Vector2 movement, lookDirection;
    private Gamepad gamepad;
    private Camera camera;
    private GameMasterController controller;

    private void Start() {
        gamepad = Gamepad.current;
        camera = GetComponent<Camera>();

        GameObject go = GameObject.FindGameObjectWithTag(TagNames.GAME_MASTER);
        controller = go.GetComponent<GameMasterController>();
        Vector3 startPosition = controller.getStartPosition();
        print(startPosition);
        gameObject.transform.position = startPosition;
    }

    public void FixedUpdate() {
        Vector3 modifiedForward = new Vector3(camera.transform.forward.x, 0, camera.transform.forward.z);
        transform.position = transform.position + modifiedForward * movement.y * MOVEMENT_MODIFIER + camera.transform.right * movement.x * MOVEMENT_MODIFIER;

        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x - lookDirection.y * LOOK_MODIFIER, 
            transform.eulerAngles.y + lookDirection.x * LOOK_MODIFIER,
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
        lookDirection = gamepad.rightStick.ReadValue();
    }

}

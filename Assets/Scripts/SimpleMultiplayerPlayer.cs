using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;

public class SimpleMultiplayerPlayer : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private const float MOVEMENT_MODIFIER = 30, LOOK_MODIFIER = 2;
    private Vector2 movement, lookDirection;
    [SerializeField]
    private Gamepad gamepad;
    private Camera camera;
    private GameMasterController controller;
    private Rigidbody rb;
    private PlayerInfo playerInfo;

    // Skurðkota START
    [SerializeField]
    private PlayerInput playerInput;
    private int playerIndex;
    private bool isControlSchemeKeyboardAndMouse;
    private InputAction m_moveAction;
    // Skurðkota END

    private void Start() {
        // Skurðkota START
        playerInput = gameObject.GetComponent<PlayerInput>();

        if (playerInput != null)
        {
            playerIndex = playerInput.playerIndex;
            Debug.Log($"Player#{playerIndex}'s currentControlScheme is {playerInput.currentControlScheme}");

            if (playerInput.currentControlScheme == "Keyboard&Mouse")
            {
                isControlSchemeKeyboardAndMouse = true;
                m_moveAction = playerInput.actions["MovementDPad"];
                //m_move = m_moveAction.ReadValue<Vector2>();
            }
        }
        // Skurðkota END


        rb = GetComponent<Rigidbody>();

        gamepad = Gamepad.current;
        camera = GetComponent<Camera>();

        GameObject go = GameObject.FindGameObjectWithTag(TagNames.GAME_MASTER);
        controller = go.GetComponent<GameMasterController>();
        playerInfo = controller.getStartPosition();

        Vector3 startPosition = playerInfo.startPosition;

        spriteRenderer.sprite = playerInfo.sprite;

        gameObject.transform.position = startPosition;
    }

    public void FixedUpdate() {
        Vector3 modifiedForward = new Vector3(camera.transform.forward.x, 0, camera.transform.forward.z);

        Vector3 updown = new Vector3(0, rb.velocity.y, 0);

        rb.velocity = updown + modifiedForward * movement.y * MOVEMENT_MODIFIER + camera.transform.right * movement.x * MOVEMENT_MODIFIER;

        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x - lookDirection.y * LOOK_MODIFIER,
            transform.eulerAngles.y + lookDirection.x * LOOK_MODIFIER,
            transform.eulerAngles.z
        );
    }
    // Skurðkota START
    //public void OnMovementDPad() => movement = gamepad.dpad.ReadValue();
    //Switcharoo!
    public void OnMovementDPad() => movement = isControlSchemeKeyboardAndMouse ? m_moveAction.ReadValue<Vector2>() : gamepad.dpad.ReadValue();
    // Skurðkota END
    public void OnMovementAnalog() => movement = gamepad.leftStick.ReadValue();

    public void OnLookAnalog() => lookDirection = gamepad.rightStick.ReadValue();

}

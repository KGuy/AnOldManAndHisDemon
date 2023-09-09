using System;
using UnityEngine;

public class InputController : MonoBehaviour {

    public bool debug;

    ITakesInput controller;

    readonly float scrollBuffer = 0.05f, movementBuffer = 0.1f, holdForTime = .25f;

    bool wDown, sDown, isCapslockOn;
    float sTimer;

    private void Start() {
        controller = gameObject.GetComponent<ITakesInput>();
        if (debug) print(controller);
    }

    void Update() {
        bool axisVerticalOnDown = Input.GetButtonDown("Vertical");
        bool axisVerticalWhileDown = Input.GetButton("Vertical");

        print(controller);
        if (controller != null) {



            //float verticalMovement = Input.GetAxis("Vertical");
            //if (verticalMovement < -movementBuffer || verticalMovement > movementBuffer) {
            //    if (debug)
            //        print("MoveVertical: " + verticalMovement);
            //    controller.MoveForward(verticalMovement);   // S and W
            //}

            //float axisVertical = Input.GetAxisRaw("Vertical");
            //if (axisVerticalOnDown && axisVertical > 0) controller.OnWDown();
            //wDown = WDown();// axisVerticalWhileDown && axisVertical > 0;
            //if (wDown) controller.WhileWDown();

            //if (axisVerticalOnDown && axisVertical < 0) {
            //    controller.OnSDown();
            //    sTimer = Time.time;
            //}
            //if (!axisVerticalWhileDown || axisVertical > 0) ResetSTimer();
            //if (sTimer != 0 && Time.time - sTimer > holdForTime) {
            //    if (debug) print("OnSHeldDown");
            //    controller.OnSHeldDown();
            //    ResetSTimer();
            //}

            //sDown = Input.GetButton("Vertical") && axisVertical < 0;
            //if (sDown) {
            //    if (debug) print("WhileSDown");
            //    controller.WhileSDown();
            //}
            //float horizontalMovement = Input.GetAxis("Horizontal");
            //if (horizontalMovement < -movementBuffer || horizontalMovement > movementBuffer) {
            //    if (debug) print("MoveHorizontal: " + horizontalMovement);
            //    controller.MoveSideways(horizontalMovement);   // A and D
            //}

            //if (Input.GetButtonDown("Jump")) {
            //    if (sDown) { 
            //    if (debug) print("JumpAndSDown");
            //        controller.JumpAndSDown(); 
            //    } else {
            //        if (debug) print("Jump");
            //        controller.Jump(); 
            //    }
            //}

            //float mouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");
            //if (mouseScrollWheel > scrollBuffer) controller.ScrollUp();
            //if (mouseScrollWheel < -scrollBuffer) controller.ScrollDown();

            //string leftClick = "Fire1";
            //string rightClick = "Fire2";
            //if (Input.GetButtonDown(leftClick)) controller.LeftClick();
            //if (Input.GetButtonDown(rightClick)) controller.RightClick();
            //if (Input.GetButtonUp(leftClick)) controller.LeftRelease();
            //if (Input.GetButtonUp(rightClick)) controller.RightRelease();

            //if (Input.GetKey(KeyCode.LeftControl)) controller.OnCtrlDown();
        }
        if (Input.GetKeyDown(KeyCode.CapsLock)) isCapslockOn = !isCapslockOn;
    }

    private void OnGUI()
    {
        Event e = Event.current;

        //below I am checking if a key is pressed,
        //then if the key is a character
        //and then remove the shift causing inversion of problem
        if (e.isKey & !GetButtonDownJump() & e.character != char.MinValue & !e.shift)
        {
            string UpperChar = e.character.ToString().ToUpper();
            isCapslockOn = UpperChar == e.character.ToString();
        }
    }

    //public static Camera GetMainCamera() => Camera.main;
    //public static Vector2 GetMousePixelPosition() => Input.mousePosition;
    //public static Vector2 GetMousePosition2D() => GetMousePosition3D();
    //public static Vector3 GetMousePosition3D() => GetMainCamera().ScreenToWorldPoint(GetMousePixelPosition());
    //public static float GetRawHorizontalSpeed() => Input.GetAxisRaw("Horizontal");
    //public static bool WDown() {
    //    bool axisVerticalWhileDown = Input.GetButton("Vertical");
    //    float axisVertical = Input.GetAxisRaw("Vertical");
    //    return axisVerticalWhileDown && axisVertical > 0;
    //}
    //public bool IsWDown() => wDown;
    //public bool IsSDown() => sDown;
    //public bool IsCapsLockOn() => isCapslockOn;
    //public static bool IsLeftMouseDown() => Input.GetButton("Fire1");
    //public static bool IsRightMouseDown() => Input.GetButton("Fire2");

    public static bool GetButtonJump() => Input.GetButton("Jump");
    public static bool GetButtonDownJump() => Input.GetButtonDown("Jump");
    //public static bool LeftShift_IsDown() => Input.GetKey(KeyCode.LeftShift);
    //public static bool LeftControl_IsDown() => Input.GetKey(KeyCode.LeftControl);
    //public static bool LeftControl_OnDown() => Input.GetKeyDown(KeyCode.LeftControl);
    //public static bool LeftControl_OnUp() => Input.GetKeyUp(KeyCode.LeftControl);
    //void ResetSTimer() => sTimer = 0;
}

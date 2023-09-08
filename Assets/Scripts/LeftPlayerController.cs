using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPlayerController : MonoBehaviour, ITakesInput {

    public float movementModifier;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void Jump() {
        throw new System.NotImplementedException();
    }

    public void JumpAndSDown() {
        throw new System.NotImplementedException();
    }

    public void LeftClick() {
        throw new System.NotImplementedException();
    }

    public void LeftRelease() {
        throw new System.NotImplementedException();
    }

    public void MoveSideways(float movement) {
        transform.Translate(new Vector3(movement * movementModifier, 0, 0));
    }

    public void MoveForward(float movement) {
        print(1);
        transform.Translate(new Vector3(0, 0, movement * movementModifier));
    }

    public void OnCtrlDown() {
        throw new System.NotImplementedException();
    }

    public void OnSDown() {
        throw new System.NotImplementedException();
    }

    public void OnSHeldDown() {
        throw new System.NotImplementedException();
    }

    public void OnWDown() {
        throw new System.NotImplementedException();
    }

    public void RightClick() {
        throw new System.NotImplementedException();
    }

    public void RightRelease() {
        throw new System.NotImplementedException();
    }

    public void ScrollDown() {
        throw new System.NotImplementedException();
    }

    public void ScrollUp() {
        throw new System.NotImplementedException();
    }

    public void WhileSDown() {
        throw new System.NotImplementedException();
    }

    public void WhileWDown() {
        throw new System.NotImplementedException();
    }
}

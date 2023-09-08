public interface ITakesInput {

    void Move(float movement);
    void Jump();
    void OnWDown();
    void OnSDown();
    void OnCtrlDown();
    void WhileSDown();
    void WhileWDown();
    void OnSHeldDown();
    void ScrollUp();
    void ScrollDown();
    void LeftClick();
    void RightClick();
    void LeftRelease();
    void RightRelease();
    void JumpAndSDown();
}

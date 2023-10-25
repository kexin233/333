using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyState : MonoBehaviour
{
    public static keyState  instance;

    public KeyCode Right { get; private set; } = KeyCode.D;
    public KeyCode Left { get; private set; } = KeyCode.A;
    public KeyCode Jump { get; private set; } =KeyCode.Space;
    public KeyCode Up { get; private set; }=KeyCode.W;
    public KeyCode Down { get; private set; }=KeyCode.S;
    public KeyCode Sprint { get; private set; } = KeyCode.LeftControl;



    public bool IsSprint {  get; private set; }
    public bool IsLongJump { get; private set; }
    public bool IsJump { get; private set; }

    public int Horizontal {  get; private set; }
    public int Vertical { get; private set; }
    private void Awake() => instance = this;
    private void Update()
    {
        IsJump=Input.GetKeyDown(Jump);
        IsLongJump = Input.GetKey(Jump);
        IsSprint = Input.GetKey(Sprint);
        TheHorizontal();
        TheVertical();
    }
    private void TheHorizontal()
    {
        if (Input.GetKey(Right)) { Horizontal = 1; }
        else if (Input.GetKey(Left)) {  Horizontal = -1; }
        else { Horizontal = 0; }
    }
    private void TheVertical()
    {
        if (Input.GetKey(Down)) { Vertical = -1; }
        else if (Input.GetKey(Up)) {Vertical= 1;  }
        else { Vertical = 0; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inWhere : MonoBehaviour
{
    public static inWhere instance;
    Transform groundCheck;      //脚底检测点，判断是否接触地面
    Transform rightCheck;
    LayerMask ground;        //地面图层
    LayerMask JustGround;
    public int a;      //判断是否发生特殊事件
    public bool JustInGround {  get; private set; }
    public bool inWall { get; private set; }
    public bool InGround {  get; private set; }
    
    private void Awake() => instance = this;

    private void Start()
    {
        groundCheck = Check.Instance.groundCheck;
        rightCheck = Check.Instance.rightCheck;
        ground = Check.Instance.ground;
        JustGround = Check.Instance.JustGround;
    }
    void Update()
    {
        justinground();
        inwall();
    }
    void justinground()
    {
        JustInGround = Physics2D.OverlapCircle(groundCheck.position, 0.8f, ground);     //判断是否在地面
        if (!JustInGround)
        {
            JustInGround = Physics2D.OverlapCircle(groundCheck.position, 0.8f, JustGround);
        }
        if(a==1)
        {
            JustInGround = true;
            a= 0;
        }
    }
    void inwall()
    {
        inWall = Physics2D.OverlapCircle(rightCheck.position, 0.1f, ground);
    }
    public void someThing()
    {
        a = 1;
    }
   /* void inground()
    {
        JustInGround = Physics2D.OverlapCircle(groundCheck.position, 0.8f, ground);
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public static Jump instance;

    private int _jumpCount;
    private float _fallforce;
    private float _upforce;
    private float _upSpeed;
    private bool _inGround;
    private bool _inwall;
    Rigidbody2D rb;
    private bool isJump;
    private bool isLongJump;
    
    public int JumpCount { get; set; }

    private void Awake()
    {
        instance= this;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        _jumpCount = state.instance.jumpCount;
        _inwall = inWhere.instance.inWall;
        _upSpeed = state.instance.UpSpeed;
        _inGround =inWhere.instance.JustInGround;
        isLongJump = keyState.instance.IsLongJump;
        isJump = keyState.instance.IsJump;
        _fallforce = state.instance.DownForce;
        _upforce = state.instance.UpForce;

        jumpCountChange();
        toJump();
    }
    private void toJump()
    {
        if (isJump && JumpCount > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, _upSpeed);
            JumpCount--;
            player.instance.PPS();
            if (JumpCount == _jumpCount) { JumpCount--; }
        }
        if (rb.velocity.y > 0 && !isLongJump)
        {
            rb.gravityScale = _upforce;      //下落与跳跃时重力不同
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = _fallforce;
        }
        else if (isLongJump && rb.velocity.y > 0) { rb.gravityScale = _upforce*5/8; }
    }

    private void jumpCountChange()
    {
        if((_inGround||_inwall)&&!isLongJump)
        {
            JumpCount = _jumpCount;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    Animator _anim;
    private int _moveX,_jumpCound,_JumpCound;
    private bool _inGround, _inWall;

    Rigidbody2D rb;
    void Start()
    {
        _anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _moveX = keyState.instance.Horizontal;
        _JumpCound = state.instance.jumpCount;
        _jumpCound = Jump.instance.JumpCount;
        _inGround=inWhere.instance.JustInGround;
        _inWall=inWhere.instance.inWall;
        animChange();
        
    }
    private void animChange()
    {
        int a = -1;
        if (_inGround && _moveX == 0)
        {
            a = 0;
        }
        if (_inGround && _moveX != 0)
        {
            a = 1;
        }
        if (!_inGround && rb.velocity.y > 0)
        {
            a = 2;
        }
        if (!_inGround && rb.velocity.y < 0)
        {
            a = 3;
        }
        if (!_inGround && _jumpCound == 0 && _JumpCound > 1)
        {
            a = 4;
        }
        _anim.SetBool("wall", _inWall && !_inGround);
        _anim.SetInteger("state", a);
    }
}

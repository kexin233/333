using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    private bool _inWall;
    private bool _isJump;
    private bool _isJumping;
    private bool _turn ;
    private Rigidbody2D rb;
    private float _speed;
    private float _wallUpSpeed;//_wallUpSpeed
    private float _wallFallSpeed;
    Animator _anim;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _wallFallSpeed = state.instance.WallDownSpeed;
        _wallUpSpeed = state.instance.WallUpSpeed;
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        _inWall = inWhere.instance.inWall;
        _isJump = keyState.instance.IsJump;
        _isJumping = keyState.instance.IsLongJump;
        _turn = Move.instance.Turn;
        _speed = state.instance.Speed;
        if (!sprint.instance.a)
        { theWall(); }
    }
    private void theWall()
    {
        //墙面跳跃
        if (_inWall && _isJump)
        {
            int x = 1;
            if (!_turn) x = 1;
            else x = -1;
            rb.velocity = new Vector2(_speed * x*2, rb.velocity.y);
            /*rb.velocity=Vector2.Lerp(rb.velocity,(new Vector2(_speed*x,rb.velocity.y)),.5f*Time.deltaTime);*/

        }
        //墙面攀爬
        if (_inWall && Input.GetKey(KeyCode.W))
        {
            rb.velocity = Vector2.up * _wallUpSpeed;
            rb.velocity = Vector2.up * _wallUpSpeed;
            _anim.SetBool("wallMove", true);
        }
        else if ((_inWall && Input.GetKey(KeyCode.S)))
        {
            _anim.SetBool("wallMove", true);
            rb.velocity = Vector2.down * _wallFallSpeed;
        }
        //在墙面则静止
        
        else if (_inWall && !_isJumping)
        {
            _anim.SetBool("wallMove", false);
            rb.gravityScale = 0;
            float TheSlide=state.instance.Slide;
            rb.velocity = new Vector2(0, -TheSlide);
        }
        //不在墙面则恢复重力
        else
        {
            rb.gravityScale =state.instance.G;
           /* upforce = upForce;
            fallforce = fallForce;*/
            /*_wallUpSpeed = upspeed;*/
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class player : MonoBehaviour
{
    public static player instance;
    Rigidbody2D rb;         //即玩家控制的角色
    //灰尘
    public ParticleSystem playerPS;     //粒子效果组件
    //复活
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();        //将rb赋予游戏角色（获取游戏角色的刚体组件
/*        rb.position = relive.transform.position;*/
    }
    /*    private void Inwall()           //在墙上
        {
            inrightwall = Physics2D.OverlapCircle(rightCheck.position, 0.1f, ground);

        }
        private void Ingrounded()       //在地面以及跳跃状态刷新
        {

            inGround = Physics2D.OverlapCircle(groundCheck.position, 0.8f, ground);     //判断是否在地面
            if (!inGround)
            {
                inGround = Physics2D.OverlapCircle(groundCheck.position, 0.8f, justGround);
            }


        }*/
    /*private void Check()
    {
        Collider2D foot =Physics2D.OverlapBox(groundCheck.position,new Vector3(0.6f,1.2f,0),0f,LayerMask.GetMask(""))       //关于射线，（原点，长宽，角度（0），图层）
    }*/
    /*    private void inMove()           //移动函数
        {
            if(!inrightwall||inGround) 
            { 
                rb.velocity=new Vector2(moveX*speed,rb.velocity.y);     //关键函数
                if (moveX > 0 && !Turn)             //符合条件时，玩家模型左右翻转
                {
                    Flip();
                }
                if (moveX < 0 && Turn)
                {
                    Flip();
                }
            }

        } */
  /*  private void Jumping()          //跳跃函数
    {
        if (Jump && jumpCound > 0)          //按下空格且仍有跳跃次数时，给一个向上的速度
        {
            rb.AddForce = Vector2.up * upspeed;
            if (jumpCound == JumpCound)
            {
                rb.velocity = new Vector2(rb.velocity.x, upSpeed);
            }
            rb.AddForce(upSpeed * Vector2.up, ForceMode2D.Impulse);
            rb.gravityScale = 0;
            if (rb.velocity.y < 0)
            {
                rb.velocity = 0 * Vector2.up;
            }
            if (jumpCound < JumpCound)
            {
                rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
            }
            jumpCound--;
            PPS();          //跳跃时，生成灰尘
        }
        if (rb.velocity.y > 0 && !longJump)
        {
            rb.gravityScale = upforce;      //下落与跳跃时重力不同
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallforce;
        }
        else if (longJump && rb.velocity.y > 0) { rb.gravityScale = 0; }
    }*/
    /*    private void Flip()         //角色左右翻转函数
        {
            Turn = !Turn;
            Vector3 playerScale=transform.localScale;
            playerScale.x *= -1;
            transform.localScale = playerScale;
            PPS();
        }*/
    public void PPS()      //生成灰尘函数
    {
        playerPS.Play();
    }
/*    void animationChange()                      //动画相关
    {
        int a = -1;
        if (inGround&&moveX==0)
        {
            a = 0;
        }
        if (inGround && moveX != 0)
        {
            a = 1;
        }
        if (!inGround && rb.velocity.y > 0)
        {
            a = 2;
        }
        if(!inGround && rb.velocity.y < 0)
        {
            a = 3;
        }
        if (!inGround && jumpCound == 0 && JumpCound > 1)
        {
            a = 4;
        }
        anim.SetBool("wall", inwall&&!inGround);
        anim.SetInteger("state", a);
    }*/
   /* void die()          //死亡
    {
        Destroy(playerPS, 1f);      //关闭粒子效果
        rb.bodyType = RigidbodyType2D.Static;
*//*        anim.SetTrigger("death");*//*
    }*/
    /*private void reStart()      //重载
    {
        Destroy(rb, 1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/
    /*private void OnCollisionEnter2D(Collision2D collision)      //发生碰撞
    {
        if (collision.gameObject.tag == "die")                  
        {
            die();
        }
        *//*if(collision.gameObject.tag == "mouster")
        {
            
            if(Physics2D.OverlapCircle(collision.transform.position, 2f,playerfollLayer))
            {
                if (collision.gameObject.TryGetComponent(out mushroom mou))
                {
                    mou.toDie();
                }
                *//*Destroy(collision.gameObject);*//*
                rb.velocity = Vector2.up * upSpeed;
            }
            else
            {
                die();
            }
        }*//*
    }*/


  /*  private void wallJump()             //墙壁相关
    {


        //墙面跳跃
        if (inwall && Jump)
        {
            int x = 1;
            if (!Turn) x = 1;
            else x = -1;
            rb.velocity = new Vector2(speed * x, rb.velocity.y);

        }
        //墙面攀爬
        if (inwall && Input.GetKey(KeyCode.W))
        {
            rb.velocity = Vector2.up * wallupspeed;
            rb.velocity = Vector2.up * upSpeed;
            anim.SetBool("wallMove", true);
        }
        else if ((inwall && Input.GetKey(KeyCode.S)))
        {
            anim.SetBool("wallMove", true);
            rb.velocity = Vector2.down * wallfallspeed;
        }
        //在墙面则静止
        else if (inwall && !longJump)
        {
            anim.SetBool("wallMove", false);
            rb.gravityScale = 0;
            G = 0; upforce = 0; fallforce = 0;
            rb.velocity = new Vector2(0, 0);
        }
        //不在墙面则恢复重力
        else
        {
            rb.gravityScale = 9.8f;
            upforce = upForce;
            fallforce = fallForce;
            upSpeed = upspeed;
            G = g;
        }
        (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
    }*/
    }

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
    Rigidbody2D rb;         //����ҿ��ƵĽ�ɫ
    //�ҳ�
    public ParticleSystem playerPS;     //����Ч�����
    //����
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();        //��rb������Ϸ��ɫ����ȡ��Ϸ��ɫ�ĸ������
/*        rb.position = relive.transform.position;*/
    }
    /*    private void Inwall()           //��ǽ��
        {
            inrightwall = Physics2D.OverlapCircle(rightCheck.position, 0.1f, ground);

        }
        private void Ingrounded()       //�ڵ����Լ���Ծ״̬ˢ��
        {

            inGround = Physics2D.OverlapCircle(groundCheck.position, 0.8f, ground);     //�ж��Ƿ��ڵ���
            if (!inGround)
            {
                inGround = Physics2D.OverlapCircle(groundCheck.position, 0.8f, justGround);
            }


        }*/
    /*private void Check()
    {
        Collider2D foot =Physics2D.OverlapBox(groundCheck.position,new Vector3(0.6f,1.2f,0),0f,LayerMask.GetMask(""))       //�������ߣ���ԭ�㣬�����Ƕȣ�0����ͼ�㣩
    }*/
    /*    private void inMove()           //�ƶ�����
        {
            if(!inrightwall||inGround) 
            { 
                rb.velocity=new Vector2(moveX*speed,rb.velocity.y);     //�ؼ�����
                if (moveX > 0 && !Turn)             //��������ʱ�����ģ�����ҷ�ת
                {
                    Flip();
                }
                if (moveX < 0 && Turn)
                {
                    Flip();
                }
            }

        } */
  /*  private void Jumping()          //��Ծ����
    {
        if (Jump && jumpCound > 0)          //���¿ո���������Ծ����ʱ����һ�����ϵ��ٶ�
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
            PPS();          //��Ծʱ�����ɻҳ�
        }
        if (rb.velocity.y > 0 && !longJump)
        {
            rb.gravityScale = upforce;      //��������Ծʱ������ͬ
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallforce;
        }
        else if (longJump && rb.velocity.y > 0) { rb.gravityScale = 0; }
    }*/
    /*    private void Flip()         //��ɫ���ҷ�ת����
        {
            Turn = !Turn;
            Vector3 playerScale=transform.localScale;
            playerScale.x *= -1;
            transform.localScale = playerScale;
            PPS();
        }*/
    public void PPS()      //���ɻҳ�����
    {
        playerPS.Play();
    }
/*    void animationChange()                      //�������
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
   /* void die()          //����
    {
        Destroy(playerPS, 1f);      //�ر�����Ч��
        rb.bodyType = RigidbodyType2D.Static;
*//*        anim.SetTrigger("death");*//*
    }*/
    /*private void reStart()      //����
    {
        Destroy(rb, 1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/
    /*private void OnCollisionEnter2D(Collision2D collision)      //������ײ
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


  /*  private void wallJump()             //ǽ�����
    {


        //ǽ����Ծ
        if (inwall && Jump)
        {
            int x = 1;
            if (!Turn) x = 1;
            else x = -1;
            rb.velocity = new Vector2(speed * x, rb.velocity.y);

        }
        //ǽ������
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
        //��ǽ����ֹ
        else if (inwall && !longJump)
        {
            anim.SetBool("wallMove", false);
            rb.gravityScale = 0;
            G = 0; upforce = 0; fallforce = 0;
            rb.velocity = new Vector2(0, 0);
        }
        //����ǽ����ָ�����
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

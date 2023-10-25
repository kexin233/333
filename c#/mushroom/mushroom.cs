using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class mushroom : MonoBehaviour
{

    public static mushroom instance;

    private reLiveGround myRelive;/*  public Unit Therelive;*/
    private GameObject playerOBJ;
    int pointNum = 1;         //
    [SerializeField] float speed = 1;     //速度
    [SerializeField] GameObject[] points;       //目标点的引用，设置
    [SerializeField] GameObject[] check;        //标记左右两边的点
    [SerializeField] GameObject myCheck;
    [SerializeField] int[] turnNum;         //转弯的点数
    bool isdie=false;

    Rigidbody2D rb;
    [SerializeField] Animator ani;
    [SerializeField] LayerMask ground;
    bool Turn = true;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
/*        OBJ=GetComponent<GameObject>();*/
        playerOBJ = GameObject.FindWithTag("Player");
        myRelive = playerOBJ.GetComponent<reLiveGround>();
        ani=GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
/*        myRelive.setMonster(OBJ);*/
       /* reLiveGround.instance.setMonster(gameObject);*/
    }

    void Update()
    {
        /*Vector2 a;
        a= transform.position;
        a = Vector2.MoveTowards(a, points[pointNum].transform.position,Time.deltaTime*speed);//移动函数，从A到B用C
                                                                                             //的速度。。transform.p
                                                                                       //osition是当前位置
        transform.position=a;*/
        isdie = reLiveGround.youDie;
        Move();
        
        /* if (isdie){
             relive();
         }*/
    }
    private void Move()
    {
        if (Physics2D.OverlapCircle(myCheck.transform.position, 0.1f, ground))
        {
            Flip();
            pointNum++;
            if (pointNum >= points.Length)
            {
                pointNum = 0;
            }
        }
        if (!isdie)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[pointNum].transform.position, speed * Time.deltaTime);//移动函数，从A到B用C
                                                                                                                                      //的速度。。transform.p
                                                                                                                                      //osition是当前位置
            for (int i = 0; i < check.Length; i++)
            {
                if (Vector2.Distance(check[i].transform.position, points[pointNum].transform.position) < 0.3)
                {

                    for (int j = 0; j < turnNum.Length; j++)
                    {
                        if (turnNum[j] == pointNum)
                        {
                            Flip();
                        }
                    }
                    pointNum++;
                    if (pointNum >= points.Length)
                    {
                        pointNum = 0;
                    }
                }
            }
        }
    }

    private void Flip()         //角色左右翻转函数
    {
        Turn = !Turn;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    public void toDie()
    {
        isdie= true;
        ani.SetTrigger("die");
    }

    public void theDestroy()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.gameObject.tag == "follcheck")
            {
                if (collision.gameObject.TryGetComponent(out inWhere inw))
                {
                    inw.a = 1;
                }
                toDie();

            }
            /* if (collision.gameObject.layer ==3 )*/
            
        }
    }
    public void relive()
    {
        gameObject.SetActive (true);
    }


    /* (Collision2D collision)      //发生碰撞
*/

}

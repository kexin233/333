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
    [SerializeField] float speed = 1;     //�ٶ�
    [SerializeField] GameObject[] points;       //Ŀ�������ã�����
    [SerializeField] GameObject[] check;        //����������ߵĵ�
    [SerializeField] GameObject myCheck;
    [SerializeField] int[] turnNum;         //ת��ĵ���
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
        a = Vector2.MoveTowards(a, points[pointNum].transform.position,Time.deltaTime*speed);//�ƶ���������A��B��C
                                                                                             //���ٶȡ���transform.p
                                                                                       //osition�ǵ�ǰλ��
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
            transform.position = Vector2.MoveTowards(transform.position, points[pointNum].transform.position, speed * Time.deltaTime);//�ƶ���������A��B��C
                                                                                                                                      //���ٶȡ���transform.p
                                                                                                                                      //osition�ǵ�ǰλ��
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

    private void Flip()         //��ɫ���ҷ�ת����
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


    /* (Collision2D collision)      //������ײ
*/

}

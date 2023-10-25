using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    public static Move instance;
    Rigidbody2D rb;
    [SerializeField] Unit playerState;
    /*private Unit playerObj;*/

    public bool insprint { get; set; }=false;

    private bool inGround;
    private bool inrightwall;
    public float moveX {  get; private set; }
    /*   [Range(0f, 100f)]*/
    private float speed;
    public bool Turn { get; private set; } = true;
    private void Awake() { instance = this; }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        /*playerObj = Instantiate(playerState);*/        

    }
    private void Update()
    {
        moveX = keyState.instance.Horizontal;       //aʱ����-1��dʱ����1����������0
        inGround = inWhere.instance.JustInGround;
        inrightwall = inWhere.instance.inWall;
        speed = state.instance.Speed;
    }
    private void FixedUpdate()
    {
        inMove();
    }
    public void inMove()           //�ƶ�����
    {
        
        if (!insprint&&(!inrightwall || inGround))
        {
            print(moveX);
            if (inGround)
            {
                rb.velocity = new Vector2(moveX * speed, rb.velocity.y);     //�ؼ�����
            }
            else if(moveX!=0)
            {
                rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
            }
            else if (moveX == 0)
            {
                rb.velocity = new Vector2(rb.velocity.x*3/4, rb.velocity.y);
            }
            if (moveX > 0 && !Turn)             //��������ʱ�����ģ�����ҷ�ת
            {
                Flip();
            }
            if (moveX < 0 && Turn)
            {
                Flip();
            }
        }

    }
    private void Flip()         //��ɫ���ҷ�ת����
    {
        Turn = !Turn;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
        player.instance.PPS();
    }
}

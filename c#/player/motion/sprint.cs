using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprint : MonoBehaviour
{
    public static sprint instance;
    private Rigidbody2D rb;
    private bool _isSprint;             //是否冲刺
    private bool _insky;                //是否在空中（目前没用
    bool _inSprint=false;               //是否正在冲刺
    [SerializeField] float _endTime;    //冲刺一共时间
    float _time;                        //记录冲刺时间（与上面那个配合
    public bool a;                      //判断是否加入冲刺状态（为什么要这样弯弯绕绕的设计。。。
    [SerializeField] float _lineDrag;   //意义不明


    private void Awake() => instance = this;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   //刚体
        a = false;                                          //初始化
        _time = 0;
    }
    void Update()
    {

        _isSprint = keyState.instance.IsSprint;         //感觉没必要
        if (_isSprint && !_inSprint)                    
        {
            a= true;
            player.instance.PPS();
        }               ////按下冲刺同时不在空中时，启用冲刺（a=true）并且启用粒子效果
        if (inWhere.instance.JustInGround || inWhere.instance.inWall)
        {
            _inSprint = false;
        }           //在地上或墙上时使 _inSprint = false;
        if (a )
        {
            rb.drag = _lineDrag;                        //空气阻力
            rb.gravityScale = 0;                     //
            _inSprint = true;                       
            float x, y;
            x = keyState.instance.Horizontal;
            y = keyState.instance.Vertical;
            rb.gravityScale = 0;
            Move.instance.insprint = true;
            rb.velocity = new Vector2(x, y).normalized * state.instance.Speed * 2;
            _time += Time.deltaTime;
            if (_time > _endTime)
            {
                rb.gravityScale = state.instance.G;
                Move.instance.insprint = false;
                _time = 0;
                a= false;
                if (rb.velocity.y > state.instance.UpSpeed)
                {
                    rb.velocity = new Vector2(rb.velocity.x, state.instance.UpSpeed);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprint : MonoBehaviour
{
    public static sprint instance;
    private Rigidbody2D rb;
    private bool _isSprint;             //�Ƿ���
    private bool _insky;                //�Ƿ��ڿ��У�Ŀǰû��
    bool _inSprint=false;               //�Ƿ����ڳ��
    [SerializeField] float _endTime;    //���һ��ʱ��
    float _time;                        //��¼���ʱ�䣨�������Ǹ����
    public bool a;                      //�ж��Ƿ������״̬��ΪʲôҪ�����������Ƶ���ơ�����
    [SerializeField] float _lineDrag;   //���岻��


    private void Awake() => instance = this;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   //����
        a = false;                                          //��ʼ��
        _time = 0;
    }
    void Update()
    {

        _isSprint = keyState.instance.IsSprint;         //�о�û��Ҫ
        if (_isSprint && !_inSprint)                    
        {
            a= true;
            player.instance.PPS();
        }               ////���³��ͬʱ���ڿ���ʱ�����ó�̣�a=true��������������Ч��
        if (inWhere.instance.JustInGround || inWhere.instance.inWall)
        {
            _inSprint = false;
        }           //�ڵ��ϻ�ǽ��ʱʹ _inSprint = false;
        if (a )
        {
            rb.drag = _lineDrag;                        //��������
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public static Check Instance;

    public LayerMask FootLayer; 
    public Transform groundCheck;      //�ŵ׼��㣬�ж��Ƿ�Ӵ�����
    public Transform rightCheck;
    public LayerMask ground;      //����ͼ��
    public LayerMask JustGround;



    private void Awake()
    {
        Instance = this;
    }
}

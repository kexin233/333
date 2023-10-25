using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public static Check Instance;

    public LayerMask FootLayer; 
    public Transform groundCheck;      //脚底检测点，判断是否接触地面
    public Transform rightCheck;
    public LayerMask ground;      //地面图层
    public LayerMask JustGround;



    private void Awake()
    {
        Instance = this;
    }
}

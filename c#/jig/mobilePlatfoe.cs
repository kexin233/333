using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class mobilePlatfoe : MonoBehaviour
{
    int pointNum=1;         //
    [SerializeField] float speed=1;     //速度
    [SerializeField] GameObject[] points;       //目标点的引用，设置
    [SerializeField] GameObject[] check;        //标记左右两边的点
    [SerializeField] int[] flieNum;
    bool Turn = true;
    void Update()
    {
        /*Vector2 a;
        a= transform.position;
        a = Vector2.MoveTowards(a, points[pointNum].transform.position,Time.deltaTime*speed);//移动函数，从A到B用C
                                                                                             //的速度。。transform.p
                                                                                             //osition是当前位置
        transform.position=a;*/
        transform.position = Vector2.MoveTowards(transform.position, points[pointNum].transform.position,speed*Time.deltaTime);//移动函数，从A到B用C
                                                                                                                               //的速度。。transform.p
                                                                                                                               //osition是当前位置
        for (int i = 0; i < check.Length; i++)
        {
            if (Vector2.Distance(check[i].transform.position, points[pointNum].transform.position) < 0.3)
            {
                for (int j = 0; j < flieNum.Length; j++)
                {
                    if (j == pointNum)
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
    private void Flip()         //角色左右翻转函数
    {
        Turn = !Turn;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

}

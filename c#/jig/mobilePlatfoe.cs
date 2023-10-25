using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class mobilePlatfoe : MonoBehaviour
{
    int pointNum=1;         //
    [SerializeField] float speed=1;     //�ٶ�
    [SerializeField] GameObject[] points;       //Ŀ�������ã�����
    [SerializeField] GameObject[] check;        //����������ߵĵ�
    [SerializeField] int[] flieNum;
    bool Turn = true;
    void Update()
    {
        /*Vector2 a;
        a= transform.position;
        a = Vector2.MoveTowards(a, points[pointNum].transform.position,Time.deltaTime*speed);//�ƶ���������A��B��C
                                                                                             //���ٶȡ���transform.p
                                                                                             //osition�ǵ�ǰλ��
        transform.position=a;*/
        transform.position = Vector2.MoveTowards(transform.position, points[pointNum].transform.position,speed*Time.deltaTime);//�ƶ���������A��B��C
                                                                                                                               //���ٶȡ���transform.p
                                                                                                                               //osition�ǵ�ǰλ��
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
    private void Flip()         //��ɫ���ҷ�ת����
    {
        Turn = !Turn;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

}

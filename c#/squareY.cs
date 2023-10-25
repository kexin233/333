using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squareY : MonoBehaviour
{
    float time;
    float endTime = 0.15f;
    PlatformEffector2D pe2D;

    
    void Start()
    {
        pe2D = GetComponent<PlatformEffector2D>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            pe2D.rotationalOffset = 180f;
            time = 0;
        }
        if(time < endTime)
        {
            time += Time.deltaTime;
            if(time > endTime)
            {
                pe2D.rotationalOffset =0f;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}

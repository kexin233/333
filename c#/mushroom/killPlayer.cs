using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class killPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)      //������ײ
    {
        /* if (collision.gameObject.tag == "die")
         {
             die();
         }*/
        if (collision.gameObject.tag == "player")
        {
        }
    }
    void die()
    {

    }
}

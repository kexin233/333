using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stike : MonoBehaviour
{
    private void Start()
    {;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "die"&&!reLiveGround.youDie)
        {
            reLiveGround.youDie = true;
            reLiveGround.instance.toDie();
        }
    }
}

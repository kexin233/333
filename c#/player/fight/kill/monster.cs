using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    LayerMask _follLayer;
    Rigidbody2D rb;
    float _upSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _follLayer = Check.Instance.FootLayer;
        _upSpeed = state.instance.UpSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "mouster")
        {

            if (Physics2D.OverlapCircle(collision.transform.position, 2f, _follLayer))
            {
                if (collision.gameObject.TryGetComponent(out mushroom mou))
                {
                    mou.toDie();
                }
                rb.velocity = Vector2.up * _upSpeed;
                inWhere.instance.someThing();
            }
            else
            {
                reLiveGround.instance.toDie();
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pursuit : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer rb_sprite;
    aWaken detect;
    Animator anim;
    float aWakenR;
    Collider2D collider;
    public float returnR;
    LayerMask _playerLayerMask;

    [SerializeField] float speed;
    async void Start()
    {
        
        rb= GetComponent<Rigidbody2D>();
        rb_sprite= GetComponent<SpriteRenderer>();
        detect=GetComponent<aWaken>();
        anim= GetComponent<Animator>();
        /*aWakenR = detect.aWakenR;
        _playerLayerMask = detect._playerLayerMask;*/
    }
    public void onwall() { 
    }
    public void wallStop() { 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        findplayer();
        Vector2 vector=Vector2.zero;
        if(collider==null)
        {

        }
        if (detect._collider != null) { 
        vector = (detect._collider.transform.position - transform.position);
        }
        /*if(vector.magnitude<=detect.aWakenR)
        {
            rb.AddForce(vector.normalized*speed);
        }*/
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, aWakenR);
    }
    private void findplayer()
    {
        collider = Physics2D.OverlapCircle(transform.position, returnR, _playerLayerMask);
    }
    private void GoBack()
    {

    }
}

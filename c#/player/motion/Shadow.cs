using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
/*public class ShadowControl : Poolable
{

}*/
public class Shadow : MonoBehaviour
{
    public List<Color> RandowColors;
    public float LiftTime = 5f;
    public float ChaseSpeed = 10;
    public float ChaseaAcc=40;
    public Vector3 ChasePosition;

    private SpriteRenderer sr;

    private Queue<Vector3> posotionTrail = new();
    private Queue<Sprite>spriteTrail = new();
    private Queue<bool> flipTrail = new();

    public void Init(SpriteRenderer sprite)
    {
        gameObject.SetActive(true);
    /*    StartCoroutine(Animation(sprite));*/
    }
   /* IEnumerator Animation(SpriteRenderer origin)
    {
        if(sr==null)
            sr=GetComponent<SpriteRenderer>();
        sr.sprite = origin.sprite;
        sr.flipX = origin.flipX;
        sr.color = randomColors
    }*/


}


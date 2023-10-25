using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public struct NeedSave
{
    public  Transform thereliveGround;
}
public class reLiveGround : MonoBehaviour
{
   /* public Unit theMonster;*/
    public static bool youDie;
    public static reLiveGround instance;
    Rigidbody2D rb;
    Animator _anim;

    public GameObject mons;

    public List<GameObject> Monsters;

    [SerializeField] private GameObject _relive;

    public void setMonster(GameObject monster)
    {
        Monsters.Add(monster);
    }
    private void Start()
    {
        youDie = false;
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "liveGround")
        {
            _relive=collision.gameObject;
        }
    }

    public void relive()
    {
        
        _anim.SetBool("death", false);      
        rb.position= _relive.transform.position;
        rb.bodyType = RigidbodyType2D.Dynamic;
        youDie = false;
        /*if (Monsters != null)
        {
            for (int i = 0; i < Monsters.Count; i++)
            {
                if (Monsters[i].active == false)
                {
                    Monsters[i].SetActive(true);
                }
            }
        }*/
        mushroom.instance.toDie();
    }
    private void Awake() => instance = this;

    public void setreliveGround(Transform than)
    {
       
    }
    public void toDie()
    {
        youDie = true;
        rb.bodyType = RigidbodyType2D.Static;
        _anim.SetBool("death", true);
    }
    public void youDiechange()
    {
        
        
    }
}
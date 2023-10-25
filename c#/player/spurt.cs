using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class spurt : MonoBehaviour
{
    [SerializeField] private Unit Player;
    private Unit player;
    private bool inspurt;
    private float moveX;
    [SerializeField] private float force;
    [SerializeField] private float tadaTime;
    Rigidbody2D rb;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        player = Player;
    }

    // Update is called once per frame
    void Update()
    {
        inspurt = UnityEngine.Input.GetKeyDown(KeyCode.LeftControl);
        moveX = UnityEngine.Input.GetAxis("Horizontal");
        spurtGo();
    }
    private void FixedUpdate()
    {
        
    }
    private void spurtGo()
    {
        if (inspurt)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(transform.localScale.x * force, 0); 
        }
    }
}

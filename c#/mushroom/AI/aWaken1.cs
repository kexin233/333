using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aWaken1 : MonoBehaviour
{
    Collider2D _player;
    float _awakenR;
    Animator _anima;
    Transform _TheSleep;

    private void Start()
    {
        _anima = GetComponent<Animator>();
        _TheSleep = gameObject.transform;
    }
    private void Update()
    {
        _player = testingPlayer.instance.collider;
        if( _player != null)
        {
            _anima.SetBool("awaken", true);
        }
        if( _player == null ) {
            
        }
    }
    private void FixedUpdate()
    {
        
    }
    private void goBack()
    {

    }
    private void Awake()
    {
        
    }
}

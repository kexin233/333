using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateplat : MonoBehaviour
{
    [SerializeField] float rotatespeed;
    
    void Update()
    {
        transform.Rotate(0,0,360*rotatespeed*Time.deltaTime);    
    }
}

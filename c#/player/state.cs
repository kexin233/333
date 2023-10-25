using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class state : MonoBehaviour
{
    public static state  instance;
    public float Speed;
    public float UpSpeed;
    public float WallUpSpeed;
    public float WallDownSpeed;
    public float DownForce;
    public float UpForce;
    public float Slide;
    public float G;
    public int jumpCount;


    private void Awake()
    {
        instance = this;
    }
}

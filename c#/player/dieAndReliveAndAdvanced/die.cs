using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static reLiveGround;
using System.IO;

public class die : MonoBehaviour
{
    public static die instance;
    private void Awake()
    {
        instance = this;
        
    }
    private void Start()
    {

    }
    private void Update()
    {

    }
    
    private void relive()
    {
        reLiveGround.instance.relive();
    }
}

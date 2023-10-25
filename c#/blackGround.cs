using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

public class blackGround : MonoBehaviour
{
    private TilemapRenderer tile;
    // Start is called before the first frame update
    void Start()
    {
        tile = GetComponent<TilemapRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            
        }
    }
}

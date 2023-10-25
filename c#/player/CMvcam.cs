using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMvcam : MonoBehaviour
{
    [SerializeField]CinemachineCameraOffset came;
    [SerializeField]CinemachineVirtualCamera m_Camera;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "needWatchright")
        {
            Vector3 v2;
            v2.x = 50f;
            v2.y = 0;
            v2.z = -20;
            came.m_Offset = v2;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Vector3 v2;
        v2.x = -50f;
        v2.y = 0;
        v2.z = 20;
        came.m_Offset = v2;
    }
    /*   (Collision collision)
   {
       
   }*/
}

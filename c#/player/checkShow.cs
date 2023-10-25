using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkShow : MonoBehaviour
{
    public float x;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, x);
    }
}

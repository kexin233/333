using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 寻找判断怪物周围的角色
/// </summary>
public class testingPlayer : MonoBehaviour
{
    public static testingPlayer instance;


    public Collider2D collider;
    float _returnR;
    LayerMask _playerLayerMask;
    void Start()
    {
        _returnR = monsterState.instance.aWakenR;
    }
    private void FixedUpdate()
    {
        findplayer();
    }
    private void findplayer()
    {
        collider = Physics2D.OverlapCircle(transform.position, _returnR, _playerLayerMask);

    }
    private void Awake() => instance = this;
}

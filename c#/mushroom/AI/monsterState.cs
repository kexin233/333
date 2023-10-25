using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 存储怪物数据
/// </summary>
public class monsterState : MonoBehaviour
{
    public static monsterState instance;        //引用用


    public LayerMask _playerLayerMask;          //玩家图层
    public float aWakenR { get; private set; } = 20f;   //唤醒半径

    Animator _anim;     //动画
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    private void Awake() => instance = this;
}

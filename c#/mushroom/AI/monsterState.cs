using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �洢��������
/// </summary>
public class monsterState : MonoBehaviour
{
    public static monsterState instance;        //������


    public LayerMask _playerLayerMask;          //���ͼ��
    public float aWakenR { get; private set; } = 20f;   //���Ѱ뾶

    Animator _anim;     //����
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    private void Awake() => instance = this;
}

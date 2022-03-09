using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody _enemyRigidbody;
    private Animator _enemyAnimator;

    [SerializeField]
    private float _enemySpeed = 2f;
    void Awake()
    {
        _enemyRigidbody = GetComponent<Rigidbody>();
        _enemyAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        enemyMove();
    }

    private void enemyMove()
    {
        Vector3 moveVec = new Vector3(-_enemySpeed * Time.deltaTime, 0, 0);
        _enemyRigidbody.MovePosition(_enemyRigidbody.position + moveVec);
    }

    public void enemyDie()
    {
        _enemyAnimator.SetTrigger(AnimParameter.DIE);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected Rigidbody EnemyRigidbody;
    protected Animator EnemyAnimator;
    protected bool IsDead;
    protected float EnemySpeed = 4f;

    private void Awake()
    {
        EnemyRigidbody = GetComponent<Rigidbody>();
        EnemyAnimator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        IsDead = false;
    }

    void Update()
    {
        if (false == IsDead)
        {
            if (GameManager.instance.IsGameOver)
            {
                StartCoroutine(EnemyWin());
            }

            if (GameManager.instance.IsSkillActive)
            {
                EnemyAnimator.enabled = false;
            }
            else
            {
                EnemyAnimator.enabled = true;
                EnemyMove();
            }
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        if ((other.tag == TagNames.WEAPON || other.tag == TagNames.SKILL) && IsDead == false)
        {
            EnemyDie();
        }
        else if (other.tag == TagNames.DEADZONE && IsDead == false)
        {
            StartCoroutine(EnemyWin());
        }
    }
    protected abstract void EnemyMove();
    protected abstract void EnemyDie();
    protected abstract IEnumerator EnemyWin();
    protected abstract IEnumerator DestroyEnemy();
}

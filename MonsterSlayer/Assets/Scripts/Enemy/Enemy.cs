using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public Rigidbody EnemyRigidbody;
    public Animator EnemyAnimator;
    public bool IsDead;
    public float EnemySpeed = 2f;

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

    public void OnTriggerEnter(Collider other)
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
    public abstract void EnemyMove();
    public abstract void EnemyDie();
    public abstract IEnumerator EnemyWin();
    public abstract IEnumerator DestroyEnemy();
}

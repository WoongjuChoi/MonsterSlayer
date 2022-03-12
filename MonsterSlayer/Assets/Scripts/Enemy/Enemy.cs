using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public Rigidbody EnemyRigidbody;
    public Animator EnemyAnimator;
    public bool IsDead;
    public float EnemySpeed = 2f;
    void Awake()
    {
        EnemyRigidbody = GetComponent<Rigidbody>();
        EnemyAnimator = GetComponent<Animator>();
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
        if (other.tag == TagNames.WEAPON && IsDead == false)
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

    public IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(3f);

        Destroy(gameObject);
    }
}

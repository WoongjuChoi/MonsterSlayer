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
            EnemyMove();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon" && IsDead == false)
        {
            EnemyDie();
        }
    }
    public abstract void EnemyMove();

    public abstract void EnemyDie();

    public IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(3f);

        Destroy(gameObject);
    }
}

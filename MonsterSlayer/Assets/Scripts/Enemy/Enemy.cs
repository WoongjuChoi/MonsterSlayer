using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody _enemyRigidbody;
    private Animator _enemyAnimator;
    private bool _isDead;

    [SerializeField]
    private float _enemySpeed = 2f;
    void Awake()
    {
        _enemyRigidbody = GetComponent<Rigidbody>();
        _enemyAnimator = GetComponent<Animator>();
        _isDead = false;
    }

    void Update()
    {
        if (false == _isDead)
        {
            enemyMove();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon" && _isDead == false)
        {
            enemyDie();
        }
    }
    private void enemyMove()
    {
        Vector3 moveVec = new Vector3(-_enemySpeed * Time.deltaTime, 0, 0);
        _enemyRigidbody.MovePosition(_enemyRigidbody.position + moveVec);
    }

    public void enemyDie()
    {
        _isDead = true;
        _enemyAnimator.SetTrigger(AnimParameter.DIE);
        StartCoroutine(DestroyEnemy());
    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(3f);

        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : Enemy
{
    [SerializeField]
    private GameObject _boomEffect;

    private void OnEnable()
    {
        _boomEffect.SetActive(false);
        IsDead = false;
    }
    protected override void EnemyMove()
    {
        Vector3 moveVec = new Vector3(-EnemySpeed * Time.deltaTime, 0, 0);
        EnemyRigidbody.MovePosition(EnemyRigidbody.position + moveVec);
    }

    protected override void EnemyDie()
    {
        IsDead = true;
        GameManager.instance.AddScore(EnemyType.Boom);
        _boomEffect.SetActive(true);
        StartCoroutine(DestroyEnemy());
    }

    protected override IEnumerator EnemyWin()
    {
        IsDead = true;

        yield return new WaitForSeconds(0.1f);

        if (false == GameManager.instance.IsGameOver)
        {
            ObjectPool.ReturnBoom(this);
        }
    }

    protected override IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(1f);

        ObjectPool.ReturnBoom(this);
    }

    protected new void OnTriggerEnter(Collider other)
    {
        if ((other.tag == TagNames.WEAPON || other.tag == TagNames.PLAYER) && IsDead == false)
        {
            GameManager.instance.IsStun = true;
            EnemyDie();
        }
        else if (other.tag == TagNames.SKILL && IsDead == false)
        {
            EnemyDie();
        }
        else if (other.tag == TagNames.DEADZONE && IsDead == false)
        {
            StartCoroutine(EnemyWin());
        }
    }
}

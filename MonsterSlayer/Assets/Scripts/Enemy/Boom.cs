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
    }
    public override void EnemyMove()
    {
        Vector3 moveVec = new Vector3(-EnemySpeed * Time.deltaTime, 0, 0);
        EnemyRigidbody.MovePosition(EnemyRigidbody.position + moveVec);
    }

    public override void EnemyDie()
    {
        IsDead = true;
        GameManager.instance.AddScore(EnemyType.Boom);
        _boomEffect.SetActive(true);
        StartCoroutine(DestroyEnemy());
    }

    public override IEnumerator EnemyWin()
    {
        IsDead = true;

        yield return new WaitForSeconds(0.1f);

        if (false == GameManager.instance.IsGameOver)
        {
            ObjectPool.ReturnBoom(this);
        }
    }

    public override IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(1f);

        ObjectPool.ReturnBoom(this);
    }
}

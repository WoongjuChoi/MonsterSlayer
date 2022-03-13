using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSlave : Enemy
{
    public override void EnemyMove()
    {
        Vector3 moveVec = new Vector3(-EnemySpeed * Time.deltaTime, 0, 0);
        EnemyRigidbody.MovePosition(EnemyRigidbody.position + moveVec);
    }

    public override void EnemyDie()
    {
        IsDead = true;
        GameManager.instance.AddScore(EnemyType.SkeletonSlave);
        EnemyAnimator.enabled = true;
        EnemyAnimator.SetTrigger(AnimParameter.DIE);
        StartCoroutine(DestroyEnemy());
    }

    public override IEnumerator EnemyWin()
    {
        IsDead = true;
        GameManager.instance.TakeDamage();
        EnemyAnimator.SetTrigger(AnimParameter.WIN);

        yield return new WaitForSeconds(3f);

        if (false == GameManager.instance.IsGameOver)
        {
            ObjectPool.ReturnSkeletonSlave(this);
        }
    }

    public override IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(3f);

        ObjectPool.ReturnSkeletonSlave(this);
    }
}

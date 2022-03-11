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
        EnemyAnimator.SetTrigger(AnimParameter.DIE);
        StartCoroutine(DestroyEnemy());
    }
}

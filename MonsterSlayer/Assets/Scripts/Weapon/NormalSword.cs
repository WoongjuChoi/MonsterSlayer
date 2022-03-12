using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSword : MonoBehaviour, IWeapon
{
    private BoxCollider _hitbox;

    void Awake()
    {
        _hitbox = GetComponent<BoxCollider>();
        _hitbox.enabled = false;
    }

    void Update()
    {

    }

    public IEnumerator Attack(Animator playerAnimator)
    {
        _hitbox.enabled = true;

        while (false == playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(AnimParameter.ATTACK))
        {
            yield return null;
        }

        _hitbox.enabled = false;
    }
}

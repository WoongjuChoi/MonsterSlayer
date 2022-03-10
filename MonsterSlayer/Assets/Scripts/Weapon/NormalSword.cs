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
    public IEnumerator Attack()
    {
        _hitbox.enabled = true;

        yield return new WaitForSeconds(0.3f);

        _hitbox.enabled = false;
    }
}

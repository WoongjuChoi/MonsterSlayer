using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    IEnumerator Attack(Animator playerAnimator);
}
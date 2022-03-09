using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator _playerAnimator;
    private Rigidbody _playerRigidbody;

    //private IWeapon _curWeapon;

    void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerRigidbody = GetComponent<Rigidbody>();
        //_curWeapon = GetComponent<IWeapon>();
    }

    void Update()
    {
    }

    public void PlayerAttack()
    {
        _playerAnimator.SetTrigger(AnimParameter.ATTACK);
        //_curWeapon.Attack();
    }

    public void SetPlayerPosition(string tag)
    {
        switch (tag)
        {
            case "LeftButton":
                _playerRigidbody.position = Field.PlayerLeftPosition;
                break;
            case "RightButton":
                _playerRigidbody.position = Field.PlayerRightPosition;
                break;
            case "MiddleButton":
                _playerRigidbody.position = Field.PlayerMiddlePosition;
                break;
        }
    }
}

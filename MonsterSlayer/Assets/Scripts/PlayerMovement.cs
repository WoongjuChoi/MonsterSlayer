using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator _playerAnimator;
    private Rigidbody _playerRigidbody;

    private IWeapon _curWeapon;
    private bool _isDead;

    void Awake()
    {
        _isDead = false;
        _playerAnimator = GetComponent<Animator>();
        _playerRigidbody = GetComponent<Rigidbody>();
        _curWeapon = GetComponentInChildren<IWeapon>();
    }

    void Update()
    {
        if (false == _isDead && GameManager.instance.IsGameOver)
        {
            PlayerDie();
        }
    }

    public void PlayerAttack()
    {
        _playerAnimator.SetTrigger(AnimParameter.ATTACK);
        StartCoroutine(_curWeapon.Attack());
    }

    public void PlayerDie()
    {
        _isDead = true;
        _playerAnimator.SetTrigger(AnimParameter.DIE);
    }

    public void PlayerSkill()
    {
        _playerAnimator.SetTrigger(AnimParameter.SKILL);
        UIManager.instance.ActiveSkillButton(false);
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

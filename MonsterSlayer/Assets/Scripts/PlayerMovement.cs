using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovement : MonoBehaviour
{
    private Animator _playerAnimator;
    private Rigidbody _playerRigidbody;

    [SerializeField]
    private PlayableDirector _SkillCam;

    [SerializeField]
    private GameObject _fireEffect1;

    [SerializeField]
    private GameObject _fireEffect2;

    private IWeapon _curWeapon;
    private bool _isDead;
    private bool _isStun;

    void Awake()
    {
        _isDead = false;
        _isStun = false;
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

        if (false == _isStun && GameManager.instance.IsStun)
        {
            StartCoroutine(playerStun());
        }
    }

    public void PlayerAttack()
    {
        _playerAnimator.SetTrigger(AnimParameter.ATTACK);
        StartCoroutine(_curWeapon.Attack(_playerAnimator));
    }

    public void PlayerDie()
    {
        _isDead = true;
        _playerAnimator.SetTrigger(AnimParameter.DIE);
    }
    public void SkillActive()
    {
        _SkillCam.gameObject.SetActive(true);
        _SkillCam.Play();
        StartCoroutine(PlayerSkill());
    }

    public IEnumerator PlayerSkill()
    {
        _playerAnimator.SetTrigger(AnimParameter.SKILL);
        UIManager.instance.ActiveSkillButton(false);
        GameManager.instance.SetSkillGauge(0f);
        GameManager.instance.IsSkillActive = true;

        yield return null;

        while (true == _playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(AnimParameter.SKILL))
        {
            if (_playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.5f)
            {
                _fireEffect1.SetActive(true);
                yield return null;
            }
            else if (_playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
            {
                _fireEffect1.SetActive(false);
                _fireEffect2.SetActive(true);
                yield return null;
            }
        }

        _fireEffect2.SetActive(false);
        GameManager.instance.IsSkillActive = false;
        _SkillCam.gameObject.SetActive(false);
    }

    private IEnumerator playerStun()
    {
        _isStun = true;
        _playerAnimator.SetTrigger(AnimParameter.STUN);
        yield return new WaitForSeconds(1.8f);

        _isStun = false;
        GameManager.instance.IsStun = false;
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

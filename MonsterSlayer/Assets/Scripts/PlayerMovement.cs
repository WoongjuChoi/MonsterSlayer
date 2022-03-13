using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovement : MonoBehaviour
{
    private Animator _playerAnimator;
    private Rigidbody _playerRigidbody;

    [SerializeField]
    private PlayableDirector _playableDirector;

    [SerializeField]
    private GameObject _fireEffect1;

    [SerializeField]
    private GameObject _fireEffect2;

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
        StartCoroutine(_curWeapon.Attack(_playerAnimator));
    }

    public void PlayerDie()
    {
        _isDead = true;
        _playerAnimator.SetTrigger(AnimParameter.DIE);
    }
    public void SkillActive()
    {
        _playableDirector.gameObject.SetActive(true);
        _playableDirector.Play();
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
        _playableDirector.gameObject.SetActive(false);
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

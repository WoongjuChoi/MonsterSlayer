using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    private static GameManager _instance;

    private int _score;
    private float _skillGauge;

    [SerializeField]
    private int _hp = 3;

    [SerializeField]
    private float _skillgaugeCapacity = 100f;

    [SerializeField]
    private PlayableDirector _dieCam;

    public bool IsGameOver { get; private set; }
    public bool IsSkillActive { get; set; }
    public bool IsStun { get; set; }

    private void Awake()
    {
        _score = 0;
        _skillGauge = 0;
        IsSkillActive = false;
        IsGameOver = false;
        IsStun = false;
    }

    public void AddScore(EnemyType type)
    {
        if (false == IsGameOver)
        {
            switch (type)
            {
                case EnemyType.SkeletonSlave:
                    _score += 100;
                    _skillGauge += 10;
                    break;
                case EnemyType.Boom:
                    _score -= 100;

                    if (_score < 0)
                    {
                        _score = 0;
                    }

                    _skillGauge -= 10;
                    break;
            }

            UIManager.instance.SetScoreText(_score);
            UIManager.instance.SetSkillGauge(_skillGauge, _skillgaugeCapacity);

            if (_skillGauge >= _skillgaugeCapacity)
            {
                _skillGauge = _skillgaugeCapacity;
                UIManager.instance.ActiveSkillButton(true);
            }
        }
    }

    public void SetSkillGauge(float gauge)
    {
        _skillGauge = gauge;
        UIManager.instance.SetSkillGauge(_skillGauge, _skillgaugeCapacity);
    }

    public void TakeDamage()
    {
        if (false == IsGameOver)
        {
            --_hp;

            UIManager.instance.SetHPText(_hp);

            if (_hp <= 0)
            {
                _hp = 0;
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        IsGameOver = true;
        UIManager.instance.ActiveGameOverUI(true);
        UIManager.instance.ActiveSkillButton(false);
        _dieCam.gameObject.SetActive(true);
        _dieCam.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private int _score = 0;
    private int _skillgauge = 0;

    [SerializeField]
    private int _hp = 3;

    [SerializeField]
    private int _skillgaugeCapacity = 100;

    public bool IsGameOver { get; private set; }

    public void AddScore(EnemyType type)
    {
        if (false == IsGameOver)
        {
            switch (type)
            {
                case EnemyType.SkeletonSlave:
                    _score += 100;
                    _skillgauge += 10;
                    break;
            }

            UIManager.instance.SetScoreText(_score);

            if (_skillgauge >= _skillgaugeCapacity)
            {
                _skillgauge -= _skillgaugeCapacity;
                UIManager.instance.ActiveSkillButton(true);
            }
        }
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
    }
}

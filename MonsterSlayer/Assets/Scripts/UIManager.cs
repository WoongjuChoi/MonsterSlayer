using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance 
    {
        get 
        { 
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIManager>();
            }

            return _instance;
        } 
    }

    private static UIManager _instance;
    [SerializeField]
    private Text _hpText;

    [SerializeField]
    private Text _scoreText;

    [SerializeField]
    private GameObject _gameOverUI;

    public void SetHPText(int hp)
    {
        _hpText.text = "HP : " + hp;
    }

    public void SetScoreText(int score)
    {
        _scoreText.text = "Score : " + score;
    }

    public void ActiveGameOverUI(bool active)
    {
        _gameOverUI.SetActive(active);
    }
}

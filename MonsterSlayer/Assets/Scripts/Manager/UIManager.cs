using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private Image _skillGauge;

    [SerializeField]
    private GameObject _skillGaugeTextObject;

    [SerializeField]
    private GameObject _skillButtonObject;

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

    public void SetSkillGauge(float gauge, float capacity)
    {
        _skillGauge.fillAmount = gauge / capacity;

        if ( gauge >= capacity)
        {
            _skillGaugeTextObject.SetActive(true);
        }
        else
        {
            _skillGaugeTextObject.SetActive(false);
        }
    }

    public void ActiveSkillButton(bool active)
    {
        _skillButtonObject.SetActive(active);
    }

    public void ActiveGameOverUI(bool active)
    {
        _gameOverUI.SetActive(active);
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

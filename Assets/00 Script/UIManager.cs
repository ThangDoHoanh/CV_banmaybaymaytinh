using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] Text _scoreText;
    [SerializeField] int _Score = 0, _Highscore, _callboss ,BossCaming;
    
    void Start()
    {
        _callboss = 0;
        _Highscore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreText();
    }
    private void Update()
    { 
        if(_callboss == BossCaming)
        {
            GameManager._instan.SetBoxItem();
            PlayController._instan.SetPause(true);
            CameraController._instan.fakeAvatarBoss();

            GameManager._instan.setCallBoss(true);
            CameraController._instan.setBoolmap2(true);
            _callboss = 0;
        }
    }
    public void SetScore(int score)
    {
        if (score < 0 || score >= 6)
            return;
        _Score += score;
        if(_callboss>3)
        {
            _callboss = 0;
        }    
        _callboss += score;
        if(_Score > _Highscore)
        {
            _Highscore = _Score;

            PlayerPrefs.SetInt("HighScore", _Highscore);
        }
        UpdateScoreText();
    }
    void UpdateScoreText()
    {
        _scoreText.text = "High Score : " + _Highscore + "\n"
            + "Score : " + _Score;
        
    }
    
}

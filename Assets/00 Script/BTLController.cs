 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BTLController : MonoBehaviour
{
    [SerializeField] Button _BTLPlay;
    [SerializeField] Button _BTLSetting;
    [SerializeField] Button _BTLHome;
    [SerializeField] Button _BTLBack;
    [SerializeField] Button _BTLReset;
    [SerializeField] Button _BTLQuit;
    [SerializeField] Button _ATK;
    [SerializeField] GameObject TextCore;
    [SerializeField] GameObject _OBjBTLSetting;
    [SerializeField] GameObject _PanelSetTing;

    private void Awake()
    {
        if (_BTLSetting != null)
        {
            _BTLSetting.onClick.AddListener(() =>
            {
                AudioController._instan.SetSFX(5);
                _OBjBTLSetting.SetActive(false);
                TextCore.SetActive(false);
                _PanelSetTing.SetActive(true);
                Time.timeScale = 0;
                
            });
        }
        
        if (_BTLBack != null)
        {
            _BTLBack.onClick.AddListener(() =>
            {
                _OBjBTLSetting.SetActive(true);
                TextCore.SetActive(true);
                _PanelSetTing.SetActive(false);
                Time.timeScale = 1;
                AudioController._instan.SetSFX(5);
            });
        }
        if (_BTLHome != null)
        {
            _BTLHome.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(CONSTANT.PLAY_SETTING);
                AudioController._instan.SetSFX(5);
            });
        }
        if (_BTLPlay != null)
        {
            _BTLPlay.onClick.AddListener(() =>
            {
                
                SceneManager.LoadScene(CONSTANT.PLAYING);
                Time.timeScale = 1;
            });
        }
        if (_BTLReset != null)
        {
            _BTLReset.onClick.AddListener(() =>
            {
                AudioController._instan.SetSFX(5);
                Time.timeScale = 1;
                SceneManager.LoadScene(CONSTANT.PLAYING);
                
            });
        }
        if (_BTLQuit != null)
        {
            _BTLQuit.onClick.AddListener(() =>
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(CONSTANT.PLAY_SETTING);
                AudioController._instan.SetSFX(5);
            });
        }
    }
    
}

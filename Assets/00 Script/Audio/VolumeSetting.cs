using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSetting : Singleton<VolumeSetting>
{
    [SerializeField] Slider volumeMusicSlider;
    [SerializeField] Slider volumeSFXSlider;

    [SerializeField] AudioSource Music;
    [SerializeField] AudioSource SFX;
    private void Awake()
    {
        volumeMusicSlider.value = PlayerPrefs.GetFloat(CONSTANT.MUSIC);
        Music.volume = PlayerPrefs.GetFloat(CONSTANT.MUSIC); 

        volumeSFXSlider.value = PlayerPrefs.GetFloat(CONSTANT.SFX);
        SFX.volume = PlayerPrefs.GetFloat(CONSTANT.SFX);
    }
    private void Start()
    {
        volumeMusicSlider.onValueChanged.AddListener((float _volume) =>
        {

            Music.volume= _volume;
            PlayerPrefs.SetFloat(CONSTANT.MUSIC, _volume);
            PlayerPrefs.Save();

        });
        volumeSFXSlider.onValueChanged.AddListener((float _volume) =>
        {

            SFX.volume= _volume;
            PlayerPrefs.SetFloat(CONSTANT.SFX, _volume);
            PlayerPrefs.Save();
        });
    }

   
}

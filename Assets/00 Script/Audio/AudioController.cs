using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : Singleton<AudioController>
{

    [SerializeField] AudioSource MusicSource;
    
    [SerializeField] AudioSource SFXSource;
   

    [SerializeField] List<AudioClip> _listAudio = new List<AudioClip>();

  

    private void Start()
    {
        MusicSource.clip = _listAudio[0]; ;
        MusicSource.Play();
    }

    public void SetSFX(int index)
    {
        SFXSource.PlayOneShot(_listAudio[index]);
    }
    
    
}

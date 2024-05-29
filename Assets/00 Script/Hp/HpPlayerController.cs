using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpPlayerController : MonoBehaviour
{
    [SerializeField] private float _maxHpPlayer=100;
    [SerializeField] private float _hphientai;
    [SerializeField] float _dameEnemy,BulletBoss;
    [SerializeField] Image _fillHpPlayer;
    [SerializeField] GameObject _panelLoss;
    
    private void Awake()
    {
        _hphientai = _maxHpPlayer;
    }
    public void takeDame(float _dame)
    {
        _hphientai-=_dame;
        _hphientai = Mathf.Clamp(_hphientai,0, _maxHpPlayer);
        if(_hphientai==0)
        {
            Time.timeScale = 0;
            _panelLoss.SetActive(true);
            AudioController._instan.SetSFX(3);
        }
        updateHp();
    }
    public void updateHp()
    {
        _fillHpPlayer.fillAmount = _hphientai/ _maxHpPlayer;
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(CONSTANT.BULLETBOSS))
        {
            collision.gameObject.SetActive(false);
            AudioController._instan.SetSFX(6);
            takeDame(BulletBoss);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(CONSTANT.ENEMY))
        {
            collision.gameObject.SetActive(false);
            AudioController._instan.SetSFX(6);
            takeDame(_dameEnemy);
        }
    }
}

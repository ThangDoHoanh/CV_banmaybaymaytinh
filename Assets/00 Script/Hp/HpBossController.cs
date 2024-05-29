using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBossController : MonoBehaviour
{

    [SerializeField] private float _maxHpPlayer = 100;
    [SerializeField] private float _hphientai;
    [SerializeField] float _dameBullet;
    [SerializeField] Image _fillHPBoss;
    //[SerializeField] GameObject _panelWin;
    
    private void OnEnable()
    {
        _hphientai = _maxHpPlayer;
        updateHp();
    }
    public void takeDame(float _dame)
    {
        _hphientai -= _dame;
        _hphientai = Mathf.Clamp(_hphientai, 0, _maxHpPlayer);
        if (_hphientai == 0)
        {
            //Time.timeScale = 0;
            //_panelWin.SetActive(true);
            CameraController._instan.setatifBoss();

            GameManager._instan.setCallBoss(false);

            GameManager._instan.CallEny();

            UIManager._instan.SetScore(5);
            AudioController._instan.SetSFX(2);
        }
        updateHp();
    }
    public void updateHp()
    {
        _fillHPBoss.fillAmount = _hphientai / _maxHpPlayer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(CONSTANT.BULLET))
        {
            collision.gameObject.SetActive(false);
            AudioController._instan.SetSFX(4);
            takeDame(_dameBullet);
        }
       
    }
}

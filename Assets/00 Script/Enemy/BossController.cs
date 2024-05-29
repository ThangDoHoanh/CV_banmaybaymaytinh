using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BossController : MonoBehaviour
{
    bool _ATkBoss = false;
    [SerializeField] GameObject _target;
    [SerializeField] GameObject _bulletBoss;
    [SerializeField] float _speedATKBoss;
    float countDownAtk = 3;
    Rigidbody2D _rigiBoss;
    [SerializeField] GameObject _updateHpBoss;
    private void Start()
    {
        _ATkBoss = true;
        PlayController._instan.SetPause(false);
    }
    private void Update()
    {
        if (_ATkBoss == true)
        {
            aTKBoss();
        }
    }
    void aTKBoss()
    {

        if (!_target)
        {
            Debug.Log("tesst qqqq");
            return;
        }
        Quaternion rotate = this.transform.rotation;
        Vector2 dir = _target.transform.position - this.transform.position;

        float newAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;

        rotate.eulerAngles = new Vector3(0, 0, newAngle);

        transform.rotation = rotate;

        _bulletBoss.GetComponent<Rigidbody2D>().velocity = -this.transform.up * Time.deltaTime * _speedATKBoss;
        countDownAtk -= Time.deltaTime;
        if (countDownAtk > 0)
            return;

        GameObject bullet = ObjectPooling._instan.GetObject(_bulletBoss);

        bullet.transform.position = this.transform.position;
        bullet.transform.rotation = this.transform.rotation;
        bullet.SetActive(true);
        countDownAtk = _speedATKBoss;


        AudioController._instan.SetSFX(1);
    }
}    


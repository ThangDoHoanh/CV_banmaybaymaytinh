using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayController : Singleton<PlayController>
{
    [SerializeField] float _speedMove,_speedRotate,_SpeedATK;
    float countDownAtk = 0;


    Rigidbody2D _rigi;
    [SerializeField] Rigidbody2D _bulletfrefab;
    bool _isPause=false;
    void Start()
    {
        _isPause = false;
        _rigi = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (_isPause == false)
        {
            Move();
            ATK();
        }

    }
    private void Move()
    {
        // Điều chỉnh góc quay của player
        Quaternion rotate = transform.rotation;
        float newAngle = rotate.eulerAngles.z + -_speedRotate * Time.deltaTime * Input.GetAxisRaw("Horizontal");
        rotate.eulerAngles = new Vector3(0,0, newAngle);
        this.transform.rotation = rotate;


        _rigi.velocity = this.transform.up * Input.GetAxisRaw("Vertical")*_speedMove*Time.deltaTime;

    }
    public void ATK()
    {
        countDownAtk -= Time.deltaTime;
        if (countDownAtk > 0)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = ObjectPooling._instan.GetObject(_bulletfrefab.gameObject);

            bullet.transform.position = this.transform.position; // Set vị trí của người chơi
            bullet.transform.rotation = this.transform.rotation;
            bullet.SetActive(true);

            countDownAtk = _SpeedATK;
            AudioController._instan.SetSFX(1);
        }
    }
   
    public void SetPause(bool _pause)
    {
        _isPause= _pause;
        this.transform.rotation = Quaternion.identity;
        _rigi.velocity= Vector2.zero;
    }
}

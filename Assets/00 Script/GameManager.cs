using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject _player;
    public GameObject player => _player;
    [SerializeField] EnemyController _enemyPrefab;
    [SerializeField] BossController _bossController;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] GameObject _bulletBoss;
    Vector2 oldRandomPos = Vector2.zero;
    
    bool _callBoos = false;
    [SerializeField] GameObject _BoxItem;
    void Start()
    {
        _callBoos = false;
        StartCoroutine(InvokeAfterTime());
    }
    public void addEnemy()
    {
        Vector2 screenZize = Camera.main.ScreenToWorldPoint
            (new Vector2(Screen.width, Screen.height));

        Vector2 newPos = Vector2.zero;
        do
        {
            newPos.x = UnityEngine.Random.Range(-screenZize.x - 5, screenZize.x
                + 5);
            newPos.y = UnityEngine.Random.Range(-screenZize.y - 5, screenZize.y
               + 5);
        } while (newPos.x >= -screenZize.x && newPos.x <= screenZize.x ||
        (newPos.y >= -screenZize.y && newPos.y <= screenZize.y) ||
        Vector2.Distance(oldRandomPos, newPos) < 2);
        oldRandomPos = newPos;

        GameObject eneymy = ObjectPooling._instan.GetObject(_enemyPrefab.gameObject);
        eneymy.transform.position = newPos;
        eneymy.SetActive(true);
        
    }
    public IEnumerator InvokeAfterTime()
    {
        while (_callBoos == false)
        {
            yield return new WaitForSeconds(
                UnityEngine.Random.Range(2, 7));

            if (!_callBoos)
            {
                this.addEnemy();
            }
        }
    }

    public void setCallBoss(bool callboss)
    {
        _callBoos = callboss;
    }
    public void SetBoxItem()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            float screenHeightInUnits = mainCamera.orthographicSize * 2f;
            Debug.Log("Chiều dài của màn hình theo đơn vị Unity: " + screenHeightInUnits);
            float screenWidthInUnits = mainCamera.orthographicSize * 2f * mainCamera.aspect;
            Debug.Log("Chiều rộng của màn hình theo đơn vị Unity: " + screenWidthInUnits);

            Vector2 trenphai = Camera.main.ScreenToWorldPoint
               (new Vector2(Screen.width, Screen.height));
            Vector2 duoiphai = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0));
            Vector3 giuaphai = new Vector3(((trenphai.x + duoiphai.x) / 2)-5, (trenphai.y + duoiphai.y) / 2, 0);
            _BoxItem.transform.position = giuaphai;
            _BoxItem.SetActive(true);
        }
    }

    public void CallEny()
    {
        StartCoroutine(InvokeAfterTime());
    }    
}


using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    [SerializeField] float _offSetY;
    [SerializeField] Transform _Player;
    [SerializeField] Vector2 _offSet;
    [SerializeField] BossController _BossController;
    [SerializeField] GameObject _bosstest;
    [SerializeField] GameObject AvatarFake;
    [SerializeField] float _currentOffsetY = 0f;
    [SerializeField] GameObject ObjPooling;
    bool map2;
    private bool generateCollidersCalled = false;
    bool freezeCamera = false;
    private void Start()
    {
        map2 = false;
    }
    private void Update()
    {
        if (map2 == false)
        {
            setCamLv1();
        }
        else
        {
            setCamLv2();
        }
    }
    void setCamLv1()
    {
        //Debug.LogError("cam1");
        Vector3 pos = _Player.position + (Vector3)_offSet;
        pos.z = Camera.main.transform.position.z;
        Camera.main.transform.position = pos;
    }

    public void GenerateColliders()
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
            Vector2 trentrai = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height));
            Vector3 giuatren = new Vector3((trenphai.x + trentrai.x) / 2, (trenphai.y + trentrai.y) / 2, 0);

            GameObject newObject_giuatren = new GameObject("newObject_giutren");

            BoxCollider2D boxCollider_giutren = newObject_giuatren.AddComponent<BoxCollider2D>();
            boxCollider_giutren.size = new Vector2(screenWidthInUnits, 2);
            newObject_giuatren.transform.position = new Vector3(giuatren.x, giuatren.y + 1, 0);



            Vector2 duoiphai = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0));
            Vector2 duoitrai = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
            Vector3 giuaduoi = new Vector3((duoiphai.x + duoitrai.x) / 2, duoitrai.y, 0);


            GameObject newObject_giuaduoi = new GameObject("newObject_giuaduoi");
            BoxCollider2D boxCollider_giuaduoi = newObject_giuaduoi.AddComponent<BoxCollider2D>();
            boxCollider_giuaduoi.size = new Vector2(screenWidthInUnits, 2);
            newObject_giuaduoi.transform.position = new Vector3(giuaduoi.x, giuaduoi.y - 1, 0);

            Vector3 giuaphai = new Vector3((trenphai.x + duoiphai.x) / 2, (trenphai.y + duoiphai.y) / 2, 0);


            GameObject newObject_giuaphai = new GameObject("newObject_giuaphai");
            BoxCollider2D boxCollider_giuaphai = newObject_giuaphai.AddComponent<BoxCollider2D>();
            boxCollider_giuaphai.size = new Vector2(2, screenHeightInUnits);
            newObject_giuaphai.transform.position = new Vector3(giuaphai.x + 1, giuaphai.y, 0);


            Vector3 giuatrai = new Vector3((trentrai.x + duoitrai.x) / 2, (trentrai.y + duoitrai.y) / 2, 0);

            GameObject newObject_giuatrai = new GameObject("newObject_giuatrai");
            BoxCollider2D boxCollider_giuatrai = newObject_giuatrai.AddComponent<BoxCollider2D>();
            boxCollider_giuatrai.size = new Vector2(2, screenHeightInUnits);
            newObject_giuatrai.transform.position = new Vector3(giuatrai.x - 1, giuatrai.y, 0);

            newObject_giuatren.transform.parent = ObjPooling.transform;
            newObject_giuaduoi.transform.parent = ObjPooling.transform;
            newObject_giuaphai.transform.parent = ObjPooling.transform;
            newObject_giuatrai.transform.parent = ObjPooling.transform;

            _bosstest.transform.position = new Vector3((trenphai.x + trentrai.x) / 2, ((trenphai.y + trentrai.y) / 2) - 2, 0);
        }

        PlayController._instan.SetPause(false);

        //_BossController.setBoolATKBoss(true);

        _bosstest.SetActive(true);
        AvatarFake.SetActive(false);
    }

    void setCamLv2()
    {
        if (_currentOffsetY == _offSetY - 1 && !generateCollidersCalled && !freezeCamera)
        {
            _currentOffsetY++;

            GenerateColliders();

            generateCollidersCalled = true;
            freezeCamera = true; // Đặt freezeCamera thành true để ngăn camera di chuyển tiếp
            return;
        }

        // Nếu camera đã được đóng băng, không cần làm gì cả
        if (freezeCamera)
            return;

        // Tăng giá trị của _currentOffsetY từ 0 đến 3 dần dần
        _currentOffsetY = Mathf.MoveTowards(_currentOffsetY, 4f, Time.deltaTime);

        // Sử dụng giá trị của _currentOffsetY để thiết lập giá trị của _offSet.y
        Vector3 pos = _Player.position + new Vector3(_offSet.x, _currentOffsetY, -10);
        pos.z = Camera.main.transform.position.z;
        Camera.main.transform.position = pos;


    }
    public void setBoolmap2(bool setmap)
    {
        map2 = setmap;
    }
    public void fakeAvatarBoss()
    {
        ObjectPooling._instan.DesTroychild();
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            float screenHeightInUnits = mainCamera.orthographicSize * 2f;
            Debug.Log("Chiều dài của màn hình theo đơn vị Unity: " + screenHeightInUnits);
            float screenWidthInUnits = mainCamera.orthographicSize * 2f * mainCamera.aspect;
            Debug.Log("Chiều rộng của màn hình theo đơn vị Unity: " + screenWidthInUnits);

            Vector2 trenphai = Camera.main.ScreenToWorldPoint
               (new Vector2(Screen.width, Screen.height));
            Vector2 trentrai = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height));
            Vector3 giuatren = new Vector3((trenphai.x + trentrai.x) / 2, ((trenphai.y + trentrai.y) / 2) + 2, 0);
            AvatarFake.transform.position = giuatren;
            AvatarFake.SetActive(true);
        }
    }
    public void setatifBoss()
    {
        _bosstest.SetActive(false);
        setCamLv1();
        map2 = false;
        ObjectPooling._instan.DesTroychild();

        // Đặt lại các biến trạng thái ở đây
        _currentOffsetY = 0f;
        generateCollidersCalled = false;
        freezeCamera = false;
    }
}


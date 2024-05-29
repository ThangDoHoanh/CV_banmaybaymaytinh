using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float _speedMoveEnemy ;
    Rigidbody2D _rigidbodyEnemy;
    [SerializeField] GameObject _target;
    
    void Start()
    {
        _rigidbodyEnemy = GetComponent<Rigidbody2D>();
        _target = GameManager._instan.player;
    }
    void Update()
    {
        moveEnemy();
    }
    void moveEnemy()
    {
        if(!_target)
        {
            return;
        }
        Quaternion rotate = this.transform.rotation;
        Vector2 dir = _target.transform.position - this.transform.position;
        if(dir.sqrMagnitude<0.5f)
        {
            _rigidbodyEnemy.velocity = Vector2.zero;
            return;
        }
        float newAngle = Mathf.Atan2(dir.y ,dir.x)* Mathf.Rad2Deg-90;

        rotate.eulerAngles = new Vector3(0, 0, newAngle);

        transform.rotation = rotate;

        _rigidbodyEnemy.velocity = this.transform.up * Time.deltaTime * _speedMoveEnemy;
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag(CONSTANT.BULLET))
        {
            return;
        }
        if (IsInCameraView(collision.transform.position))
        {
            UIManager._instan.SetScore(1);
            collision.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            AudioController._instan.SetSFX(4);
        }
    }
    private bool IsInCameraView(Vector2 position)
    {
        // Lấy camera chính
        Camera mainCamera = Camera.main;

        // Kiểm tra xem có camera chính không
        if (mainCamera != null)
        {
            // Kiểm tra xem vị trí của Collider2D có nằm trong tầm nhìn của camera hay không
            Vector3 viewportPoint = mainCamera.WorldToViewportPoint(position);
            return viewportPoint.x >= 0 && viewportPoint.x <= 1 && viewportPoint.y >= 0 && viewportPoint.y <= 1;
        }

        // Trả về false nếu không có camera chính
        return false;
    }

}

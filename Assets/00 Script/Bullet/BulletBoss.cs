using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss : MonoBehaviour
{
    [SerializeField] float _speed, _lifeTime;
    Rigidbody2D _rigiBullet;
    Coroutine _coroutine = null;
    void Start()
    {
        _rigiBullet = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        StartCoroutine(DeactiveAfterTime());
    }
    private void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }
    void Update()
    {
        _rigiBullet.velocity = _speed * -this.transform.up * Time.deltaTime;
    }
    IEnumerator DeactiveAfterTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        this.gameObject.SetActive(false);
    }
}

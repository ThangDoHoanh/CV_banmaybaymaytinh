using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxItem : MonoBehaviour
{
    [SerializeField] GameObject _Hp;
    [SerializeField] float _hoiHP;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(CONSTANT.PLAYER))
        {
            this.gameObject.SetActive(false);
            AudioController._instan.SetSFX(6);
            _Hp.GetComponent<HpPlayerController>().takeDame(-_hoiHP);

        }
    }
}

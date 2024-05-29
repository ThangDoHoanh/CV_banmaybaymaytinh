using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGController : MonoBehaviour
{
    Texture _image;
    [SerializeField] int _pixelIma;
    [SerializeField] Transform _tranformPlayer;
    float inGameWdith;
    float inGameHeight;
    private void Awake()
    {
        _image =this.GetComponent<SpriteRenderer>().sprite.texture;
        inGameWdith= _image.width/ _pixelIma;
        inGameHeight = _image.height/ _pixelIma;
    }
    private void Update()
    {
        if ((Mathf.Abs(_tranformPlayer.position.x - this.transform.position.x) >= inGameWdith)||
            (Mathf.Abs(_tranformPlayer.position.x - this.transform.position.x))<= -inGameWdith)
        {
            Vector2 pos = this.transform.position;
            pos.x =_tranformPlayer.position.x;
            this.transform.position = pos;
        }

        if (Mathf.Abs(_tranformPlayer.position.y - this.transform.position.y) >= inGameHeight || Mathf.Abs(_tranformPlayer.position.y - this.transform.position.y)
            <= -inGameHeight)
        {
            Vector2 pos = this.transform.position;
            pos.y = _tranformPlayer.position.y;
            
            this.transform.position = pos;
        }
    }


}

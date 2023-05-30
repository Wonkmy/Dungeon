using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTile : MonoBehaviour
{
    public Texture2D mapTex;
    SpriteRenderer sr;
    public void Init()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void SetTileCoords(int x,int y)
    {
        Sprite sp = Sprite.Create(mapTex, new Rect(x * 16, y * 16, 16, 16), new Vector2(0.5f, 0.5f));
        sr.sprite = sp;
    }
}

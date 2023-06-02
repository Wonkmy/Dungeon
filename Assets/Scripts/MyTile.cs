using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTile : MonoBehaviour
{
    #region 公开变量
    public Texture2D mapTex;
    #endregion

    public bool HaveAnim { get; set; }

    public bool NeedPlayOnLoad { get; set; }

    SpriteRenderer sr;

    List<Sprite> allFrames;
    List<Sprite> allCustomAnimFrames;
    int frameCounts = -1;
    int curFrameId = -1;
    int customCurFrameId = -1;
    float frameTimer = 0;
    float customFrameTimer = 0;
    bool canPlayOnCustom = false;
    public void Init()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Init(bool haveAnim,bool playOnload , int howManyFrameCounts)
    {
        sr = GetComponent<SpriteRenderer>();
        HaveAnim = haveAnim;
        NeedPlayOnLoad = playOnload;
        if (haveAnim)
        {
            allFrames = new List<Sprite>();
            allCustomAnimFrames = new List<Sprite>();
            frameCounts = howManyFrameCounts;
            curFrameId = 0;
            customCurFrameId = 0;
        }
    }

    public void SetTileCoords(int x,int y)
    {
        if (HaveAnim)
        {
            for (int i = 0; i < frameCounts; i++)
            {
                Sprite sp = Sprite.Create(mapTex, new Rect(x * 16 + (i * 16), y * 16, 16, 16), new Vector2(0.5f, 0.5f));
                if (NeedPlayOnLoad)
                {
                    allFrames.Add(sp);
                }
                else
                {
                    allCustomAnimFrames.Add(sp);
                }
            }
        }
        else
        {
            Sprite sp = Sprite.Create(mapTex, new Rect(x * 16, y * 16, 16, 16), new Vector2(0.5f, 0.5f));
            sr.sprite = sp;
        }
    }

    public void PlayAnim()
    {
        canPlayOnCustom = true;
    }
    private void Update()
    {
        if (HaveAnim)
        {
            if (NeedPlayOnLoad)
            {
                frameTimer += Time.deltaTime;
                if (frameTimer >= 0.2f)
                {
                    frameTimer = 0;
                    curFrameId++;
                    if (curFrameId >= allFrames.Count)
                    {
                        curFrameId = 0;
                    }
                    sr.sprite = allFrames[curFrameId];
                }
            }
            else
            {
                if (canPlayOnCustom)
                {
                    customFrameTimer += Time.deltaTime;
                    if (customFrameTimer >= 0.2f)
                    {
                        customFrameTimer = 0;
                        customCurFrameId++;
                        if (customCurFrameId >= allCustomAnimFrames.Count)
                        {
                            customCurFrameId = allCustomAnimFrames.Count;
                            canPlayOnCustom = false;
                        }
                        sr.sprite = allCustomAnimFrames[customCurFrameId];
                    }
                }
            }
        }
    }
}

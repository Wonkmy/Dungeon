using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChunkViewer : MonoBehaviour
{
    GameObject tile;
    public int CID { get; set; }
    public ChunkType type { get; set; }

    int[,] chunkData;

    MyTile[,] allBaseTile;
    public void Init(int cid)
    {
        CID = cid;
        tile = Resources.Load<GameObject>("Prefabs/tile");
        allBaseTile = new MyTile[7, 7];
    }
    public void InitChunk(ChunkType _type)
    {
        type = _type;
        chunkData = Utility.GetChunkDataByChunkType(type);
        GameObject newTile = null;
        for (int x = 0; x < chunkData.GetLength(0); x++)
        {
            for (int y = 0; y < chunkData.GetLength(1); y++)
            {
                if (chunkData[x, y] == 1)
                {
                    newTile = Instantiate(tile);
                    newTile.name = "BaseGround";
                    newTile.GetComponent<MyTile>().Init();
                    newTile.GetComponent<MyTile>().SetTileCoords(Random.Range(5, 7), 15);// 80  240 192  32
                    newTile.transform.SetParent(transform);
                    newTile.transform.localPosition = new Vector3(x - ChunkData.ChunkSize / 2.0f + 0.5f, y - ChunkData.ChunkSize / 2.0f + 0.5f);
                    newTile.transform.localScale = Vector3.one * 6.243f;
                    allBaseTile[x, y] = newTile.GetComponent<MyTile>();
                    newTile.AddComponent<BoxCollider2D>();
                }
            }
        }
        if (Random.Range(0, 100) > 70)
        {
            SpwanItems(newTile);
        }
    }

    void SpwanItems(GameObject baseTile)
    {
        int[,] itemData = Utility.GetRandomItemRecipeData();
        for (int i = 0; i < itemData.GetLength(0);i++)
        {
            for (int j = 0; j < itemData.GetLength(1); j++)
            {
                if (itemData[i, j] != 0 && chunkData[i,j]!=0)
                {
                    if (itemData[i, j] == 1) //0Ϊ�� 1Ϊ���  2Ϊ�ع��� 3Ϊ������  4Ϊ�ر���  5Ϊ�Ʊ���
                    {
                        SpwanTile("newCoin", i, j, baseTile, 80, 32, true, true, 4);
                    }
                    if (itemData[i, j] == 2)
                    {
                        SpwanTile("newJug", i, j, baseTile, 192, 32);
                    }
                    if (itemData[i, j] == 3)
                    {
                        SpwanTile("newJug", i, j, baseTile, 144, 32);
                    }
                    if (itemData[i, j] == 4)
                    {
                        SpwanTile("newChest", i, j, baseTile, 0, 48);
                    }
                    if (itemData[i, j] == 5)
                    {
                        SpwanTile("newChest", i, j, baseTile, 128, 48);
                    }
                }
            }
        }
    }

    void SpwanTile(string tileName,int x,int y,GameObject baseTile,int coordX,int coordY,bool hasAnim=false,bool playOnload=false,int frameCounts = -1)
    {
        GameObject newTile = Instantiate(tile);
        newTile.name = tileName;
        if (hasAnim)
        {
            newTile.GetComponent<MyTile>().Init(hasAnim, playOnload, frameCounts);
        }
        else
        {
            newTile.GetComponent<MyTile>().Init();
        }
        newTile.GetComponent<MyTile>().SetTileCoords(coordX / 16, coordY / 16);
        newTile.transform.SetParent(transform);
        newTile.transform.localPosition = new Vector3(x - ChunkData.ChunkSize / 2.0f + 0.5f, y - ChunkData.ChunkSize / 2.0f + 0.5f);
        newTile.transform.localScale = Vector3.one * 6.243f;
        newTile.GetComponent<SpriteRenderer>().sortingOrder = baseTile.GetComponent<SpriteRenderer>().sortingOrder + 1;
    }
}

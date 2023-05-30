using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChunkViewer : MonoBehaviour
{
    GameObject tile;
    int[,] chunkData;
    public void Init()
    {
        tile = Resources.Load<GameObject>("Prefabs/tile");
    }

    public void RotateArray()
    {
        Utility.RotateArray(chunkData);
    }
    public void InitChunk(ChunkType type)
    {
        chunkData = Utility.GetChunkDataByChunkType(type);
        for (int x = 0; x < chunkData.GetLength(0); x++)
        {
            for (int y = 0; y < chunkData.GetLength(1); y++)
            {
                if (chunkData[x, y] == 1)
                {
                    GameObject newTile = Instantiate(tile);
                    newTile.GetComponent<MyTile>().Init();
                    newTile.GetComponent<MyTile>().SetTileCoords(5, 15);
                    newTile.transform.SetParent(transform);
                    newTile.transform.position = new Vector3(x, y);
                    newTile.transform.localScale = Vector3.one * 6.243f;
                }
            }
        }
    }
}

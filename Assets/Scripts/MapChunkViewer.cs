using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChunkViewer : MonoBehaviour
{
    GameObject tile;
    public int CID { get; set; }
    public ChunkType type { get; set; }
    public void Init(int cid)
    {
        CID = cid;
        tile = Resources.Load<GameObject>("Prefabs/tile");
    }
    public void InitChunk(ChunkType _type)
    {
        type = _type;
        int[,] chunkData = Utility.GetChunkDataByChunkType(type);
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
                    newTile.transform.localPosition = new Vector3(x - ChunkData.ChunkSize / 2.0f + 0.5f, y - ChunkData.ChunkSize / 2.0f + 0.5f);
                    newTile.transform.localScale = Vector3.one * 6.243f;
                }
            }
        }
    }
}

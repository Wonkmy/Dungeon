using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private void Start()
    {
        int[,] mapData = MapData.data;
        Utility.RotateArray(mapData);

        bool a = false;
        bool b = false;
        bool c = false ;
        ChunkType chunkType = ChunkType.NULL;
        for (int x = 0; x < mapData.GetLength(0); x++)
        {
            for (int y = 0; y < mapData.GetLength(1); y++)
            {
                if (mapData[x, y] != 0)
                {
                    GameObject chunkBiewContain = new GameObject("chunkViewer", typeof(MapChunkViewer));
                    MapChunkViewer mapChunkViewer = chunkBiewContain.GetComponent<MapChunkViewer>();
                    mapChunkViewer.Init();
                    if (mapData[x, y] == 1)
                    {
                        chunkType = ChunkType.NormalChunk;
                        mapChunkViewer.InitChunk(chunkType);
                        if (a == false)
                        {
                            mapChunkViewer.RotateArray();
                            a = true;
                        }
                    }
                    if (mapData[x, y] == 2)
                    {
                        chunkType = ChunkType.LineChunk;
                        mapChunkViewer.InitChunk(chunkType);
                        if (b == false)
                        {
                            mapChunkViewer.RotateArray();
                            b = true;
                        }
                    }
                    if (mapData[x, y] == 3)
                    {
                        chunkType = ChunkType.RopeChunk;
                        mapChunkViewer.InitChunk(chunkType);
                        if (c == false)
                        {
                            mapChunkViewer.RotateArray();
                            c = true;
                        }
                    }
                    chunkBiewContain.transform.position = new Vector3(x * 7 - 10, y * 7 - 5, 0);
                }
            }
        }
    }
}

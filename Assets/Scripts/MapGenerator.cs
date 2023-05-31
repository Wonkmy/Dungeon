using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private void Start()
    {
        RotateAllChunkDataArray();
        

        int[,] mapData = MapData.data;
        Utility.RotateArray(mapData);

        for (int x = 0; x < mapData.GetLength(0); x++)
        {
            for (int y = 0; y < mapData.GetLength(1); y++)
            {
                if (mapData[x, y] != 0)
                {
                    if (mapData[x, y] == 1)
                    {
                        GameObject chunkViewerContain = new GameObject("chunkViewer", typeof(MapChunkViewer));
                        chunkViewerContain.transform.position = new Vector3(x * 7 - 38, y * 7, 0);
                        chunkViewerContain.GetComponent<MapChunkViewer>().Init();
                        chunkViewerContain.GetComponent<MapChunkViewer>().InitChunk(ChunkType.BaseChunk);
                    }
                    if (mapData[x, y] == 2)
                    {
                        GameObject chunkViewerContain = new GameObject("chunkViewer", typeof(MapChunkViewer));
                        chunkViewerContain.transform.position = new Vector3(x * 7 - 38, y * 7, 0);
                        chunkViewerContain.GetComponent<MapChunkViewer>().Init();
                        chunkViewerContain.GetComponent<MapChunkViewer>().InitChunk(ChunkType.BaseChunk);
                    }
                    if (mapData[x, y] == 3)
                    {
                        GameObject chunkViewerContain = new GameObject("chunkViewer", typeof(MapChunkViewer));
                        chunkViewerContain.transform.position = new Vector3(x * 7 - 38, y * 7, 0);
                        chunkViewerContain.GetComponent<MapChunkViewer>().Init();
                        chunkViewerContain.GetComponent<MapChunkViewer>().InitChunk(ChunkType.BaseChunk);
                    }
                }
            }
        }
    }

    void RotateAllChunkDataArray()
    {
        Utility.RotateArray(ChunkData.NormalChunk);
        Utility.RotateArray(ChunkData.LineChunk);
        Utility.RotateArray(ChunkData.QuadChunk);
        Utility.RotateArray(ChunkData.ZhongChunk);
        Utility.RotateArray(ChunkData.RopeChunk);
        Utility.RotateArray(ChunkData.BaseChunk);
    }
}

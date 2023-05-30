using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    List<GameObject> allContain = new List<GameObject>();
    GameObject tile;
    private void Start()
    {
        tile = Resources.Load<GameObject>("Prefabs/tile");

        int[,] mapData = MapData.data;
        Utility.RotateArray(mapData);
        GameObject chunkViewerContain = null;

        for (int i = 0; i < 3; i++)
        {
            for (int y = 0; y < 3; y++)
            {
                chunkViewerContain = new GameObject("chunkViewer", typeof(MapChunkViewer));
                allContain.Add(chunkViewerContain);
                chunkViewerContain.transform.position = new Vector3(i * 7, y * 7, 0);
            }
            
        }

        for (int i = 0; i < allContain.Count; i++)
        {
            //MapChunkViewer mapChunkViewer = allContain[i].GetComponent<MapChunkViewer>();
            //int[,] chunData = mapChunkViewer.InitChunk(ChunkType.NormalChunk);
            GeneratorSingleChunk(ChunkData.NormalChunk, allContain[i].transform);
        }
    }

    void GeneratorSingleChunk(int[,] chunkData,Transform parent)
    {
        Utility.RotateArray(chunkData);
        for (int x = 0; x < chunkData.GetLength(0); x++)
        {
            for (int y = 0; y < chunkData.GetLength(1); y++)
            {
                if (chunkData[x, y] == 1)
                {
                    GameObject newTile = Instantiate(tile);
                    newTile.GetComponent<MyTile>().Init();
                    newTile.GetComponent<MyTile>().SetTileCoords(5, 15);
                    newTile.transform.SetParent(parent);
                    newTile.transform.position = new Vector3(x, y);
                    newTile.transform.localScale = Vector3.one * 6.243f;
                }
            }
        }
    }
}

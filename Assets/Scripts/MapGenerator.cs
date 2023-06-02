using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    Dictionary<int, MapChunkViewer> mapChunkViewers;
    private void Start()
    {
        mapChunkViewers = new Dictionary<int, MapChunkViewer>();
        RotateAllChunkDataArray();
        GeneratorMap();
    }

    void GeneratorMap()
    {
        int[,] mapData = MapData.GenerateData(11, 11);
        Utility.RotateArray(mapData);
        int cid = 0;
        for (int x = 0; x < mapData.GetLength(0); x++)
        {
            for (int y = 0; y < mapData.GetLength(1); y++)
            {
                if (mapData[x, y] != 0)
                {
                    if (mapData[x, y] == 1)
                    {
                        GameObject chunkViewerContain = new GameObject("chunkViewer", typeof(MapChunkViewer));
                        chunkViewerContain.transform.SetParent(transform);
                        chunkViewerContain.transform.localPosition = new Vector3(x * ChunkData.ChunkSize - 38, y * ChunkData.ChunkSize, 0);
                        MapChunkViewer mapChunkViewer = chunkViewerContain.GetComponent<MapChunkViewer>();
                        mapChunkViewer.Init(cid++);
                        mapChunkViewer.InitChunk(ChunkType.BaseChunk);
                        mapChunkViewers.Add(mapChunkViewer.CID, mapChunkViewer);
                    }
                    if (mapData[x, y] == 2)
                    {
                        GameObject chunkViewerContain = new GameObject("chunkViewer", typeof(MapChunkViewer));
                        chunkViewerContain.transform.SetParent(transform);
                        chunkViewerContain.transform.localPosition = new Vector3(x * ChunkData.ChunkSize - 38, y * ChunkData.ChunkSize, 0);
                        MapChunkViewer mapChunkViewer = chunkViewerContain.GetComponent<MapChunkViewer>();
                        mapChunkViewer.Init(cid++);
                        mapChunkViewer.InitChunk(ChunkType.BaseChunk);
                        mapChunkViewers.Add(mapChunkViewer.CID, mapChunkViewer);
                    }
                    if (mapData[x, y] == 6)
                    {
                        GameObject chunkViewerContain = new GameObject("chunkViewer", typeof(MapChunkViewer));
                        chunkViewerContain.transform.SetParent(transform);
                        chunkViewerContain.transform.localPosition = new Vector3(x * ChunkData.ChunkSize - 38, y * ChunkData.ChunkSize, 0);
                        MapChunkViewer mapChunkViewer = chunkViewerContain.GetComponent<MapChunkViewer>();
                        mapChunkViewer.Init(cid++);
                        mapChunkViewer.InitChunk(ChunkType.BaseChunk);
                        mapChunkViewers.Add(mapChunkViewer.CID, mapChunkViewer);
                    }
                }
            }
        }
        Camera.main.GetComponent<CameraFollow>().SetFollow(GetChunkViewByCID(0).transform,true);
    }


    public MapChunkViewer GetChunkViewByCID(int cid)
    {
        if (mapChunkViewers.ContainsKey(cid))
        {
            return mapChunkViewers[cid];
        }
        return null;
    }
    private void Update()
    {
        TestMapGenerator();
    }

    void TestMapGenerator()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (transform.childCount > 0)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
                mapChunkViewers.Clear();
                Camera.main.GetComponent<CameraFollow>().CloseFollow();
            }
            GeneratorMap();
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
        Utility.RotateArray(ItemData.Recipe1);
        Utility.RotateArray(ItemData.Recipe2);
        Utility.RotateArray(ItemData.Recipe3);
        Utility.RotateArray(ItemData.Recipe4);
    }
}

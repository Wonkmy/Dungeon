using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChunkViewer : MonoBehaviour
{
    
    public int[,] InitChunk(ChunkType type)
    {
        int[,] chunkData = Utility.GetChunkDataByChunkType(type);
        //Utility.RotateArray(chunkData);
        return chunkData;
    }
}

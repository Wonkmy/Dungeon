using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility
{
    public static void RotateArray(int[,] array)
    {
        //Debug.Log(1);
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);
        // ת�þ���
        for (int i = 0; i < rows; i++)
        {
            for (int j = i + 1; j < cols; j++)
            {
                int temp = array[i, j];
                array[i, j] = array[j, i];
                array[j, i] = temp;
            }
        }

        // ������
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols / 2; j++)
            {
                int temp = array[i, j];
                array[i, j] = array[i, cols - j - 1];
                array[i, cols - j - 1] = temp;
            }
        }
    }

    public static int[,] GetChunkDataByChunkType(ChunkType type)
    {
        if (type == ChunkType.BaseChunk)
        { return ChunkData.BaseChunk; }
        if (type == ChunkType.NormalChunk)
        { return ChunkData.NormalChunk; }
        else if (type == ChunkType.LineChunk)
        { return ChunkData.LineChunk; }
        else if (type == ChunkType.QuadChunk)
        { return ChunkData.QuadChunk; }
        else if (type == ChunkType.ZhongChunk)
        { return ChunkData.ZhongChunk; }
        else if (type == ChunkType.RopeChunk)
        { return ChunkData.RopeChunk; }
        else
        { return new int[0, 0]; }
    }

    public static int[,] GetRandomItemRecipeData()
    {
        int rand = Random.Range(0, 4);
        if (rand == 0)
        {
            return ItemData.Recipe1;
        }
        else if (rand == 1)
        {
            return ItemData.Recipe2;
        }
        else if (rand == 2)
        {
            return ItemData.Recipe3;
        }
        else if (rand == 3)
        {
            return ItemData.Recipe4;
        }
        else
        {
            return new int[0, 0];
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkData
{
    public const int ChunkSize = 7;
    public static int[,] BaseChunk = new int[ChunkSize, ChunkSize] {
        { 1,1,1,1,1,1,1},
        { 1,1,1,1,1,1,1},
        { 1,1,1,1,1,1,1},
        { 1,1,1,1,1,1,1},
        { 1,1,1,1,1,1,1},
        { 1,1,1,1,1,1,1},
        { 1,1,1,1,1,1,1}
    };
    public static int[,] NormalChunk = new int[ChunkSize, ChunkSize] {
        { 0,0,1,1,1,0,0},
        { 0,0,1,1,1,0,0},
        { 0,1,1,1,1,1,0},
        { 0,1,1,1,1,1,0},
        { 0,1,1,1,1,1,0},
        { 0,0,1,1,1,0,0},
        { 0,0,1,1,1,0,0}
    };
    public static int[,] LineChunk = new int[ChunkSize, ChunkSize] {
        { 0,0,0,1,0,0,0},
        { 0,0,0,1,0,0,0},
        { 0,0,0,1,0,0,0},
        { 0,0,0,1,0,0,0},
        { 0,0,0,1,0,0,0},
        { 0,0,0,1,0,0,0},
        { 0,0,0,1,0,0,0}
    };
    public static int[,] QuadChunk = new int[ChunkSize, ChunkSize] {
        { 0,0,0,0,0,0,0},
        { 0,0,0,0,0,0,0},
        { 0,0,1,1,1,0,0},
        { 0,0,1,1,1,0,0},
        { 0,0,1,1,1,0,0},
        { 0,0,0,0,0,0,0},
        { 0,0,0,0,0,0,0}
    };
    public static int[,] ZhongChunk = new int[ChunkSize, ChunkSize] {
        { 0,0,0,0,0,0,0},
        { 0,0,0,0,0,0,0},
        { 0,0,1,1,1,0,0},
        { 0,0,1,1,1,0,0},
        { 0,1,1,1,1,1,0},
        { 0,0,1,1,1,0,0},
        { 0,0,1,1,1,0,0}
    };
    public static int[,] RopeChunk = new int[ChunkSize, ChunkSize] {
        { 0,0,0,1,0,0,0},
        { 0,0,1,1,1,0,0},
        { 0,0,0,1,0,0,0},
        { 0,0,0,1,0,0,0},
        { 0,0,1,1,1,1,1},
        { 0,0,0,1,0,1,0},
        { 0,0,0,0,0,1,0}
    };
}

public class MapData
{
    //public static int[,] data = new int[11, 11] {
    //    {0,0,0,0,0,0,1,0,0,0,0},
    //    {0,0,0,0,0,0,1,0,0,0,0},
    //    {0,0,0,0,0,0,6,1,0,0,0},
    //    {0,0,0,0,0,0,0,1,0,0,0},
    //    {0,0,0,0,0,0,0,2,0,0,0},
    //    {0,0,0,0,0,0,0,2,0,0,0},
    //    {0,0,0,0,0,0,0,2,0,0,0},
    //    {0,0,0,0,0,1,1,1,0,0,0},
    //    {0,0,0,0,0,1,0,0,0,0,0},
    //    {0,0,0,0,0,1,0,0,0,0,0},
    //    {0,0,0,0,0,1,0,0,0,0,0}
    //};


    public static int[,] GenerateData(int rows, int columns)
    {
        int[,] maze = new int[rows, columns];

        // 初始化迷宫，所有位置都设置为墙壁（0）
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                maze[i, j] = 0;
            }
        }

        // 生成一条路径
        int row = 0;
        int col = 0;

        while (row != rows - 1 || col != columns - 1)
        {
            maze[row, col] = GetRandomNumber(1, 3);  // 随机生成一个非零数字作为路径的一部分

            if (row == rows - 1)
            {
                col++;
            }
            else if (col == columns - 1)
            {
                row++;
            }
            else
            {
                if (GetRandomNumber(0, 2) == 0)
                {
                    col++;
                }
                else
                {
                    row++;
                }
            }
        }

        maze[row, col] = GetRandomNumber(1, 9);  // 终点也作为路径的一部分

        return maze;
    }

    static int GetRandomNumber(int min, int max)
    {
        return Random.Range(min, max);
    }
}

/// <summary>
/// 道具排布数据
/// </summary>
public class ItemData
{
    public const int RecipeSize = 7;
    //0为空 1为金币  2为棕罐子 3为蓝罐子  4为棕宝箱  5为黄宝箱
    public static int[,] Recipe1 = new int[RecipeSize, RecipeSize] {
        { 0,0,0,0,0,0,0},
        { 0,0,0,0,0,0,0},
        { 0,0,0,0,0,0,0},
        { 0,0,0,1,0,0,0},
        { 0,0,1,2,1,0,0},
        { 0,1,0,0,0,1,0},
        { 0,0,0,0,0,0,0},
    };
    public static int[,] Recipe2 = new int[RecipeSize, RecipeSize] {
        { 0,0,0,0,0,0,0},
        { 0,0,0,0,0,0,0},
        { 0,0,0,0,0,1,0},
        { 0,0,0,0,1,2,0},
        { 0,0,0,0,1,2,0},
        { 0,0,0,0,0,1,0},
        { 0,0,0,0,0,0,0},
    };
    public static int[,] Recipe3 = new int[RecipeSize, RecipeSize] {
        { 0,0,0,0,0,0,0},
        { 0,0,0,0,0,0,0},
        { 0,0,1,1,1,0,0},
        { 0,1,0,3,0,1,0},
        { 0,1,0,0,0,1,0},
        { 0,0,1,1,1,0,0},
        { 0,0,0,0,0,0,0},
    }; 
    public static int[,] Recipe4 = new int[RecipeSize, RecipeSize] {
        { 0,0,0,0,0,0,0},
        { 0,0,0,0,0,0,0},
        { 0,0,0,1,0,0,0},
        { 4,0,0,1,0,0,4},
        { 0,0,0,1,0,0,0},
        { 0,0,0,1,0,0,0},
        { 0,0,0,0,0,0,0},
    };
}
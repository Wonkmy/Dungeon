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
        { 0,0,0,0,0,0,0},
        { 0,0,0,0,0,0,0},
        { 0,1,1,1,1,1,0},
        { 0,1,0,0,0,1,0},
        { 0,1,1,1,1,1,0},
        { 0,0,0,1,0,0,0},
        { 0,0,0,1,0,0,0}
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
    public static int[,] data = new int[11, 11] {
        {0,0,0,0,1,1,1,0,0,0,0},
        {0,0,0,0,1,1,1,0,0,0,0},
        {0,0,0,0,1,1,1,0,0,0,0},
        {0,0,0,0,1,1,1,0,0,0,0},
        {0,0,0,0,1,1,1,0,0,0,0},
        {0,0,0,0,1,1,1,0,0,0,0},
        {0,0,0,0,1,1,1,0,0,0,0},
        {0,0,0,0,1,1,1,0,0,0,0},
        {0,0,0,0,1,1,1,0,0,0,0},
        {0,0,0,0,1,1,1,0,0,0,0},
        {0,0,0,0,1,1,1,0,0,0,0}
    };
}

using UnityEngine;
using System.Collections.Generic;

public static class BlockShapeLibrary
{
    public static readonly List<BlockShapeData> Shapes = new()
    {
        // ===== 3 Ô THẲNG =====
        Shape(
            (0,0),(1,0),(2,0)
        ),
        Shape(
            (0,0),(0,1),(0,2)
        ),

        // ===== 4 Ô THẲNG =====
        Shape(
            (0,0),(1,0),(2,0),(3,0)
        ),
        Shape(
            (0,0),(0,1),(0,2),(0,3)
        ),

        // ===== 3x3 =====
        Shape(
            (1,0),(1,1),(2,1),
            (0,1),(1,1),(2,1),
            (0,2),(1,2),(2,2)
        ),

        // ===== 2x3 =====
        Shape(
            (0,0),(1,0),
            (0,1),(1,1),
            (0,2),(1,2)
        ),
        Shape(
            (0,0),(1,0),(2,0),
            (0,1),(1,1),(2,1)
        ),

        // ===== L SHAPE (4 HƯỚNG) =====
        Shape(
            (0,0),(0,1),(0,2),(1,0)
        ),
        Shape(
            (0,0),(1,0),(2,0),(2,1)
        ),
        Shape(
            (1,0),(1,1),(1,2),(0,2)
        ),
        Shape(
            (0,1),(1,1),(2,1),(0,0)
        ),

        // ===== T SHAPE (4 HƯỚNG) =====
        Shape(
            (0,0),(1,0),(2,0),(1,1)
        ),
        Shape(
            (0,0),(0,1),(0,2),(1,1)
        ),
        Shape(
            (0,1),(1,1),(2,1),(1,0)
        ),
        Shape(
            (1,0),(1,1),(1,2),(0,1)
        ),

        // ===== Z SHAPE (4 HƯỚNG) =====
        Shape(
            (0,1),(1,1),(1,0),(2,0)
        ),
        Shape(
            (1,0),(1,1),(0,1),(0,2)
        ),
        Shape(
            (0,0),(1,0),(1,1),(2,1)
        ),
        Shape(
            (0,0),(0,1),(1,1),(1,2)
        ),
    };

    private static BlockShapeData Shape(params (int x, int y)[] cells)
    {
        var list = new Vector2Int[cells.Length];
        for (int i = 0; i < cells.Length; i++)
            list[i] = new Vector2Int(cells[i].x, cells[i].y);

        return new BlockShapeData(list);
    }
}



[System.Serializable]
public class BlockShapeData
{
    public Vector2Int[] cells; // các ô cấu thành block

    public BlockShapeData(params Vector2Int[] cells)
    {
        this.cells = cells;
    }
}

using UnityEngine;
using System.Collections.Generic;

public class Block : MonoBehaviour
{
    [SerializeField] private SpriteRenderer cellPrefab;
    [SerializeField] private List<Sprite> blockColors; 
    [SerializeField] private float cellSpacing = 0.5f;

    private List<SpriteRenderer> spawnedCells = new();

    public void Init(BlockShapeData shape)
    {
        Clear();
        var color = GetRandomColor() ; 
        foreach (var cell in shape.cells)
        {
            var c = Instantiate(cellPrefab, transform);
            c.transform.localPosition = new Vector3(
                cell.x * cellSpacing,
                cell.y * cellSpacing,
                0
            );
            c.sprite = color;

            spawnedCells.Add(c);
        }
    }

    private void Clear()
    {
        foreach (var c in spawnedCells)
            Destroy(c.gameObject);

        spawnedCells.Clear();
    }

    private Sprite GetRandomColor() => blockColors[Random.Range(0,blockColors.Count -1)];
}

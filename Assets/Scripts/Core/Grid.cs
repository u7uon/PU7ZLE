using UnityEngine;

public class Grid : MonoBehaviour
{
    private  const  int size = 8;
    private const float cellSpacing = 0.68f; // Điều chỉnh khoảng cách

    [SerializeField] private GridCell cellPrefab; 
    [SerializeField] private Transform cellsParent;

    private readonly GridCell[,] cells = new GridCell[size, size];

    void Start()
    {
        // Tính offset để căn giữa grid
        float gridWidth = size  * cellSpacing;
        float offsetX = -gridWidth / 2f;
        float offsetY = -gridWidth / 2f;

        for(var r = 0; r < size; r++)
        {
            for(var c = 0; c < size; c++)
            {
                cells[r,c] = Instantiate(cellPrefab, cellsParent); 
                
                // QUAN TRỌNG: Dùng localPosition, không phải position
                cells[r,c].transform.localPosition = new Vector3(
                    c * cellSpacing + offsetX +0.3f, 
                    r * cellSpacing + offsetY + 0.3f, 
                    0.0f
                );
            }
        }
    }
}
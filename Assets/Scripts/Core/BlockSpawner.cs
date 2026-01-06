using Unity.VisualScripting;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private Block blockPrefab;
    [SerializeField] private Transform spawnParent;

    void OnEnable()
    {
        foreach(Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }

        for(int i = -2 ; i<= 2 ; i+= 2)
        {
           var block =  SpawnRandomBlock();
           block.gameObject.transform.localPosition = new Vector3( spawnParent.position.x + i , 0.0f, 0.0f   ) ;
           block.gameObject.transform.localScale = new(0.5f,0.5f); 
        }

    }

    public Block SpawnRandomBlock()
    {
        var block = Instantiate(blockPrefab, spawnParent);

        var shape = BlockShapeLibrary.Shapes[
            Random.Range(0, BlockShapeLibrary.Shapes.Count)
        ];

        block.Init(shape);

        return block; 
    }
}

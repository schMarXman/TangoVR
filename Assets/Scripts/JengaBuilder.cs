using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JengaBuilder : MonoBehaviour
{
    [SerializeField]
    private GameObject blockPrefab;

    [SerializeField] private Material alternativeBlockMaterial;

    private List<GameObject> blocks = new List<GameObject>();

    void Start()
    {
        //BuildTower(7);
    }

    public void BuildTower(int layerAmount)
    {
        if (blocks.Count != 0)
        {
            RemoveBlocks();
        }

        for (int i = 0; i < layerAmount; i++)
        {
            bool horizontal = i % 2 == 0;
            var spawnPosition = horizontal ? transform.position : new Vector3(blocks[1].transform.position.x, blocks[1].transform.position.y, blocks[1].transform.position.z - blockPrefab.transform.localScale.x);
            for (int j = 0; j < 3; j++)
            {
                var block = Instantiate(blockPrefab,
                    new Vector3(horizontal ? spawnPosition.x + j * blockPrefab.transform.localScale.x : spawnPosition.x,
                        spawnPosition.y + i * blockPrefab.transform.localScale.y,
                        !horizontal ? spawnPosition.z + j * blockPrefab.transform.localScale.x : spawnPosition.z),
                    horizontal ? Quaternion.identity : Quaternion.Euler(0, -90, 0));

                blocks.Add(block);

                if (blocks.Count % 2 == 0)
                {
                    block.GetComponent<MeshRenderer>().material = alternativeBlockMaterial;
                }

                if (i == 0)
                {
                    blocks[blocks.Count - 1].GetComponent<JengaBlock>().isBottomPiece = true;
                }
            }
        }
    }

    private void RemoveBlocks()
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            Destroy(blocks[i]);
        }

        blocks.Clear();
    }
}

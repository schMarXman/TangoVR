using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JengaBuilder : MonoBehaviour
{
    [SerializeField]
    private GameObject blockPrefab;

    private List<GameObject> blocks = new List<GameObject>();

    void Start()
    {
        BuildTower(7);
    }

    public void BuildTower(int layerAmount)
    {
        for (int i = 0; i < layerAmount; i++)
        {
            bool horizontal = i % 2 == 0;
            var spawnPosition = horizontal ? transform.position : new Vector3(blocks[1].transform.position.x, blocks[1].transform.position.y, blocks[1].transform.position.z - blockPrefab.transform.localScale.x);
            for (int j = 0; j < 3; j++)
            {
                blocks.Add(Instantiate(blockPrefab,
                    new Vector3(horizontal ? spawnPosition.x + j * blockPrefab.transform.localScale.x : spawnPosition.x, spawnPosition.y + i * blockPrefab.transform.localScale.y,
                        !horizontal ? spawnPosition.z + j * blockPrefab.transform.localScale.x : spawnPosition.z), horizontal ? Quaternion.identity : Quaternion.Euler(0, -90, 0)));

                if (i == 0)
                {
                    blocks[blocks.Count - 1].GetComponent<JengaBlock>().isBottomPiece = true;
                }
            }
        }
    }
}

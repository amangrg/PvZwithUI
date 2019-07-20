using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWorld : MonoBehaviour
{


    private int lawn_height = 5;
    private int lawn_width = 9;

    public GameObject lawn_tile;
    [HideInInspector]

    public Vector2[] lanePositions;

    [HideInInspector]
    public float game_over_line;

    // Start is called before the first frame update
    void Start()
    {
        lanePositions = new Vector2[5];
        generateLawn();
        invisibleWall();
    }


    void Update()
    {

    }

    private void invisibleWall()
    {
        GameObject tile = Instantiate(lawn_tile, new Vector2(-6.22f, 3f),
               Quaternion.identity, transform);

        game_over_line = tile.transform.position.x - 0.7f;
    }

    private void generateLawn()
    {
        for (int i = 0; i < lawn_height; i++)
        {
            for (int j = 0; j < lawn_width; j++)
            {
                GameObject tile = Instantiate(lawn_tile, new Vector2(-6.22f + 1.58f * (float)j, 3f - 1.68f * (float)i),
                Quaternion.identity, transform);

                if (j == 0)
                {
                    lanePositions[i] = new Vector2(tile.transform.position.x + 16f, tile.transform.position.y + 0.3f);
                }
            }
        }
    }
}

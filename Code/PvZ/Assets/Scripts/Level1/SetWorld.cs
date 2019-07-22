﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
The SetWorld class creates the grid and creates invisible wall to detect game over condition
*/
public class SetWorld : MonoBehaviour
{
    private int lawn_height = 5;
    private int lawn_width = 9;

    [SerializeField]
    private GameObject lawn_tile = null;
    [HideInInspector]

    private Vector2[] lanePositions;

    [HideInInspector]
    private float game_over_line = 0f;

    // Start is called before the first frame update (Autogenerated by UNITY)
    void Start()
    {
        lanePositions = new Vector2[5];
        generateLawn();
        invisibleWall();
    }

    /*
        Function: invisibleWall() function creates a boundary for game lost condition detection.
        Parameters: It takes no parameters.
        Usage: It is called in Start() function which will be called at the beginning when user plays game.
    */

    public float getGameOver()
    {
        return game_over_line;
    }

    private void invisibleWall()
    {
        GameObject tile = Instantiate(lawn_tile, new Vector2(-6.22f, 3f),
               Quaternion.identity, transform);

        game_over_line = tile.transform.position.x - 0.7f;
    }

    public Vector2 getLane()
    {
        return lanePositions[Random.Range(0, 5)];
    }
    /*
        Function: generateLawn() function creates a 5x9 using tile object. It also assigns lane positions to each row.
        Parameters: It takes no parameters.
        Usage: It is called in Start() function which will be called at the beginning when user plays game.
    */
    private void generateLawn()
    {
        for (int i = 0; i < lawn_height; ++i)
        {
            for (int j = 0; j < lawn_width; ++j)
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

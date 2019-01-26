using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class TileScript : MonoBehaviour {

    [Range(0, 100)]
    public int iniChance;
    [Range(1, 8)]
    public int birthLimit;
    [Range(1, 8)]
    public int deathLimit;

    [Range(1, 10)]
    public int numR;
    private int count = 0;

    private int[,] terrainMap;
    public Vector3Int tmpSize;
    public Tilemap topMap;
    public Tilemap botMap;
    public Tile[] topTile = new Tile[4];
    public Tile botTile;

    int width;
    int height;

    void Start()
    {
        doSim(numR);
    }

    public void doSim(int nu)
    {
        width = tmpSize.x;
        height = tmpSize.y;

        if (terrainMap == null)
        {
            terrainMap = new int[width, height];
            initPos();
        }


        for (int i = 0; i < nu; i++)
        {
            terrainMap = genTilePos(terrainMap);
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (terrainMap[x, y] == 1)
                {
                    if (y < height - 1)
                    {
                        if (terrainMap[x, y + 1] == 1)
                        {
                            topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), topTile[Random.Range(0, 2)]);
                        }
                        else
                        {
                            topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), topTile[Random.Range(2, 4)]);
                        }
                    }
                    else
                    {
                        topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), topTile[Random.Range(0, 2)]);
                    }
                }
                else
                    botMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), botTile);
            }
        }


    }

    public void initPos()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                terrainMap[x, y] = Random.Range(1, 101) < iniChance ? 1 : 0;
            }

        }

    }


    public int[,] genTilePos(int[,] oldMap)
    {
        int[,] newMap = new int[width, height];
        int neighb;
        BoundsInt myB = new BoundsInt(-1, -1, 0, 3, 3, 1);


        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                neighb = 0;
                foreach (var b in myB.allPositionsWithin)
                {
                    if (b.x == 0 && b.y == 0) continue;
                    if (x + b.x >= 0 && x + b.x < width && y + b.y >= 0 && y + b.y < height)
                    {
                        neighb += oldMap[x + b.x, y + b.y];
                    }
                    else
                    {
                        //neighb++;
                    }
                }

                if (oldMap[x, y] == 1)
                {
                    if (neighb < deathLimit) newMap[x, y] = 0;

                    else
                    {
                        newMap[x, y] = 1;

                    }
                }

                if (oldMap[x, y] == 0)
                {
                    if (neighb > birthLimit) newMap[x, y] = 1;

                    else
                    {
                        newMap[x, y] = 0;
                    }
                }

            }

        }
        return newMap;
    }
}

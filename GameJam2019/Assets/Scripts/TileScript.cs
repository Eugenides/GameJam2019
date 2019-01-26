using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class TileScript : MonoBehaviour {

    public TileList tileList;

    [Range(0, 100)]
    public int iniChance;
    [Range(1, 8)]
    public int birthLimit;
    [Range(1, 8)]
    public int deathLimit;

    [Range(1, 10)]
    public int numR;
    private int count = 0;
    public GridLayout gridLayout;
    private int[,] terrainMap;
    public Vector3Int tmpSize;
    public Tilemap topMap;
    public Tilemap botMap;
    public Tile botTile;

    public GameObject[] resources = new GameObject[10];
    public int[] numResources = new int[10];

    int width;
    int height;

    public int numOfGrassland;

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


        for (int i = 0; i < numResources.Length; i++)
        {
            numResources[i] = Random.Range(5, 16);
        }

        bool repeat = true;
        Vector3Int tempVec;
        do
        {
            tempVec = new Vector3Int(Random.Range(0, width), Random.Range(0, height), 0);
            if (terrainMap[tempVec.x, tempVec.y] == 1)
            {
                setBiome(tempVec.x, tempVec.y, 2);
                numOfGrassland--;
                if (numOfGrassland == 0)
                {
                    repeat = false;
                }
            }
        } while (repeat == true);

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
                            topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), tileList.topTile[Random.Range(0, 4)]);
                        }
                        else
                        {
                            topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), tileList.topTile[Random.Range(4, 8)]);
                        }
                    }
                    else
                    {
                        topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), tileList.topTile[Random.Range(0, 4)]);
                    }
                }
                else if (terrainMap[x, y] == 2)
                {
                    if (y < height - 1)
                    {
                        if (terrainMap[x, y + 1] == 2)
                        {
                            topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), tileList.topTile[Random.Range(8, 12)]);
                        }
                        else
                        {
                            topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), tileList.topTile[Random.Range(12, 16)]);
                        }
                    }
                    else
                    {
                        topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), tileList.topTile[Random.Range(8, 12)]);
                    }
                }
                else
                    botMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), botTile);
            }
        }

        for(int i = 0; i < numResources.Length; i++)
        {
            repeat = true;
            do
            {
                tempVec = new Vector3Int(Random.Range(0, width), Random.Range(0, height), 0);
                if (terrainMap[tempVec.x, tempVec.y] != 0)
                {
                    Instantiate(resources[i], new Vector3Int(-tempVec.x + width / 2, -tempVec.y + height / 2, 0), Quaternion.identity);
                    numResources[i]--;
                    if (tempVec.x < width - 1)
                    {
                        if (terrainMap[tempVec.x + 1, tempVec.y] == 1)
                        {
                            Instantiate(resources[i], new Vector3Int(-tempVec.x + width / 2 - 1, -tempVec.y + height / 2, 0), Quaternion.identity);
                        }
                    }
                    if (tempVec.x > 1)
                    {
                        if (terrainMap[tempVec.x - 1, tempVec.y] == 1)
                        {
                            Instantiate(resources[i], new Vector3Int(-tempVec.x + width / 2 + 1, -tempVec.y + height / 2, 0), Quaternion.identity);
                        }
                    }

                    if (tempVec.x < width - 1 && tempVec.y < height - 1)
                    {
                        if (terrainMap[tempVec.x + 1, tempVec.y + 1] == 1)
                        {
                            Instantiate(resources[i], new Vector3Int(-tempVec.x + width / 2 - 1, -tempVec.y + height / 2 - 1, 0), Quaternion.identity);
                        }
                    }
                    if (tempVec.x > 1 && tempVec.y > 1)
                    {
                        if (terrainMap[tempVec.x - 1, tempVec.y - 1] == 1)
                        {
                            Instantiate(resources[i], new Vector3Int(-tempVec.x + width / 2 + 1, -tempVec.y + height / 2 + 1, 0), Quaternion.identity);
                        }
                    }

                    if (tempVec.x < width - 1 && tempVec.y > 1)
                    {
                        if (terrainMap[tempVec.x + 1, tempVec.y - 1] == 1)
                        {
                            Instantiate(resources[i], new Vector3Int(-tempVec.x + width / 2 - 1, -tempVec.y + height / 2 + 1, 0), Quaternion.identity);
                        }
                    }
                    if (tempVec.x > 1 && tempVec.y < height - 1)
                    {
                        if (terrainMap[tempVec.x - 1, tempVec.y + 1] == 1)
                        {
                            Instantiate(resources[i], new Vector3Int(-tempVec.x + width / 2 + 1, -tempVec.y + height / 2 - 1, 0), Quaternion.identity);
                        }
                    }

                    if (tempVec.y > 1)
                    {
                        if (terrainMap[tempVec.x, tempVec.y - 1] == 1)
                        {
                            Instantiate(resources[i], new Vector3Int(-tempVec.x + width / 2, -tempVec.y + height / 2 + 1, 0), Quaternion.identity);
                        }
                    }
                    if (tempVec.y < height - 1)
                    {
                        if (terrainMap[tempVec.x, tempVec.y + 1] == 1)
                        {
                            Instantiate(resources[i], new Vector3Int(-tempVec.x + width / 2, -tempVec.y + height / 2 - 1, 0), Quaternion.identity);
                        }
                    }
                }
                if(numResources[i] == 0)
                {
                    repeat = false;
                }

            } while (repeat == true);
        }
        for (int i = 0; i < numResources.Length; i++)
        {
            numResources[i] = Random.Range(5, 16);
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

    public void setBiome(int xPos, int yPos, int biomeType)
    {
        terrainMap[xPos, yPos] = 2;

        if (xPos < width - 1)
        {
            if (terrainMap[xPos + 1, yPos] == 1)
            {
                setBiome(xPos + 1, yPos, biomeType);
            }
        }
        if (xPos > 1)
        {
            if (terrainMap[xPos - 1, yPos] == 1)
            {
                setBiome(xPos - 1, yPos, biomeType);
            }
        }

        if (xPos < width - 1 && yPos < height - 1)
        {
            if (terrainMap[xPos + 1, yPos + 1] == 1)
            {
                setBiome(xPos + 1, yPos + 1, biomeType);
            }
        }
        if (xPos > 1 && yPos > 1)
        {
            if (terrainMap[xPos - 1, yPos - 1] == 1)
            {
                setBiome(xPos - 1, yPos - 1, biomeType);
            }
        }

        if (xPos < width - 1 && yPos > 1)
        {
            if (terrainMap[xPos + 1, yPos - 1] == 1)
            {
                setBiome(xPos + 1, yPos - 1, biomeType);
            }
        }
        if (xPos > 1 && yPos < height - 1)
        {
            if (terrainMap[xPos - 1, yPos + 1] == 1)
            {
                setBiome(xPos - 1, yPos + 1, biomeType);
            }
        }

        if (yPos > 1)
        {
            if (terrainMap[xPos, yPos - 1] == 1)
            {
                setBiome(xPos, yPos - 1, biomeType);
            }
        }
        if (yPos < height - 1)
        {
            if (terrainMap[xPos, yPos + 1] == 1)
            {
                setBiome(xPos, yPos + 1, biomeType);
            }
        }
    }
}

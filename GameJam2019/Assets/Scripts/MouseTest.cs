using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;  

public class MouseTest : MonoBehaviour
{
    public TileList tileList;

    public GridLayout gridLayout;
    public Tilemap topMap;
    public Tilemap botMap;
    public Tile bridgeTile;
    public Tile bridgeTile2;
    public Tile regularTile;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3Int cellPosition = gridLayout.WorldToCell(pos);

            botMap.SetTile(cellPosition, null);

            if (topMap.GetTile(cellPosition) == null)
            {
                if (topMap.GetTile(new Vector3Int(cellPosition.x, cellPosition.y - 1, cellPosition.z)) == null)
                {
                    topMap.SetTile(cellPosition, bridgeTile);
                }
                else
                {
                    topMap.SetTile(cellPosition, bridgeTile2);
                }

                if (topMap.GetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z)) != null && topMap.GetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z)) != bridgeTile && topMap.GetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z)) != bridgeTile2)
                {
                    if (topMap.GetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z)) == tileList.topTile[4] || topMap.GetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z)) == tileList.topTile[5] || topMap.GetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z)) == tileList.topTile[6] || topMap.GetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z)) == tileList.topTile[7])
                    {
                        topMap.SetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z), tileList.topTile[Random.Range(0, 4)]);
                    }
                    else if (topMap.GetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z)) == tileList.topTile[12] || topMap.GetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z)) == tileList.topTile[13] || topMap.GetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z)) == tileList.topTile[14] || topMap.GetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z)) == tileList.topTile[15])
                    {
                        topMap.SetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z), tileList.topTile[Random.Range(8, 12)]);   
                    }
                }
                if(topMap.GetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z)) == bridgeTile)
                {
                    topMap.SetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z), bridgeTile2);
                }

            }

        }

    }
}

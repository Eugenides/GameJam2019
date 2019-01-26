using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;  

public class MouseTest : MonoBehaviour {

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
                    topMap.SetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z), regularTile);
                }
                if(topMap.GetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z)) == bridgeTile)
                {
                    topMap.SetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, cellPosition.z), bridgeTile2);
                }

            }

        }

    }
}

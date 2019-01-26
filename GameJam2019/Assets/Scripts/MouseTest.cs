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
            topMap.SetTile(cellPosition, bridgeTile);
        }

    }
}

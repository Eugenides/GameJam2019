using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCrafting : MonoBehaviour {

    //Reference to the image panel that holds the list of craftable items.
    public Image craftingPanel;

    //Reference to the player object's inventory.
    private PlayerInventory pInventory;

	// Use this for initialization
	void Start () {
        pInventory = GetComponent<PlayerInventory>();
	}
	
	// Update is called once per frame
	void Update () {
        //Enables the panel on screen to be seen or hidden.
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (craftingPanel.enabled == true)
                craftingPanel.enabled = false;
            else
                craftingPanel.enabled = true;
        }
	}

    public void CraftCraftingBench()
    {

    }
}

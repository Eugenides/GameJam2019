
using UnityEngine;

public class InventoryUI : MonoBehaviour {
    //TO DO: GET INVENTORY 
    //Inventory inventory;
    // Use this for initialization
    public Transform itemsParent;

    InventorySlot[] slots;

    public GameObject inventoryUI;
    public GameObject inventoryUIClosed;


	void Start () {

        //TO DO: ASSIGN INVETORY  
        //inventory = INventory.instance
        //inventory.onItemchangeCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}
	
	// Update is called once per frame
	void Update () {
        //toggleUI
        if (Input.GetButtonDown("Inventory"))
        {

            inventoryUI.SetActive(!inventoryUI.activeSelf);
            //TODO toggle on the smalll version of inventory with weight 
            inventoryUIClosed.SetActive(!inventoryUI.activeSelf);
        }

	}

    void UpdateUI()
    {
        Debug.Log("Update UI");

        for (int i = 0; i < slots.Length; i++)
        {

            /*if(i < inventory.items.Count){

                slots[i].ClearSlot();}*/
        }
    }
}

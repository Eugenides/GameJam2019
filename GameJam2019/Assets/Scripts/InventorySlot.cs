
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    //TODO: VAR ITEM OR ITEM TYPE
    GameObject item;//this is temporal until we get the right var
    public Image icon;

    public Button removeButton;

    public void AddItem(GameObject newItem/*Item newItem*/)
    {

        item = newItem;

        //icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {

        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton() {

        //Inventory.Remove(item);
        Debug.Log("removing item");
    }

    public void UseItem()
    {
        /* if(item != null)
         {

             item.Use();
             //create a use function in item class 
         }*/
        Debug.Log("use item");

    }
}

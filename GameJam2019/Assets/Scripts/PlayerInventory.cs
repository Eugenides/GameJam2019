using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

    //The player object's list of available resources.
    [SerializeField]
    private List<Resource> mResourceList;

    //Amount of weight(in kg.) that the backpack may hold.
    [SerializeField]
    private float maxBackpackCapacity;

    //Current amount of weight(in kg.) held in backpack.
    [SerializeField]
    private float currBackpackCapacity;

	// Use this for initialization
	void Start () {
        mResourceList = new List<Resource>();
        maxBackpackCapacity = 20.0f;
	}
	
	// Update is called once per frame
	void Update () {
        //Prints amount of resources in list.
        Debug.Log("Resources available: " + mResourceList.Count);
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        //Retrieve the gameobject of the collided object.
        GameObject collidedObject = c.gameObject;
        if(collidedObject.layer == LayerMask.NameToLayer("Resource"))
        {
            //Temporary resource.
            Resource r = new Resource();

            //Switch-Case to check what resource was collided with.
            switch (collidedObject.tag)
            {
                //Cases retrieve the respected resource type object and add to the resource list.
                case "Wood":
                    r = collidedObject.GetComponent<ResourceWood>().GetResource();
                    break;

                case "Stone":
                    r = collidedObject.GetComponent<ResourceStone>().GetResource();
                    break;

                case "Energy":
                    r = collidedObject.GetComponent<ResourceEnergy>().GetResource();
                    break;

                case "Metal":
                    r = collidedObject.GetComponent<ResourceMetal>().GetResource();
                    break;

                case "Organics":
                    r = collidedObject.GetComponent<ResourceOrganics>().GetResource();
                    break;

                case "Twine":
                    r = collidedObject.GetComponent<ResourceTwine>().GetResource();
                    break;

                case "AlienEnergy":
                    r = collidedObject.GetComponent<ResourceAlienEnergy>().GetResource();
                    break;

                case "Bone":
                    r = collidedObject.GetComponent<ResourceBone>().GetResource();
                    break;

                case "Glass":
                    r = collidedObject.GetComponent<ResourceGlass>().GetResource();
                    break;

                case "Clay":
                    r = collidedObject.GetComponent<ResourceClay>().GetResource();
                    break;

                default:
                    break;
            }

            if (r.GetWeight() + currBackpackCapacity < maxBackpackCapacity)
            {
                mResourceList.Add(r);
                Destroy(collidedObject);
            }
            else
                Debug.Log("Object is too heavy; Cannot add to Backpack.");

        }
    }

    public void AddWeightToBackpack(float weightToAdd)
    {
        if(currBackpackCapacity + weightToAdd < maxBackpackCapacity)
            currBackpackCapacity += weightToAdd;
    }

    public void IncreaseBackpackCapacity(float weightToAdd)
    {
        maxBackpackCapacity += weightToAdd;
    }
}

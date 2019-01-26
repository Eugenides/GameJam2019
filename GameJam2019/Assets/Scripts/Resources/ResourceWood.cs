using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceWood : MonoBehaviour {

    [SerializeField]
    private Wood mWoodResource;

	// Use this for initialization
	void Start () {

        mWoodResource = new Wood();
        mWoodResource.SetIcon(GetComponent<SpriteRenderer>().sprite);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Resource GetResource()
    {
        return mWoodResource;
    }
}

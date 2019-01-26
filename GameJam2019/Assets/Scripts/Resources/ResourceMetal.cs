using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceMetal : MonoBehaviour
{

    [SerializeField]
    private Metal mMetalResource;

    // Use this for initialization
    void Start()
    {
        mMetalResource = new Metal();
        mMetalResource.SetIcon(GetComponent<SpriteRenderer>().sprite);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Resource GetResource()
    {
        return mMetalResource;
    }
}


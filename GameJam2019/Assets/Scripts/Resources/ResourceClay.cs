using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceClay : MonoBehaviour
{

    [SerializeField]
    private Clay mClayResource;

    // Use this for initialization
    void Start()
    {
        mClayResource = new Clay();
        mClayResource.SetIcon(GetComponent<SpriteRenderer>().sprite);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Resource GetResource()
    {
        return mClayResource;
    }
}

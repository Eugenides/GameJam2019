using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGlass : MonoBehaviour
{

    [SerializeField]
    private Glass mGlassResource;

    // Use this for initialization
    void Start()
    {
        mGlassResource = new Glass();
        mGlassResource.SetIcon(GetComponent<SpriteRenderer>().sprite);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Resource GetResource()
    {
        return mGlassResource;
    }
}


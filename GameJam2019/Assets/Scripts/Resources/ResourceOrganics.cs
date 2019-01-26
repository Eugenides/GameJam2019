using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceOrganics : MonoBehaviour
{

    [SerializeField]
    private Organics mOrganicsResource;

    // Use this for initialization
    void Start()
    {
        mOrganicsResource = new Organics();
        mOrganicsResource.SetIcon(GetComponent<SpriteRenderer>().sprite);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Resource GetResource()
    {
        return mOrganicsResource;
    }
}

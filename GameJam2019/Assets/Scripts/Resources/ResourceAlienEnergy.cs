using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceAlienEnergy : MonoBehaviour
{

    [SerializeField]
    private AlienEnergy mAlienEnergyResource;

    // Use this for initialization
    void Start()
    {
        mAlienEnergyResource = new AlienEnergy();
        mAlienEnergyResource.SetIcon(GetComponent<SpriteRenderer>().sprite);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Resource GetResource()
    {
        return mAlienEnergyResource;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceEnergy : MonoBehaviour
{

    [SerializeField]
    private Energy mEnergyResource;

    // Use this for initialization
    void Start()
    {
        mEnergyResource = new Energy();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Resource GetResource()
    {
        return mEnergyResource;
    }
}

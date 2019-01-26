using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceStone : MonoBehaviour
{

    [SerializeField]
    private Stone mStoneResource;

    // Use this for initialization
    void Start()
    {
        mStoneResource = new Stone();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Resource GetResource()
    {
        return mStoneResource;
    }
}

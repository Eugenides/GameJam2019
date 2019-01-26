using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBone : MonoBehaviour
{

    [SerializeField]
    private Bone mBoneResource;

    // Use this for initialization
    void Start()
    {
        mBoneResource = new Bone();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Resource GetResource()
    {
        return mBoneResource;
    }
}

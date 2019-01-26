using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTwine : MonoBehaviour
{

    [SerializeField]
    private Twine mTwineResource;

    // Use this for initialization
    void Start()
    {
        mTwineResource = new Twine();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Resource GetResource()
    {
        return mTwineResource;
    }
}


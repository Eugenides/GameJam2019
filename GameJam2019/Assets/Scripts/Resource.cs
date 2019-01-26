using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource {

    //Enumerator to organize and identify different kinds of resources.
    public enum ResourceType
    {
        WOOD, 
        STONE,
        ENERGY,
        METAL,
        ORGANICS,
        TWINE,
        ALIEN_ENERGY,
        BONE,
        GLASS,
        CLAY,
    }

    //Every inherited child will have a type associated with it and a utility function to retrieve it.
    protected ResourceType type;

    //Time it takes to harvest the resource.
    protected float collectionTime;

    //Mass of the resource
    protected float weight;

    //Retrieve what type of Resource enum this object is.
    public virtual ResourceType GetResourceType() {

        return type;
    }

    //Retrieve the weight (in kg.) of this resource object.
    public virtual float GetWeight()
    {
        return weight;
    }

}

//Class for Wood Resource
public class Wood : Resource
{
    public Wood()
    {
        type = ResourceType.WOOD;
        collectionTime = 2.0f;
        weight = 1.0f;
    }
}

//Class for Stone Resource
public class Stone : Resource
{
    public Stone()
    {
        type = ResourceType.STONE;
        collectionTime = 2.0f;
        weight = 1.0f;
    }
}

//Class for Energy Resource
public class Energy : Resource
{
    public Energy()
    {
        type = ResourceType.ENERGY;
        collectionTime = 2.0f;
        weight = 1.0f;
    }
}

//Class for Metal Resource
public class Metal : Resource
{
    public Metal()
    {
        type = ResourceType.METAL;
        collectionTime = 2.0f;
        weight = 1.0f;
    }
}

//Class for Organics Resource
public class Organics : Resource
{
    public Organics()
    {
        type = ResourceType.ORGANICS;
        collectionTime = 2.0f;
        weight = 1.0f;
    }
}

//Class for Twine Resource
public class Twine : Resource
{
    public Twine()
    {
        type = ResourceType.TWINE;
        collectionTime = 2.0f;
        weight = 1.0f;
    }
}

//Class for AlienEnergy Resource
public class AlienEnergy : Resource
{
    public AlienEnergy()
    {
        type = ResourceType.ALIEN_ENERGY;
        collectionTime = 2.0f;
        weight = 1.0f;
    }
}

//Class for Bone Resource
public class Bone : Resource
{
    public Bone()
    {
        type = ResourceType.BONE;
        collectionTime = 2.0f;
        weight = 1.0f;
    }
}

//Class for Glass Resource
public class Glass : Resource
{
    public Glass()
    {
        type = ResourceType.GLASS;
        collectionTime = 2.0f;
        weight = 1.0f;
    }
}

//Class for Clay Resource
public class Clay : Resource
{
    public Clay()
    {
        type = ResourceType.CLAY;
        collectionTime = 2.0f;
        weight = 1.0f;
    }
}



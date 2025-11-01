using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Charm", menuName = "Scriptable Objects/Charm")]
public class Charm : ScriptableObject
{
    public enum CharmType
    {
        MUSHPEARL,
        EYECLOVER
    }

    [HideInInspector]
    public const float ALIGNMENT_RANGE = 500;

    public Sprite sprite;

    public CharmComponent firstComponent; // first charm component
    public CharmComponent secondComponent; // second charm component

    public CharmType charmType;

    public float alignment; // negative - evil side, around 0 is neutral, positive - good

    

}

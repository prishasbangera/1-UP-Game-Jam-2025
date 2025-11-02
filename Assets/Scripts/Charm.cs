using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Charm", menuName = "Scriptable Objects/Charm")]
public class Charm : ScriptableObject
{
    public enum CharmType
    {
        EYECHARM,
        EYEPEARL,
        EYEFUR,
        EYECRYSTAL,
        EYECLOVER,
        MUSHCHARM,
        MUSHPEARL,
        MUSHFUR,
        MUSHCRYSTAL,
        MUSHCLOVER,
        PEARLEYE,
        PEARLMUSH,
        PEARLCHARM,
        PEARLCRYSTAL,
        FUREYE,
        FURMUSH,
        FURCHARM,
        FURCLOVER,
        CRYSTALEYE,
        CRYSTALMUSH,
        CRYSTALPEARL,
        CRYSTALCLOVER,
        CLOVEREYE,
        CLOVERMUSH,
        CLOVERFUR,
        CLOVERCRYSTAL,
        CLOVERCHARM
    }

    [HideInInspector]
    public const float ALIGNMENT_RANGE = 6;

    public Sprite sprite;

    public CharmComponent firstComponent; // first charm component
    public CharmComponent secondComponent; // second charm component

    public CharmType charmType;

    public int alignment; // negative - evil side, around 0 is neutral, positive - good
    
    

}

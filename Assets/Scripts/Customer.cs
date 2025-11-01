using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Customer", menuName = "Scriptable Objects/Customer")]
public class Customer : ScriptableObject
{
    public enum CustomerType
    {
        WITCH,
        SLIMEDOG
    }


    [HideInInspector]
    public const float ALIGNMENT_RANGE = 20;

    public int patience; // amount of seconds that the customer will wait before leaving

    public Sprite sprite;

    public CustomerType customerType;

    public float alignment; // negative - evil side, around 0 is neutral, positive - good

}

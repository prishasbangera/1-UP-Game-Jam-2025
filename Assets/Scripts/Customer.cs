using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Customer", menuName = "Scriptable Objects/Customer")]
public class Customer : ScriptableObject
{
    public enum CustomerType
    {
        WITCH,
        SLIMEDOG,
        GOBLIN
    }

    public static Array customerTypeValues = Enum.GetValues(typeof(CustomerType));

    [HideInInspector]
    public const int ALIGNMENT_RANGE = 6;
    [SerializeField] public const int BUY_RANGE = 3;

    public int patience; // amount of seconds that the customer will wait before leaving

    public Sprite sprite;

    public CustomerType customerType;

    public int alignment; // negative - evil side, around 0 is neutral, positive - good


    public Customer(CustomerType customerType)
    {
        // Random customer type is passed in
        this.customerType = customerType;
        // Alignment goes from min to max range + anywhere between
        alignment = (int)(UnityEngine.Random.Range(-1,1) * ALIGNMENT_RANGE); 
        // Patience goes from 90 to 180 seconds
        patience = (int)(UnityEngine.Random.Range(0, 1) * 90) + 90;
    }

}

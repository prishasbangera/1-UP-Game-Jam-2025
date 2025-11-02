using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//[CreateAssetMenu(fileName = "Customer", menuName = "Scriptable Objects/Customer")]
public class Customer
{
    public enum CustomerType
    {
        SLIMEDOG,
        GOBLIN
    }

    public static Array customerTypeValues = Enum.GetValues(typeof(CustomerType));

    [HideInInspector]
    public const int ALIGNMENT_RANGE = 6;
    [SerializeField] public const int BUY_RANGE = 3;

    [SerializeField] public int patience = 60; // amount of seconds that the customer will wait before leaving

    public Sprite sprite;

    public CustomerType customerType;

    public int alignment; // negative - evil side, around 0 is neutral, positive - good

    public int entered = 5; // wait 5 seconds before checking for bracelets

    public GameObject customerPanel = null;


    public Customer(CustomerType customerType)
    {
        // Random customer type is passed in
        this.customerType = customerType;
        // Alignment goes from min to max range + anywhere between
        alignment = (int)(UnityEngine.Random.Range(-1,1) * ALIGNMENT_RANGE); 
    }

}

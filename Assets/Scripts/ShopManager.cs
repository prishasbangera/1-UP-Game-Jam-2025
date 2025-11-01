using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour, ShopManagerInterface
{
    public static ShopManager Instance { get; private set; }   // allows read-only access to the RecipeBook instance

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);   // Destroy duplicate instances of RecipeBook
        }
    }


    public List<CharmComponent> inventoryList;
    public List<Bracelet> braceletsForSaleList;
    public Bracelet currentBracelet = null;

    private CharmCreator charmCreator;

    public void InitializeShop()
    {
        braceletsForSaleList = new List<Bracelet>();
        charmCreator = new CharmCreator();
        StartNewBracelet();
        RefreshInventory();
    }
    public void AddBraceletToShop()
    {
        throw new System.NotImplementedException();
    }

    public void AddCharmToBracelet(Charm charm)
    {
        // Invarient: bracelet must not be full here

        // Add charm

        currentBracelet.AddCharmToBracelet(charm);
        UpdateCraftingDisplay();

        // Now bracelet may be full

        if (currentBracelet.charmList.Count >= currentBracelet.maxCharms) {
            braceletsForSaleList.Add(currentBracelet);
            StartNewBracelet();
            RefreshInventory();
        }

        UpdateBraceletDisplay();

    }

    /// <summary>
    /// Only call when you change the inventory
    /// </summary>
    public void UpdateInventoryDisplay()
    {
        throw new System.NotImplementedException();
    }

    public void RefreshInventory()
    {
        // TODO

        UpdateInventoryDisplay();
        throw new System.NotImplementedException();
    }

    public void StartNewBracelet()
    {
        int braceletSize = Random.Range(2, 6);
        currentBracelet = new Bracelet(braceletSize);
        UpdateBraceletDisplay();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeShop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBraceletDisplay()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateCraftingDisplay()
    {
        throw new System.NotImplementedException();
    }
}

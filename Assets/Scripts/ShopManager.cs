using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour, ShopManagerInterface
{
    public static ShopManager Instance { get; private set; }   // allows read-only access to the RecipeBook instance

    [SerializeField]
    private List<CharmComponent> componentPool = new List<CharmComponent>();


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

    public CharmCreator charmCreator;

    public void InitializeShop()
    {
        braceletsForSaleList = new List<Bracelet>();
        charmCreator = new CharmCreator();
        StartNewBracelet();
        RefreshInventory();
    }



    public void AddCharmToBracelet(Charm charm)
    {
        // Invariant: bracelet must not be full here

        // Add charm

        currentBracelet.AddCharm(charm);
        UpdateCraftingDisplay();

        Debug.Log("Added charm to bracelet");

        // Now bracelet may be full

        if (currentBracelet.charmList.Count >= currentBracelet.maxCharms) {
            braceletsForSaleList.Add(currentBracelet);
            StartNewBracelet();
            RefreshInventory();
            Debug.Log("New bracelet was started");
        }

        UpdateCurrentBraceletDisplay();

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
        inventoryList.Clear();

        int newInventorySize = Random.Range(5, 10);
        for (int i = 0; i < newInventorySize; i++)
        {
            int randInd = Random.Range(0, CharmComponent.NUM_COMPONENT_TYPES);
            CharmComponent cc = new CharmComponent();
        }

        UpdateInventoryDisplay();
        throw new System.NotImplementedException();
    }

    public void StartNewBracelet()
    {
        int braceletSize = Random.Range(2, 6);
        currentBracelet = new Bracelet(braceletSize);
        UpdateCurrentBraceletDisplay();
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

    public void UpdateCurrentBraceletDisplay()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateCraftingDisplay()
    {
        throw new System.NotImplementedException();
    }

    public void AddBraceletToDisplay()
    {
        throw new System.NotImplementedException();
    }
}

using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour, ShopManagerInterface
{
    public static ShopManager Instance { get; private set; }   // allows read-only access to the RecipeBook instance

    [SerializeField]
    private List<CharmComponent> componentPool = new List<CharmComponent>();


    [SerializeField]
    private Button craftButton;
    private GameObject component1Panel;
    private GameObject component2Panel;

    public List<CharmComponent> inventoryList;
    public List<Bracelet> braceletsForSaleList;
    public Bracelet currentBracelet = null;

    public CharmCreator charmCreator;

    private void Awake()
    {
        craftButton.onClick.AddListener(charmCreator.CraftButtonOnClick);

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

    public void RefreshInventory()
    {
        inventoryList.Clear();

        int newInventorySize = Random.Range(5, 10);
        for (int i = 0; i < newInventorySize; i++)
        {
            int randInd = Random.Range(0, CharmComponent.NUM_COMPONENT_TYPES);
            CharmComponent cc = Instantiate(componentPool[randInd]);
            inventoryList.Add(cc);
        }

        Debug.Log("New inventory created.");

        UpdateInventoryDisplay();
    }

    public void StartNewBracelet()
    {
        int braceletSize = Random.Range(2, 6);
        currentBracelet = new Bracelet(braceletSize);
        UpdateCurrentBraceletDisplay();
    }
    public void UpdateInventoryDisplay()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateCurrentBraceletDisplay()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateCraftingDisplay()
    {
        throw new System.NotImplementedException();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeShop();
    }

    public void RemoveBraceletFromDisplay(Bracelet bracelet)
    {
        throw new System.NotImplementedException();
    }

    public void AddBraceletToDisplay(Bracelet bracelet)
    {
        throw new System.NotImplementedException();
    }
}

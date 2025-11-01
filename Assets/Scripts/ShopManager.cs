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
    [SerializeField]
    private ComponentUIBox component1UI;
    [SerializeField]
    private ComponentUIBox component2UI;
    [SerializeField]
    private GameObject shelfUIBox;
    [SerializeField] private ComponentUIBox componentUIBoxPrefab;

    private List<CharmComponent> inventoryList = new();
    public List<Bracelet> braceletsForSaleList = new();
    public Bracelet currentBracelet = null;

    [HideInInspector]
    public CharmCreator charmCreator;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            charmCreator = new CharmCreator();
        }
        else
        {
            Destroy(gameObject);   // Destroy duplicate instances of RecipeBook
        }
    }


    public void InitializeShop()
    {
        Debug.Log("initialized shop");
        braceletsForSaleList = new List<Bracelet>();

        RefreshInventory();

        craftButton.onClick.AddListener(charmCreator.CraftButtonOnClick);

        StartNewBracelet();

    }

    public void CharmComponentOnClick(CharmComponent c)
    {
        Debug.Log("compoennt ui box clicked: " + c.componentType);
        charmCreator.IngredientOnClick(c);
        UpdateCraftingDisplay();
        UpdateInventoryDisplay();
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
        int numChildren = shelfUIBox.transform.childCount;
        for (int i = numChildren; i >= 0; i--)
        {
            Destroy(shelfUIBox.transform.GetChild(0).gameObject);
        }

        for (int i = 0; i < inventoryList.Count; i++)
        {
            ComponentUIBox box = Instantiate(componentUIBoxPrefab);
            box.SetComponent(inventoryList[i]);
            box.transform.SetParent(shelfUIBox.transform, false);
        }
        Debug.Log("refershed inventsoty, now" + inventoryList.Count + "components.");

    }

    public void UpdateCurrentBraceletDisplay()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateCraftingDisplay()
    {
        CharmComponent[] comps = charmCreator.craftingArea;
        if (comps[0])
        {
            component1UI.SetComponent(comps[0]);
        }
        else
        {
            component1UI.SetComponent(null);
        }


        if (comps[1])
        {
            component2UI.SetComponent(comps[1]);
        } else
        {
            component2UI.SetComponent(null);
        }
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

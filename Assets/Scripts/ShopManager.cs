using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour, ShopManagerInterface
{

    [SerializeField] public int MIN_INVENTORY_COUNT = 15;
    [SerializeField] public int MAX_INVENTORY_COUNT = 30;
    [SerializeField] public int MIN_BRACELET_LENGTH = 2;
    [SerializeField] public int MAX_BRACELET_LENGTH = 6;
    public static ShopManager Instance { get; private set; }   // allows read-only access to the RecipeBook instance

    [SerializeField]
    private List<CharmComponent> componentPool = new List<CharmComponent>();
    [SerializeField]
    private GameObject[] workingCharmsUI; // contains the charm uis on the working bracelet
    [SerializeField] GameObject workingBraceletAffinityText;
    [SerializeField] GameObject workingBraceletNumCharmsText;

    [SerializeField]
    private Button craftButton;
    [SerializeField]
    private GameObject component1Panel;
    [SerializeField]
    private GameObject component2Panel;
    [SerializeField]
    private GameObject shelfUIBox;
    [SerializeField] private ComponentUIBox componentUIBoxPrefab;
    [SerializeField]
    private GameObject forSaleShelf;

    private List<CharmComponent> inventoryList = new();
    public List<Bracelet> braceletsForSaleList = new(); // list of bracelets for sale
    public Bracelet currentBracelet = null;

    [HideInInspector]
    public CharmCreator charmCreator;

    private TMP_Text alignmentText;

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
        alignmentText = workingBraceletAffinityText.GetComponent<TMP_Text>();
        Debug.Log("initialized shop");
        braceletsForSaleList = new List<Bracelet>();

        RefreshInventory();

        craftButton.onClick.AddListener(charmCreator.CraftButtonOnClick);

        StartNewBracelet();

    }

    public void CharmComponentOnClick(ComponentUIBox box)
    {
        //Debug.Log("compnent ui box clicked: " + c.componentType);
        charmCreator.IngredientOnClick(box.assignedComponent);

        // Update display

        UpdateBoxPosition(box);

    }
    public void AddCharmToBracelet(Charm charm)
    {
        // Invariant: bracelet must not be full here

        // Add charm

        currentBracelet.AddCharm(charm);

        Debug.Log("Added charm to bracelet");

        // Now bracelet may be full

        if (currentBracelet.charmList.Count >= currentBracelet.maxCharms) {
            braceletsForSaleList.Add(currentBracelet);
            StartNewBracelet();
            RefreshInventory();
            Debug.Log("New bracelet was started");
        }

        ClearCraftingDisplay();
        UpdateCurrentBraceletDisplay();

    }

    public List<Bracelet> GetBraceletsForSale()
    {
        return braceletsForSaleList;
    }

    public void BuyBracelet(Bracelet bracelet)
    {
        throw new System.NotImplementedException("not implemeted");
        
    }

    public void RefreshInventory()
    {
        inventoryList.Clear();

        int newInventorySize = Random.Range(MIN_INVENTORY_COUNT, MAX_INVENTORY_COUNT);
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
        int braceletSize = Random.Range(MIN_BRACELET_LENGTH, MAX_BRACELET_LENGTH);
        currentBracelet = new Bracelet(braceletSize);
        workingBraceletNumCharmsText.GetComponent<TMP_Text>().text = "Make a " + braceletSize + "-Charm Bracelet";

        //UpdateCurrentBraceletDisplay();
    }
    public void UpdateInventoryDisplay()
    {
        // Clear old boxes
        foreach (Transform child in shelfUIBox.transform)
        {
            Destroy(child.gameObject);
        }

        // Create components
        for (int i = 0; i < inventoryList.Count; i++)
        {
            ComponentUIBox box = Instantiate(componentUIBoxPrefab);
            box.SetComponent(inventoryList[i]);
            box.transform.SetParent(shelfUIBox.transform, false);

            // Button on click
            Button button = box.GetComponent<Button>();
            button.onClick.AddListener(box.OnClick);
        }
        Debug.Log("refershed inventsoty, now " + inventoryList.Count + " components.");

    }

    public void UpdateCurrentBraceletDisplay()
    {
        // Set charm images
        for (int i = 0; i < currentBracelet.charmList.Count; i++)
        {
            Sprite s = currentBracelet.charmList[i].sprite;
            if (s) workingCharmsUI[i].GetComponent<Image>().sprite = s;
            else workingCharmsUI[i].GetComponent<Image>().sprite = null;
        }

        // Empty out other images
        for (int i = currentBracelet.charmList.Count; i < MAX_BRACELET_LENGTH; i++)
        {
            workingCharmsUI[i].GetComponent<Image>().sprite = null;
        }

        // Update Text
        int alignment = currentBracelet.CalculateAlignment();
        alignmentText.text = "CURRENT ALIGNMENT: " + alignment;

        if (alignment < 0)
        {
            alignmentText.color = new Color(150, 0, 0);
        } else if (alignment > 0)
        {
            alignmentText.color = new Color(0, 150, 0);
        } else
        {
            alignmentText.color = new Color(255, 255, 255);
        }
        
    }

    public void UpdateBoxPosition(ComponentUIBox box)
    {
        if (box == null) { return; }

        if (box.assignedComponent == null) { return; }

        if (box.assignedComponent.craftingAreaLocation < 0)
        {
            // Item WAS on crafting area and now is on in the inventory box
            inventoryList.Add(box.assignedComponent);
            box.transform.SetParent(shelfUIBox.transform);
            Debug.Log("Moved box position to inventory");
        } else
        {
            // Item WAS on inventory box, now in crafting area
            inventoryList.Remove(box.assignedComponent);
            
            if (box.assignedComponent.craftingAreaLocation == 0)
            {
                box.transform.position = component1Panel.transform.position;
                box.transform.parent = component1Panel.transform;
            } else
            {
                box.transform.position = component2Panel.transform.position;
                box.transform.parent = component2Panel.transform;
            }
        }
    }


    public void ClearCraftingDisplay()
    {
        GameObject c1 = component1Panel.transform.GetChild(0).gameObject;
        GameObject c2 = component2Panel.transform.GetChild(0).gameObject;
        
        if (c1) Destroy(c1);
        if (c2) Destroy(c2);

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
        bracelet.CreateCompletedBraceletImage();
        bracelet.completedBraceletImage.transform.SetParent(forSaleShelf.transform);
    }
}

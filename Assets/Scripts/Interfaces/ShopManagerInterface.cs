using UnityEngine;

public interface ShopManagerInterface
{
    /// <summary>
    /// Call when the game starts
    /// </summary>
    public void InitializeShop();

    public void CharmComponentOnClick(ComponentUIBox componentUI);

    // Maintain an instance of bracelet that is being made
    // And maintain list of bracelets that were made

    // Bracelet Methods

    /// <summary>
    /// // add charm to current bracelet, add to shop if done
    /// </summary>
    public void AddCharmToBracelet(Charm charm); 

    /// <summary>
    /// Start a new bracelet by generating new inventory, getting new wire
    /// </summary>
    public void StartNewBracelet();

    // Inventory Methods

    /// <summary>
    /// Flush the inventory list
    /// Generate new inventory of random size and display it
    /// </summary>
    public void RefreshInventory();

    /// <summary>
    /// Use the Inventory Box Panel to display all new items and when we move stuff around
    /// </summary>
    public void UpdateInventoryDisplay();

    public void RemoveBraceletFromDisplay(Bracelet bracelet);

    public void AddBraceletToDisplay(Bracelet bracelet);

    public void UpdateCurrentBraceletDisplay();

    public void UpdateCraftingDisplay();

}

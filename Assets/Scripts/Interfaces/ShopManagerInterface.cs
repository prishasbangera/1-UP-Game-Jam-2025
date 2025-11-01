using UnityEngine;

public interface ShopManagerInterface
{
    /// <summary>
    /// Call when the game starts
    /// </summary>
    public void InitializeShop();

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

    public void AddBraceletToShop(); // add created bracelet to shop list and start new bracelet

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

    public void UpdateBraceletDisplay();

    public void UpdateCraftingDisplay();

}

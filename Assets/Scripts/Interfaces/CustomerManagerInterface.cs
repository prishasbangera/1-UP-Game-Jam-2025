using UnityEngine;

public interface CustomerManagerInterface
{
    /// <summary>
    /// // Function: Every so often, spawn a new customer
    /// </summary>
    public void SpawnCustomer();

    /// <summary>
    /// // Function: Check whether a customer will buy any bracelets
    /// For each bracelet in the bracelets for sale list, compare its alignment to this customer
    /// </summary>
    public bool CheckBuyWillingness(Customer customer);

    /// <summary>
    /// // Function: Call this when a customer buys a bracelet or runs out of time
    /// </summary>
    public void DespawnCustomer(Customer customer);

    /// <summary>
    /// // Function: Display customer sprites
    /// </summary>
    public void UpdateCustomerDisplay();
}

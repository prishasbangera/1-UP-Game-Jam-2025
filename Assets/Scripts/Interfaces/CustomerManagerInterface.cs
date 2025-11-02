using UnityEngine;

public interface CustomerManagerInterface
{
    /// <summary>
    /// // Function: Every so often, spawn a new customer
    /// </summary>
    public void SpawnCustomer();

    /// <summary>
    /// // Function: Check to see if a customer will buy a bracelet
    /// </summary>
    public bool CheckBuyWillingness(Customer customer, Bracelet bracelet);

    /// <summary>
    /// // Function: Call this when a customer buys a bracelet or runs out of time
    /// </summary>
    public void DespawnCustomer(Customer customer);

    /// <summary>
    /// // Function: Display customer sprites
    /// </summary>
    public void UpdateCustomerDisplay();
}

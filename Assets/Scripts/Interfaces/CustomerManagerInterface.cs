using UnityEngine;

public interface CustomerManagerInterface
{
    // Function: Every so often, spawn a new customer
    public void CustomerSpawner();

    // Function: Check to see if a customer will buy a bracelet
    public bool CheckBuyWillingness(Customer customer, Bracelet bracelet);

    // Function: Call this when a customer buys a bracelet or runs out of time
    public void CustomerDespawner();
}

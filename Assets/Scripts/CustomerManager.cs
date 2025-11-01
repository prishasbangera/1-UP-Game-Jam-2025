using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Purchasing;
using static Customer;

public class CustomerManager : MonoBehaviour, CustomerManagerInterface
{
    public static CustomerManager Instance { get; private set; }   // allows read-only access to the RecipeBook instance

    public List<Customer> customerList;

    [SerializeField] public int spawnMin;
    [SerializeField] public int spawnMax;
    public float spawnInterval;
    public float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnCustomer(); // Call the method to spawn the object
            timer = 0f; // Reset the timer
        }
    }

    private void Awake()
    {
        // Calculated once at the start and recalculated after a customer spawns, to be used for next customer
        spawnInterval = UnityEngine.Random.Range(spawnMin, spawnMax);

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

    public void SpawnCustomer()
    {
        // Make a new customer with random traits and add to list
        int randomIndex = UnityEngine.Random.Range(0, Customer.customerTypeValues.Length);
        CustomerType type = (CustomerType)Customer.customerTypeValues.GetValue(randomIndex);

        Customer customer = new Customer(type);
        customerList.Add(customer);
        Debug.Log("Spawned " + customer.customerType + " after " +spawnInterval+ " seconds");

        // Calculate time until next customer spawns
        spawnInterval = UnityEngine.Random.Range(spawnMin, spawnMax);
    }

    public bool CheckBuyWillingness(Customer customer, Bracelet bracelet)
    {
        throw new System.NotImplementedException();
    }

    public void DespawnCustomer(Customer customer)
    {
        customerList.Remove(customer);
        Debug.Log("Removed " + customer.customerType + " customer");
    }
}

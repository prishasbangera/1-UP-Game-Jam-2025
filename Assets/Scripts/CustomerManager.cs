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
    public int spawnInterval;
    public float spawnTimer;
    public float patienceTimer;

    void Update()
    {
        spawnTimer += Time.deltaTime; // this one gets set back to 0
        patienceTimer += Time.deltaTime; // this one keeps going the whole time

        // Every so often, spawn a customer
        if (spawnTimer >= spawnInterval)
        {
            SpawnCustomer();
            spawnTimer = 0f;
        }

        if (patienceTimer % 1.0 == 0.0) // not sure if this will work since it has to be exactly a second, can check a small range instead
        {
            // Decrease every present customer's patience, if it goes below 0 then they leave
            for (int i=0; i<customerList.Count; i++)
            {
                Customer customer = customerList[i];
                customer.patience--;
                if (customer.patience < 0)
                {
                    DespawnCustomer(customer);
                }
                // This is what controls new customers waiting 5 seconds before checking for bracelets
                if (customer.entered > 0)
                {
                    customer.entered--;
                }
            }
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
        UpdateCustomerDisplay();
        Debug.Log("Spawned " + customer.customerType + " after " +spawnInterval+ " seconds");

        // Calculate time until next customer spawns
        spawnInterval = UnityEngine.Random.Range(spawnMin, spawnMax);
    }

    public bool CheckBuyWillingness(Customer customer, Bracelet bracelet)
    {
        throw new System.NotImplementedException();
        // check if customer.entered is above 0, if it is then keep waiting
        // wait 5 seconds and then check for bracelets
        /*if (customer.entered>0)
                {
                    customer.entered--;
                }*/
    }

    public void DespawnCustomer(Customer customer)
    {
        customerList.Remove(customer);
        UpdateCustomerDisplay();
        Debug.Log("Removed " + customer.customerType + " customer");
    }

    public void UpdateCustomerDisplay()
    {
        throw new System.NotImplementedException();
    }
}

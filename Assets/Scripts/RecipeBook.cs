using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains the undirected graph for charm recipes.
/// </summary>
public class RecipeBook : MonoBehaviour
{
    public static RecipeBook Instance { get; private set; }   // allows read-only access to the RecipeBook instance

    [SerializeField]
    public List<Charm> charmsRecipeList;

    private void Awake()
    {
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

    void Start()
    {
        // TODO: Go through list of charms and build the adj matrix

       
    }

    
}

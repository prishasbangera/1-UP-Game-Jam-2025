using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains the undirected graph for charm recipes.
/// </summary>
public class RecipeBook : MonoBehaviour
{
    public static RecipeBook Instance { get; private set; }   // allows read-only access to the RecipeBook instance

    [SerializeField]
    private List<Charm> charmsRecipeList; // inital list

    private Charm[,] recipeTable; // Table/adjacency matrix of recipes

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
        // TODO:Go through list of charms and build the adj matrix

        recipeTable = new Charm[CharmComponent.NUM_COMPONENT_TYPES, CharmComponent.NUM_COMPONENT_TYPES];

        // init to null
        for (int i = 0; i < CharmComponent.NUM_COMPONENT_TYPES; i++)
        {
            for (int j = 0; j < CharmComponent.NUM_COMPONENT_TYPES; j++)
            {
                recipeTable[i, j] = null;
            }
        }

        // fill the table
        foreach(Charm charm in charmsRecipeList)
        {
            int row = (int)charm.firstComponent.componentType;
            int col = (int)charm.secondComponent.componentType;
            recipeTable[row, col] = charm;
            recipeTable[col, row] = charm;
        }

       
    }

    /// <summary>
    /// Looko up the charm, passing in the first and second components
    /// </summary>
    /// <param name="comp1"></param>
    /// <param name="comp2"></param>
    /// <returns></returns>
    public Charm LookUpCharm(CharmComponent.ComponentType comp1, CharmComponent.ComponentType comp2)
    {

        Charm c = recipeTable[(int)comp1, (int)comp2];
        return c;
    }



    
}

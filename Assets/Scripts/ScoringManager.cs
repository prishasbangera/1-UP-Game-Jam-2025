using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoringManager : MonoBehaviour, ScoringManagerInterface
{
    public static ScoringManager Instance { get; private set; }   // allows read-only access to the RecipeBook instance

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

    public void InitializeProgressBar()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateProgressBar()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateScore(int score)
    {
        throw new System.NotImplementedException();
    }
}

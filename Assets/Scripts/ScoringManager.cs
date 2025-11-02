using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoringManager : MonoBehaviour, ScoringManagerInterface
{
    [HideInInspector] public int score;
    [SerializeField] public const int PENALTY = 5;

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

    void Start()
    {
        InitializeProgressBar();
    }

    public void InitializeProgressBar()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateProgressBarDisplay()
    {
        throw new System.NotImplementedException();
    }

    public void AddScore(int score)
    {
        this.score += score;
        Debug.Log("added " + score + ". new score: " + this.score);
        CheckWin();
    }

    public void GivePenalty()
    {
        if (score < 0)
        {
            score += PENALTY;
        }
        else if (score > 0)
        {
            score -= PENALTY;
        }
        CheckWin();
    }

    public void CheckWin()
    {
        if (score > 50)
        {
            Debug.Log("loaded game scene");
            SceneManager.LoadScene(2);
        }
        else if (score < -50)
        {
            Debug.Log("loaded game scene");
            SceneManager.LoadScene(3);
        }
    }
}

using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoringManager : MonoBehaviour, ScoringManagerInterface
{
    const int SCORE_BOUND = 50;
    [HideInInspector] public int score = 0;
    [SerializeField] public const int PENALTY = 5;
    [SerializeField] public int barHeight = 200;
    [SerializeField] public int barWidth = 50;

    [SerializeField] GameObject scoreIndicatorUI;

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
        //throw new System.NotImplementedException();
    }

    public void UpdateProgressBarDisplay()
    {
        //float h = Mathf.Abs(score) / SCORE_BOUND * maxBarHeight;
        //h = Mathf.Clamp(h, 0, maxBarHeight);

        //if (score < 0)
        //{
        //    goodBar.GetComponent<RectTransform>().sizeDelta = new Vector2(barWidth, 0);
        //    evilBar.GetComponent<RectTransform>().sizeDelta = new Vector2(barWidth, h);

        //}
        //else if (score > 0)
        //{
        //    goodBar.GetComponent<RectTransform>().sizeDelta = new Vector2(barWidth, h);
        //    evilBar.GetComponent<RectTransform>().sizeDelta = new Vector2(barWidth, 0);
        //}
        //else
        //{
        //    goodBar.GetComponent<RectTransform>().sizeDelta = new Vector2(barWidth, 0);
        //    evilBar.GetComponent<RectTransform>().sizeDelta = new Vector2(barWidth, 0);
        //}
        RectTransform rt = scoreIndicatorUI.GetComponent<RectTransform>();
        float normalizedScore = Mathf.Clamp((float)score / SCORE_BOUND, -1f, 1f);
        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, normalizedScore * barHeight);
        //float y = score + Score * barHeight;
        //scoreIndicatorUI.transform.position = new Vector2(scoreIndicatorUI.transform.position.x, y);
    }

    public void AddScore(int score)
    {
        this.score += score;
        Debug.Log("added " + score + ". new score: " + this.score);
        CheckWin();
        UpdateProgressBarDisplay();
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
        UpdateProgressBarDisplay() ;
    }

    public void CheckWin()
    {
        if (score > SCORE_BOUND)
        {
            Debug.Log("loaded game scene");
            SceneManager.LoadScene(2);
        }
        else if (score < -SCORE_BOUND)
        {
            Debug.Log("loaded game scene");
            SceneManager.LoadScene(3);
        }
    }
}

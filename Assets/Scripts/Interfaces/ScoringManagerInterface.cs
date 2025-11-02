using UnityEngine;

public interface ScoringManagerInterface
{
    /// <summary>
    /// Call when the game starts
    /// </summary>
    public void InitializeProgressBar();

    /// <summary>
    /// Visually update the progress bar to show the current score/progress
    /// </summary>
    public void UpdateProgressBar();

    /// <summary>
    /// Add or subtract score from progress.
    /// Call when bracelet is sold, customer leaves, or player refreshes inventory
    /// </summary>
    public void UpdateScore(int score);
}

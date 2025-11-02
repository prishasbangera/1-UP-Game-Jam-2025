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
    public void UpdateProgressBarDisplay();

    /// <summary>
    /// Add or subtract score from progress.
    /// Call when bracelet is sold
    /// </summary>
    public void AddScore(int score);

    /// <summary>
    /// Update score but specifically for penalty
    /// Call when customer leaves, or player refreshes inventory
    /// </summary>
    public void GivePenalty();

    /// <summary>
    /// Check to see if you win; load the corresponding win scene
    /// </summary>
    public void CheckWin();
}

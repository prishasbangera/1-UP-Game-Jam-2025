using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadWinSceneChanger : MonoBehaviour
{
    public void LoadBadScene()
    {
        Debug.Log("loaded game scene");
        SceneManager.LoadScene(3);
    }
}
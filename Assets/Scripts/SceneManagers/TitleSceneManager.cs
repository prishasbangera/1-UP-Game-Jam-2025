using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneChanger : MonoBehaviour
{
    public void LoadGameScene()
    {
        Debug.Log("loaded game scene");
        SceneManager.LoadScene(1);
    }
}
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Bracelet : MonoBehaviour
{
    [SerializeField]
    public static GameObject braceletPrefab;

    public List<Charm> charmList;
    public CharmUIBox[] charmUIBoxList;
    public GameObject completedBraceletImage;

    public int maxCharms;  // maxcharms lol
    public Sprite chainImg;

    public Bracelet(int maxCharms)
    {
        this.maxCharms = maxCharms;
        charmList = new List<Charm>();
        
        charmUIBoxList = new CharmUIBox[maxCharms];
    }

    public void AddCharm(Charm c)
    {
        if (isComplete())
        {
            Debug.Log("Error: we are trying to add charm to already full bracelet, but full bracelets should be on Bracelet Shelf!!");
        } else
        {
            charmList.Add(c);
        }
    }

    public int CalculateAlignment()
    {
        int sum = 0;

        for (int i = 0; i < charmList.Count; i++)
        {
            sum += charmList[i].alignment;
        }

        return sum;
    }


    public bool isComplete()
    {
        return charmList.Count == maxCharms;
    }

    public void CreateCompletedBraceletImage()
    {
        if (!isComplete()) return;
        Debug.Log("created new brancelet image");
        completedBraceletImage = GameObject.Instantiate(braceletPrefab);
        for (int i = 0; i < maxCharms; i++) {
            charmUIBoxList[i].SetCharm(charmList[i]);
        }
    }

}

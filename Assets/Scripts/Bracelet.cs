using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Bracelet
{

    public List<Charm> charmList;
    public GameObject completedBraceletImage;

    public int maxCharms;  // maxcharms lol
    //public Sprite chainImg;

    public Bracelet(int maxCharms)
    {
        this.maxCharms = maxCharms;
        charmList = new List<Charm>();
        
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
        //Debug.Log("creating new brancelet image");
        completedBraceletImage = GameObject.Instantiate(ShopManager.Instance.braceletPrefab);
        CharmUIBox[] charmUIBoxList = completedBraceletImage.GetComponentsInChildren<CharmUIBox>(true);

        for (int i = 0; i < maxCharms; i++) {
            charmUIBoxList[i].SetCharm(charmList[i]);
        }

        for (int i = maxCharms; i < ShopManager.Instance.MAX_BRACELET_LENGTH; i++) {
            charmUIBoxList[i].SetCharm(null);
        }
    }

}

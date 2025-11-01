using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Bracelet
{
    public List<Charm> charmList;
    public int maxCharms;

    public Bracelet(int maxCharms)
    {
        this.maxCharms = maxCharms;
    }

    public void AddCharm(Charm c)
    {
        if (charmList.Count >= maxCharms) // maxcharms lol
        {
            Debug.Log("Error: we are trying to add charm to already full bracelet, but full bracelets should be on Bracelet Shelf!!");
        } else
        {
            charmList.Add(c);
        }
    }

    public float CalculateAlignment()
    {
        throw new System.NotImplementedException();
    }

}

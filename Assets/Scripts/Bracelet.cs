using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bracelet", menuName = "Scriptable Objects/Bracelet")]
public class Bracelet : ScriptableObject
{
    public List<Charm> charmList;
}

using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharmComponent", menuName = "Scriptable Objects/CharmComponent")]
public class Bracelet : ScriptableObject
{
    public List<Charm> charmList;
}

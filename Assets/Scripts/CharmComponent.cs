using UnityEngine;

[CreateAssetMenu(fileName = "CharmComponent", menuName = "Scriptable Objects/CharmComponent")]
public class CharmComponent : ScriptableObject
{
    public enum ComponentType {
        EMPTY,
        WATER,
        FLOWER,
        EVIL_EYE,
        FIRE
    }

    

    public ComponentType componentType;
    public Sprite sprite;

    [HideInInspector]
    public bool isInStash = true; // if false, in crafting area
    

}

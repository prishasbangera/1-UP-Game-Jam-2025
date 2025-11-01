using UnityEngine;

[CreateAssetMenu(fileName = "CharmComponent", menuName = "Scriptable Objects/CharmComponent")]
public class CharmComponent : ScriptableObject
{
    public static int NUM_COMPONENT_TYPES = 5;

    public enum ComponentType {
        FLOWER,
        EYEBALL,
        FUR,
        MUSHROOM,
        PEARL,
        CLOVER,
        CRYSTAL
    }

    

    public ComponentType componentType;
    public Sprite sprite;

    [HideInInspector]
    public bool isInStash = true; // if false, in crafting area
    

}

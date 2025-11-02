using UnityEngine;
using static CharmComponent;

[CreateAssetMenu(fileName = "CharmComponent", menuName = "Scriptable Objects/CharmComponent")]
public class CharmComponent : ScriptableObject
{
    public enum ComponentType {
        FLOWER,
        EYEBALL,
        FUR,
        MUSHROOM,
        PEARL,
        CLOVER,
        CRYSTAL
    }

    public static int NUM_COMPONENT_TYPES = ComponentType.GetNames(typeof(ComponentType)).Length;


    public ComponentType componentType;
    public Sprite sprite;

    [HideInInspector]
    public int craftingAreaLocation = -1; // 0 in first spot, 1 in second spot, -1 in stash

}

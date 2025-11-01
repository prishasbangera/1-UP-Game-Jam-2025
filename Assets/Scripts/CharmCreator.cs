using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class CharmCreator : CharmCreatorInterface
{
    public void DisplayStash()
    {
        throw new System.NotImplementedException();
    }

    public void GenerateNewStash()
    {
        throw new System.NotImplementedException();
    }

    // Stash
    // Have a list here or something
    public List<CharmComponent> stash = new List<CharmComponent>();

    // Crafting area - can change this, wasn't sure how to implement
    public CharmComponent[] craftingArea = new CharmComponent[2];

    // Look in the charmscreatorinterface class
    void CharmCreatorInterface.CraftButtonOnClick()
    {
        throw new System.NotImplementedException();
    }

    void CharmCreatorInterface.IngredientOnClick()
    {
        // Don't know how to access the scriptable object that got clicked
        CharmComponent clickedObject = new CharmComponent();
        clickedObject.componentType = CharmComponent.ComponentType.EVIL_EYE;
        // Did this rather than check for null
        CharmComponent emptyComponent = new CharmComponent();
        clickedObject.componentType = CharmComponent.ComponentType.EMPTY;

        if (!clickedObject.isInStash)
        {
            craftingArea[System.Array.LastIndexOf(craftingArea,clickedObject)]=emptyComponent;
            Debug.Log("Removed " + clickedObject.componentType + " from crafting area");
            stash.Add(clickedObject);
            Debug.Log("Added " + clickedObject.componentType + " to stash");
            clickedObject.isInStash = false;
        }
        else
        {
            // Unsure how we're implementing the crafting area so I just made an array up by the stash
            if (craftingArea[0].componentType == CharmComponent.ComponentType.EMPTY)
            {
                craftingArea[0] = clickedObject;
                Debug.Log("Added " + clickedObject.componentType + " to first crafting slot");
            }
            else if (craftingArea[1].componentType == CharmComponent.ComponentType.EMPTY)
            {
                craftingArea[1] = clickedObject;
                Debug.Log("Added " + clickedObject.componentType + " to second crafting slot");
            }
            else
            {
                Debug.Log("an oopsy daisy happened :(");
            }
        }
    }

    void CharmCreatorInterface.OnCraftFail()
    {
        throw new System.NotImplementedException();
    }

    void CharmCreatorInterface.OnCraftSuccess()
    {
        throw new System.NotImplementedException();
    }
}

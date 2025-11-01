using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.Purchasing;

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
        // Use the actual method name once it's made
        Charm result = RecipeBook.Instance.LookUpCharm(craftingArea[0].componentType, craftingArea[1].componentType);
        if (result != null)
        {
            ((CharmCreatorInterface)this).OnCraftSuccess();
        }
        else
        {
            ((CharmCreatorInterface)this).OnCraftFail();
        }
    }

    void CharmCreatorInterface.IngredientOnClick()
    {
        // Don't know how to access the scriptable object that got clicked
        CharmComponent clickedObject = new CharmComponent();
        clickedObject.componentType = CharmComponent.ComponentType.EYEBALL;

        if (!clickedObject.isInStash)
        {
            craftingArea[System.Array.LastIndexOf(craftingArea,clickedObject)]=null;
            Debug.Log("Removed " + clickedObject.componentType + " from crafting area");
            stash.Add(clickedObject);
            Debug.Log("Added " + clickedObject.componentType + " to stash");
            clickedObject.isInStash = false;
        }
        else
        {
            // Unsure how we're implementing the crafting area so I just made an array up by the stash
            if (craftingArea[0] == null)
            {
                craftingArea[0] = clickedObject;
                Debug.Log("Added " + clickedObject.componentType + " to first crafting slot");
            }
            else if (craftingArea[1] == null)
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
        Bracelet bracelet = new Bracelet();

        // Maybe pass the result into this method instead of calling it again?
        Charm result = RecipeBook.Instance.LookUpCharm(craftingArea[0].componentType, craftingArea[1].componentType);

        Debug.Log("Used " + craftingArea[0] + " and " + craftingArea[1] + " to craft " + result);
        craftingArea[0] = null;
        craftingArea[1] = null;
        bracelet.charmList.Add(result);
        Debug.Log("added charm to bracelet");
    }
}

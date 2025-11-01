using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.Purchasing;

public class CharmCreator : MonoBehaviour, CharmCreatorInterface
{

    // Stash
    public List<CharmComponent> stash = new List<CharmComponent>();

    // Crafting area
    public CharmComponent[] craftingArea = new CharmComponent[2];

    public void DisplayCraftingArea()
    {
        throw new System.NotImplementedException();
    }

    public void DisplayStash()
    {
        throw new System.NotImplementedException();
    }

    public void GenerateNewStash()
    {
        throw new System.NotImplementedException();
    }

    // Look in the charmscreatorinterface class

    public void CraftButtonOnClick()
    {
        // Use the actual method name once it's made
        Charm result = RecipeBook.Instance.LookUpCharm(craftingArea[0].componentType, craftingArea[1].componentType);
        if (result != null)
        {
            OnCraftSuccess(result);
        }
        else
        {
            OnCraftFail();
        }
    }

    public void IngredientOnClick(ref CharmComponent clickedObject)
    {
        // Don't know how to access the scriptable object that got clicked
        clickedObject.componentType = CharmComponent.ComponentType.EYEBALL;

        if (clickedObject.craftingAreaLocation >= 0)
        {
            craftingArea[clickedObject.craftingAreaLocation] = null;
            Debug.Log("Removed " + clickedObject.componentType + " from crafting area");
            stash.Add(clickedObject);
            Debug.Log("Added " + clickedObject.componentType + " to stash");
            clickedObject.craftingAreaLocation = -1;
        }
        else
        {
            if (craftingArea[0] == null)
            {
                clickedObject.craftingAreaLocation = 0;
                craftingArea[0] = clickedObject;
                Debug.Log("Added " + clickedObject.componentType + " to first crafting slot");
            }
            else if (craftingArea[1] == null)
            {
                clickedObject.craftingAreaLocation = 1;
                craftingArea[1] = clickedObject;
                Debug.Log("Added " + clickedObject.componentType + " to second crafting slot");
            }
            else
            {
                Debug.Log("an oopsy daisy happened :( - crafting area full ");
            }
        }
    }

    public void OnCraftFail()
    {
        throw new System.NotImplementedException();
    }

    public void OnCraftSuccess(Charm charm)
    {
        Debug.Log("Used " + craftingArea[0].componentType + " and " + craftingArea[1].componentType + " to craft " + charm.charmType);
        craftingArea[0] = null;
        craftingArea[1] = null;
        ShopManager.Instance.currentBracelet.AddCharm(charm);
        Debug.Log("added charm to bracelet TODO add to shelf");
        
    }
}

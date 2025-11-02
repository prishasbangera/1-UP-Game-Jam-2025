using UnityEngine;

public interface CharmCreatorInterface
{

    /// <summary>
    /// // Function: called when user clicks an ingredient
    /// If the ingredient is on the crafting area, move it back to the stash
    /// If the ingredient is on the stash, ->
    /// If the  first ingredient is already there, put it in the second slot. Else, put it in the first slot.
    /// </summary>
    public void IngredientOnClick(CharmComponent clickedObject);

    // Function: Call when craft button is clicked
    public void CraftButtonOnClick();

    // Function: called when charm making fails

    public void OnCraftFail();

    // Function: called when charm making succeeds (add to charms made list)

    public void OnCraftSuccess(Charm charm);



}

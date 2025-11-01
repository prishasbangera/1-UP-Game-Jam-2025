using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

/// <summary>
/// This just sets the slot images
/// </summary>
public class ComponentUIBox : MonoBehaviour
{
    [SerializeField]
    GameObject img;

    private CharmComponent charmComponent = null;
    public void SetComponent(CharmComponent comp)
    {
        charmComponent = comp;
        if (img != null)
        {
            img.GetComponent<Image>().sprite = comp.sprite;

        }
        else
        {
            img.GetComponent<Image>().sprite = null;
        }
    }

    public void OnClick()
    {
        ShopManager.Instance.CharmComponentOnClick(charmComponent);
    }
}

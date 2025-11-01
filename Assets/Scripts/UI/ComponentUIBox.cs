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
    GameObject imgPanel = null;
    Image img;

    private void Awake()
    {
        img = imgPanel.GetComponent<Image>();
    }

    private CharmComponent assignedComponent = null;
    public void SetComponent(CharmComponent comp)
    {
        assignedComponent = comp;
        if (comp != null)
        {
            img.sprite = comp.sprite;
            img.color = Color.white; // fully visible

        }
        else
        {
            img.sprite = null;

            img.color = new Color(1, 1, 1, 0); // not visible
        }
    }

    public void OnClick()
    {
        if (assignedComponent != null)
        {
            ShopManager.Instance.CharmComponentOnClick(assignedComponent);
        }
    }
}

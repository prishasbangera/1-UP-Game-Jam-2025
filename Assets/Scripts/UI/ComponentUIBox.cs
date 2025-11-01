using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ComponentUIBox : MonoBehaviour
{
    [SerializeField]
    GameObject img;

    private CharmComponent charmComponent = null;
    public void SetImage(CharmComponent comp)
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
        Debug.Log("compoennt ui box clicked.");
        ShopManager.Instance.CharmComponentOnClick(this);
    }
}

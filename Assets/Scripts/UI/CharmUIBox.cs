using UnityEngine;
using UnityEngine.UI;

public class CharmUIBox : MonoBehaviour
{
    Image img;

    private void Awake()
    {
        img = this.gameObject.GetComponent<Image>();
    }

    public Charm assignedCharm = null;
    public void SetCharm(Charm charm)
    {
        assignedCharm = charm;
        if (charm != null)
        {
            img.sprite = charm.sprite;
            img.color = Color.white; // fully visible

        }
        else
        {
            img.sprite = null;
            img.color = new Color(1, 1, 1, 0); // not visible
        }
    }

}

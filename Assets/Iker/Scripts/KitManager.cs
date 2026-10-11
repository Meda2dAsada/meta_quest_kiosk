using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems; 

public class KitManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public KitState InitialState = KitState.NONE;
    public TextMeshProUGUI KitText;
    public GameObject KitHover;
    public GameObject StatusColor;
    public TextMeshProUGUI StatusText;
    
    private Dictionary<KitState, Color> KitStateColorNormal = new Dictionary<KitState, Color>()
    {
        { KitState.AVAILABLE, new Color(0.368f, 0.843f, 0.325f) },
        { KitState.UNAVAILABLE, new Color(0.996f, 0.203f, 0.203f) },
        { KitState.CHARGING, new Color(0.203f, 0.839f, 0.847f) },
    };

    private Dictionary<KitState, Color> KitStateColorHover = new Dictionary<KitState, Color>()
    {
        { KitState.AVAILABLE, new Color(0.458f, 1f, 0.411f) },
        { KitState.UNAVAILABLE, new Color(1f, 0.443f, 0.443f) },
        { KitState.CHARGING, new Color(0.549f, 0.992f, 1f) },
    };
    
    private Dictionary<KitState, string> KitStateSymbol = new Dictionary<KitState, string>()
    {
        { KitState.AVAILABLE, "/" },
        { KitState.UNAVAILABLE, "x" },
        { KitState.CHARGING, "-" },
    };
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (InitialState == KitState.UNAVAILABLE || InitialState == KitState.CHARGING)
        {
            KitHover.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        KitHover.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked");
    }
}

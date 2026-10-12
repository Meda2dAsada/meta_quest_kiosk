using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Unity.VisualScripting;

public class KitManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public uint KitNumber = 0;
    public KitState InitialState = KitState.EMPTY;
    public TextMeshProUGUI KitText;
    public GameObject KitHover;
    public GameObject StatusColorObject;
    public TextMeshProUGUI StatusText;
    
    public static Dictionary<KitState, Color> KitStateColorNormal = new Dictionary<KitState, Color>()
    {
        { KitState.AVAILABLE, new Color(0.368f, 0.843f, 0.325f) },
        { KitState.UNAVAILABLE, new Color(0.996f, 0.203f, 0.203f) },
        { KitState.CHARGING, new Color(0.203f, 0.839f, 0.847f) },
        { KitState.EMPTY, Color.white },
    };

    public static Dictionary<KitState, Color> KitStateColorHover = new Dictionary<KitState, Color>()
    {
        { KitState.AVAILABLE, new Color(0.458f, 1f, 0.411f) },
        { KitState.UNAVAILABLE, new Color(1f, 0.443f, 0.443f) },
        { KitState.CHARGING, new Color(0.549f, 0.992f, 1f) },
        { KitState.EMPTY, Color.white },
        
    };
    public static Dictionary<KitState, string> KitStateSymbol = new Dictionary<KitState, string>()
    {
        { KitState.AVAILABLE, "OK" },
        { KitState.UNAVAILABLE, "x" },
        { KitState.CHARGING, "-" },
        { KitState.EMPTY, "" },
        
    };

    
    public void SetKitInfo()
    {
        StatusColorObject.SetActive(!IsEmpty());
        KitText.text = $"KIT #0{KitNumber}";
        StatusColorObject.GetComponent<Image>().color = KitStateColorNormal[InitialState];
        StatusText.text = KitStateSymbol[InitialState];
    }

    void Start()
    {
        SetKitInfo();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UserData.KitManager = this;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (IsEmpty()) return;
        
        KitHover.SetActive(IsUnavailable() || IsCharging());
        GetComponent<Image>().color = new Color(0.51f, 0.53f, 0.54f, 1);
        StatusColorObject.GetComponent<Image>().color = KitStateColorHover[InitialState];

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (IsEmpty()) return;
        
        KitHover.SetActive(false);
        GetComponent<Image>().color = new Color(0.51f,0.57f,0.60f,1f);
        StatusColorObject.GetComponent<Image>().color = KitStateColorNormal[InitialState];
    }

    public bool IsAvailable()
    {
        return InitialState == KitState.AVAILABLE;
    }
    
    public bool IsUnavailable()
    {
        return InitialState == KitState.UNAVAILABLE;
    }
    
    public bool IsCharging()
    {
        return InitialState == KitState.CHARGING;
    }
    
    public bool IsEmpty()
    {
        return InitialState == KitState.EMPTY;
    }
}

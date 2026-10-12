using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class KitManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public uint KitNumber;
    public KitState InitialState = KitState.EMPTY;
    public TextMeshProUGUI KitText, StatusText;
    public GameObject KitHover, StatusColorObject;
    public bool ShowSelectedKit;
    public static Dictionary<KitState, Color> KitStateColorNormal = new Dictionary<KitState, Color>() {
        { KitState.AVAILABLE, new Color(0.368f, 0.843f, 0.325f) },
        { KitState.UNAVAILABLE, new Color(0.996f, 0.203f, 0.203f) },
        { KitState.CHARGING, new Color(0.203f, 0.839f, 0.847f) },
        { KitState.EMPTY, Color.white }
    };
    public static Dictionary<KitState, Color> KitStateColorHover = new Dictionary<KitState, Color>() {
        { KitState.AVAILABLE, new Color(0.458f, 1f, 0.411f) },
        { KitState.UNAVAILABLE, new Color(1f, 0.443f, 0.443f) },
        { KitState.CHARGING, new Color(0.549f, 0.992f, 1f) },
        { KitState.EMPTY, Color.white }
    };
    private string[] symbols = { "-", "OK", "x", "" }; // Orden del enum KitState.
    void Start() { SetKitInfo(); }

    public void SetKitInfo() {
        if (StatusColorObject != null) StatusColorObject.SetActive(!ShowSelectedKit && !IsEmpty());
        KitText.text = $"KIT #{KitNumber:00}";
        if (ShowSelectedKit) {
            KitText.text = UserData.HasKit ? UserData.KitText : "SELECT A KIT";
            if (UserData.HasKit) KitText.color = UserData.KitStateColorNormal;
        } else {
            StatusColorObject.GetComponent<Image>().color = KitStateColorNormal[InitialState];
            StatusText.text = symbols[(int)InitialState];
        }
    }
    public void OnPointerEnter(PointerEventData eventData) {
        if (IsEmpty() || ShowSelectedKit) return;
        KitHover.SetActive(IsUnavailable() || IsCharging());
        GetComponent<Image>().color = new Color(0.51f, 0.53f, 0.54f, 1);
        StatusColorObject.GetComponent<Image>().color = KitStateColorHover[InitialState];
        SaveSelection();
    }
    public void OnPointerExit(PointerEventData eventData) {
        if (IsEmpty() || ShowSelectedKit) return;
        KitHover.SetActive(false);
        GetComponent<Image>().color = new Color(0.51f, 0.57f, 0.60f, 1);
        StatusColorObject.GetComponent<Image>().color = KitStateColorNormal[InitialState];
    }
    public void SaveSelection() {
        if (!IsSelectionScreen() || !CanSelect()) return;
        bool scenarioB = gameObject.scene.name == "SceneBStart";
        if (UserData.ScenarioB != scenarioB) UserData.ResetSelection();
        UserData.State = InitialState;
        UserData.KitText = KitText.text;
        UserData.KitStateColorNormal = KitStateColorNormal[InitialState];
        UserData.KitNumber = KitNumber;
        UserData.ScenarioB = scenarioB;
    }
    public bool IsSelectionScreen() {
        return gameObject.scene.name == "SceneAStart" || gameObject.scene.name == "SceneBStart";
    }
    public bool CanSelect() { return !IsEmpty() && (gameObject.scene.name == "SceneBStart" || IsAvailable()); }
    public bool IsAvailable() { return InitialState == KitState.AVAILABLE; }
    public bool IsUnavailable() { return InitialState == KitState.UNAVAILABLE; }
    public bool IsCharging() { return InitialState == KitState.CHARGING; }
    public bool IsEmpty() { return InitialState == KitState.EMPTY; }
}

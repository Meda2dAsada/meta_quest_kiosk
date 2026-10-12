using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour, IPointerClickHandler
{
    public string NextSceneName;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;
        if (string.IsNullOrEmpty(NextSceneName)) return;

        KitManager kit = GetComponent<KitManager>();
        if (kit != null && kit.IsSelectionScreen())
        {
            if (!kit.CanSelect()) return;
            kit.SaveSelection();
        }

        bool needsSelection = NextSceneName == "Screen1A" || NextSceneName == "Screen1B" ||
                              NextSceneName == "Screen2A" || NextSceneName == "Screen2B";
        if (needsSelection && !UserData.HasReservation) return;

        string destination = NextSceneName;
        // Al volver desde Home B, recupera el calendario del dia que ya eligio el usuario.
        if (destination == "CalendarioScenarioB1" && UserData.ScenarioB &&
            (UserData.SelectedDay == 28 || UserData.SelectedDay == 30))
        {
            destination = "CalendarioScenarioB2";
        }

        SceneManager.LoadScene(destination);
    }
}

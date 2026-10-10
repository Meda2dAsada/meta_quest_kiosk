using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CalendarController : MonoBehaviour
{
    
    //Atributos
    public bool B1;
    public int SelectedDay = 22;

    public Button horario1000;
    public Button horario1130;
    public Button confirmButton;
    public CanvasGroup confirmGroup;

    private bool horarioSeleccionado;
    
    //Metodos
    void Start() {
        horarioSeleccionado = false;
        horario1000.transition = Selectable.Transition.None;
        horario1130.transition = Selectable.Transition.None;
        confirmButton.transition = Selectable.Transition.None;
        
        horario1000.interactable = false;
        horario1130.interactable = !B1;
        confirmButton.interactable = false;
        confirmGroup.alpha = 0.45f;
    }

    public void SeleccionarHorario() {
        if (B1)
        {
            return;
        }
        horarioSeleccionado = true;
        confirmButton.interactable = true;
        confirmGroup.alpha = 1f;
    }

    public void Day28() {
        if (B1) {
            SceneManager.LoadScene("CalendarioScenarioB2");
        }
    }

    public void Confirm() {
        if (B1 || !horarioSeleccionado)
        {
            return;
        }
        Debug.Log("Time selected: " + SelectedDay + "of September 2026, from 11:30 AM to 1:00 PM (90 Minutes)");
    }

}

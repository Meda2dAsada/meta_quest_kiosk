using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CalendarController : MonoBehaviour {
    public bool B1;
    public int SelectedDay = 22;
    public Button horario1000, horario1130, confirmButton;
    public CanvasGroup confirmGroup;
    public Transform daysGrid;
    public TMP_Text monthLabel, currentTimeLabel, availableTimesLabel;
    private Button[] dayButtons = new Button[30];
    private CultureInfo language = new CultureInfo("en-US");
    void Start() {
        horario1000.transition = horario1130.transition = confirmButton.transition = Selectable.Transition.None;
        for (int i = 0; i < dayButtons.Length; i++) {
            int day = i + 1;
            dayButtons[i] = daysGrid.Find("Day" + day.ToString("00")).GetComponent<Button>();
            // Tambien el dia original debe recibir clics al volver a elegirlo.
            dayButtons[i].targetGraphic.raycastTarget = true;
            if (dayButtons[i].onClick.GetPersistentEventCount() == 0)
                dayButtons[i].onClick.AddListener(() => SelectDay(day));
        }
        RefreshCalendar();
    }
    public void RefreshCalendar() {
        SelectedDay = UserData.SelectedDay;
        monthLabel.text = UserData.DemoTime.ToString("MMMM yyyy", language);
        currentTimeLabel.text = "Current time: " + UserData.DemoTime.ToString("MMM d\nyyyy 'at' h:mm tt", language);
        availableTimesLabel.text = UserData.HasKit ? "AVAILABLE TIMES - " + SelectedDay + " SEP" : "SELECT A KIT FIRST - USE BACK";
        for (int i = 0; i < dayButtons.Length; i++) {
            Button button = dayButtons[i];
            bool canSelect = UserData.IsDayAvailable(i + 1);
            bool isSelected = canSelect && i + 1 == SelectedDay;
            button.interactable = canSelect;
            button.targetGraphic.color = Color.white;
            button.transition = Selectable.Transition.ColorTint;
            ColorBlock colors = button.colors;
            colors.normalColor = colors.selectedColor = colors.disabledColor = UserData.GetDayColor(i + 1);
            colors.highlightedColor = colors.pressedColor = UserData.DaySelectedColor;
            button.colors = colors;
            button.GetComponentInChildren<TMP_Text>(true).color = canSelect && !isSelected ? UserData.DayTextColor : Color.white;
            button.transform.Find("SelectedBorder").gameObject.SetActive(isSelected);
        }
        horario1000.interactable = false;
        horario1130.interactable = UserData.IsDayAvailable(SelectedDay);
        confirmButton.interactable = horario1130.interactable && UserData.HasReservation;
        confirmGroup.alpha = confirmButton.interactable ? 1f : 0.45f;
        horario1130.targetGraphic.color = confirmButton.interactable ? new Color32(65, 115, 66, 255) : UserData.DayAvailableColor;
    }
    public void SelectDay(int day) {
        if (!UserData.IsDayAvailable(day)) return;
        UserData.SelectedDay = SelectedDay = day;
        if (B1) SceneManager.LoadScene("CalendarioScenarioB2");
        else RefreshCalendar();
    }
    public void SeleccionarHorario() {
        if (UserData.SelectTime(11, 30)) RefreshCalendar();
    }
    public void Back() {
        SceneManager.LoadScene(gameObject.scene.name == "CalendarioScenarioA" ? "SceneAStart" : "SceneBStart");
    }
    public void Day28() { SelectDay(28); }
    public void Confirm() {
        if (UserData.IsDayAvailable(SelectedDay) && UserData.HasReservation)
            SceneManager.LoadScene(UserData.ScenarioB ? "KitShowCaseB" : "KitShowCaseA");
    }
}

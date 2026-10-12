using System;
using UnityEngine;

// Datos compartidos mientras la aplicacion esta abierta.
public static class UserData {
    public static KitState State = KitState.EMPTY;
    public static string KitText = "";
    public static Color KitStateColorNormal = Color.white;
    public static uint KitNumber;
    public static bool ScenarioB, HasSelectedTime;
    public static int SelectedDay = 22, SelectedHour = 11, SelectedMinute = 30;
    public const int DurationMinutes = 90;
    public const int HeadsetCount = 1, ControllerCount = 2, ChargerCount = 1;
    public const string PickupLocation = "TI LAB#2";
    public static readonly DateTime DemoTime = new DateTime(2026, 9, 22, 8, 15, 0);
    public static readonly Color DayAvailableColor = new Color32(72, 81, 86, 255);
    public static readonly Color DayUnavailableColor = new Color32(195, 0, 57, 255);
    public static readonly Color DaySelectedColor = new Color32(62, 198, 85, 255);
    public static readonly Color DayTextColor = new Color32(232, 196, 0, 255);

    public static bool HasKit {
        get { return KitNumber >= 1 && KitNumber <= 6 && State != KitState.EMPTY; }
    }
    // Tener una seleccion todavia no significa haber registrado un prestamo.
    public static bool HasReservation {
        get { return HasKit && HasSelectedTime; }
    }
    public static DateTime PickupTime {
        get { return new DateTime(2026, 9, SelectedDay, SelectedHour, SelectedMinute, 0); }
    }
    public static DateTime ReturnTime {
        get { return PickupTime.AddMinutes(DurationMinutes); }
    }
    // Disponibilidad de ejemplo del prototipo, sin inventario de prestamos.
    public static bool IsDayAvailable(int day) {
        if (!HasKit || day < DemoTime.Day || day > 30) return false;
        if (ScenarioB) return day == 28 || day == 30;
        return State == KitState.AVAILABLE;
    }
    public static Color GetDayColor(int day) {
        if (!IsDayAvailable(day)) return DayUnavailableColor;
        return day == SelectedDay ? DaySelectedColor : DayAvailableColor;
    }
    public static bool SelectTime(int hour, int minute) {
        if (!IsDayAvailable(SelectedDay)) return false;
        SelectedHour = hour;
        SelectedMinute = minute;
        HasSelectedTime = true;
        return true;
    }

    // Unity limpia los datos al empezar otra sesion de Play.
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    public static void ResetSelection() {
        State = KitState.EMPTY;
        KitText = "";
        KitStateColorNormal = Color.white;
        KitNumber = 0;
        ScenarioB = false;
        SelectedDay = DemoTime.Day;
        SelectedHour = 11;
        SelectedMinute = 30;
        HasSelectedTime = false;
    }
}

using System.Globalization;
using TMPro;
using UnityEngine;

public class ReservationScreen : MonoBehaviour {
    public TMP_Text pickupText, subtitleText, returnText, locationText;
    public TMP_Text headsetText, controllerText, chargerText;
    private CultureInfo language = new CultureInfo("en-US");

    void Start() {
        RefreshScreen();
    }
    public void RefreshScreen() {
        string pickup = "SELECT A KIT AND TIME\nFROM THE HOME SCREEN";
        string returnMessage = "Select a kit\nand time\nfirst.";
        if (UserData.HasReservation) {
            string time = UserData.PickupTime.ToString("h:mmtt", language).ToLower();
            string date = UserData.PickupTime.ToString("dd/MMMM/yyyy", language);
            pickup = "PICK UP AT " + time + "\n" + date;
            returnMessage = "Your return\ntime will be\nat " +
                UserData.ReturnTime.ToString("h:mm tt", language) + ".";
        }
        SetText(pickupText, pickup);
        SetText(returnText, returnMessage);
        SetText(subtitleText, "Loan duration: " + UserData.DurationMinutes +
            " minutes.\nPlease arrive 5 minutes early.");
        SetText(locationText, UserData.PickupLocation);
        SetText(headsetText, UserData.HeadsetCount + " Headset");
        SetText(controllerText, UserData.ControllerCount + " Controllers");
        SetText(chargerText, UserData.ChargerCount + " Charger");
    }
    // Cada escena solo tiene asignados los textos que utiliza.
    private void SetText(TMP_Text label, string text) {
        if (label != null) label.text = text;
    }
}

using TMPro;
using UnityEngine;

public class UpdateLabel : MonoBehaviour
{
    public TextMeshProUGUI label;
    
    void Start()
    {
        label.text = UserData.KitManager.KitText.text;
        label.color = UserData.KitManager.KitText.color;
    }
}

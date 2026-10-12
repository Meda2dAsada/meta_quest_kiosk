using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour, IPointerClickHandler
{
    public string NextSceneName;
    public void OnPointerClick(PointerEventData eventData)
    {
        
        Debug.Log("OnPointerClick");
        if (!string.IsNullOrEmpty(NextSceneName))
        { 
            SceneManager.LoadScene(NextSceneName);
        }
    }

}

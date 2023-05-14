using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MyButton : MonoBehaviour, IPointerClickHandler
{
    new string name;
    public void OnPointerClick(PointerEventData eventData)
    {
        // Code à exécuter lors du clic sur le bouton
        
        name = eventData.pointerPress.name;
        

    }

    public string getButtonName()
    {
        return name;
    }
}
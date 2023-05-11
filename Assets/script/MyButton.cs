using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MyButton : MonoBehaviour, IPointerClickHandler
{
    string name;
    public void OnPointerClick(PointerEventData eventData)
    {
        // Code à exécuter lors du clic sur le bouton
        Debug.Log("Bouton cliqué !");
        name = eventData.pointerPress.name;
        

    }

    public string getButtonName()
    {
        return name;
    }
}
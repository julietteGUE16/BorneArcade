using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*
Ce script permet de récupérer le nom du bouton cliqué
*/


public class MyButton : MonoBehaviour, IPointerClickHandler
{
    new string name;
    public void OnPointerClick(PointerEventData eventData)
    {
        name = eventData.pointerPress.name;
        

    }

    public string getButtonName()
    {
        return name;
    }
}
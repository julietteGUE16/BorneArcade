using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverDetector : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    
    /*private GameObject lastHighlightedButton = null;
   

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerEnter != null)
        {
            lastHighlightedButton = eventData.pointerEnter;
            Debug.Log("Bouton en surbrillance : " + lastHighlightedButton.name);
            // Faites quelque chose en réponse au bouton en surbrillance
        }else {
            Debug.Log("is null");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerEnter == lastHighlightedButton)
        {
            lastHighlightedButton = null;
            // Réinitialisez le dernier bouton en surbrillance
        }
    }

    public void OnPointerHover(PointerEventData eventData)
    {
        if (eventData.pointerEnter != null)
        {
            lastHighlightedButton = eventData.pointerEnter;
        }
    }

     public void OnPointerMove(PointerEventData eventData)
    {
        if (eventData.pointerEnter != null)
        {
            lastHighlightedButton = eventData.pointerEnter;
        }
    }

    


    public string getButtonName()
    {
        //Debug.Log("getButtonName : " + nameButton);
        if(lastHighlightedButton == null){
            return "null";
        }else {
            return lastHighlightedButton.name;
        }
    }*/
}
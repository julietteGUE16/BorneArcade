using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
Ce script permet de changer la couleur du texte dans les menu et de le faire clignoter
*/
public class TextMenuColor : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Color colorSelected;
    public Color colorUnselected;
    public float blinkInterval = 2f;

    private void Start()
    {
        StartCoroutine(BlinkText());
    }

    private IEnumerator BlinkText()
    {
        while (true)
        {
            // Activer le texte
            text.color = colorSelected;

            yield return new WaitForSeconds(blinkInterval / 2f);

            // Désactiver le texte
            text.color = colorUnselected;

           
            yield return new WaitForSeconds(blinkInterval / 2f);
        }
    }
}

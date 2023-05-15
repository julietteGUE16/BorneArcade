using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/*
Ce script permet de changer la couleur des images dans les menu et de le faire clignoter
*/
public class FontMenuColor : MonoBehaviour
{
    public Image image;
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
            image.color = colorSelected;

            
            yield return new WaitForSeconds(blinkInterval / 2f);

            // Désactiver le texte
            image.color = colorUnselected;

           
            yield return new WaitForSeconds(blinkInterval / 2f);
        }
    }
}

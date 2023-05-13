using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


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

            // Attendre pendant la moitié de l'intervalle
            yield return new WaitForSeconds(blinkInterval / 2f);

            // Désactiver le texte
            text.color = colorUnselected;

            // Attendre pendant la moitié de l'intervalle
            yield return new WaitForSeconds(blinkInterval / 2f);
        }
    }
}

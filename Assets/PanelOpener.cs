using UnityEngine;
using UnityEngine.UI;


public class PanelOpener : MonoBehaviour
{
    public GameObject panel;
 

   

    private void Start()
    {
      
       
   
    }

    public void OpenPanel()
    {
       
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
       
        panel.SetActive(false);
    }

   
}
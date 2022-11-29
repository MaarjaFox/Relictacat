using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonOpener : MonoBehaviour
{
    
    public GameObject QPanel;
   



    public void OpenPanel()
    {
        if(QPanel != null)
        {   
            bool isActive = QPanel.activeSelf;

            QPanel.SetActive(!isActive); 
        }
       
    }

   

   
    
    
}

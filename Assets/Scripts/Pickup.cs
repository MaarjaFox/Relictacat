using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject whatCanIPickup;
    public GameObject playerMouth;
    public GameObject dropOffPoint;

   
   
    
    public bool iHaveSomething = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUpObject()
    {
        if (iHaveSomething)
        {
            whatCanIPickup.transform.parent = null;
            whatCanIPickup.transform.localPosition = dropOffPoint.transform.position;
            iHaveSomething = false;
        }
        else
        {
             if(whatCanIPickup != null)
                {
                 whatCanIPickup.transform.SetParent(playerMouth.transform);
                 whatCanIPickup.transform.localPosition = new Vector3(0f, 0f, 0f);
                 //whatCanIPickup.transform.localScale = new Vector3(1f, 1f, 1f);
                 iHaveSomething = true;
                 //!theQM.questCompleted[questNumber] && theQM.quests[questNumber].gameObject.activeSelf;
                 
                 }
            else 
                {

                }
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Pickable"))
        {
            whatCanIPickup = other.gameObject;
        }
    }
    
          //  if(!theQM.questCompleted[questNumber] && theQM.quests[questNumber].gameObject.activeSelf)
         //   {
         //       theQM.itemCollected = itemName;
                //gameObject.SetActive(false);
          //  }
      //  }
   // }
}

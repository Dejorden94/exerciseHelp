using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class new_trigger_punt : MonoBehaviour
{
    public GameObject uiObject;
    void Start()
    {
        uiObject.SetActive(false);
    }
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            uiObject.SetActive(true);
            print("Hij doet het");
        }
        void OnTriggerExit(Collider eindPunt)
        { 
                uiObject.SetActive(false);
                print("Hij doet het");
            }
        }
}

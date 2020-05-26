using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Bron: https://learn.unity.com/tutorial/getcomponent#5c8a65d5edbc2a001f47d6e6

public class warningMessage : MonoBehaviour
{

    //haalt het joycon script op
    private List<Joycon> joycons;
    //Uit dit gameobject moeten de components gehaald worden.
    public GameObject otherGameObject;
    //public GameObject gameObjectRumble;

    //private JoyConRumble rumble;
    private CurrentForce currentForce;

    [SerializeField] Text warning;

    //Herkent joy con en of het links of rechts is.
    public int jc_ind = 0;

    //Bron: https://www.youtube.com/watch?v=oRogSqp2rPg
    public AudioClip feedbackSound;
    AudioSource audioSource;

    public bool alreadyPlayed = false;
    
    void Start()
    { 
        joycons = JoyconManager.Instance.j;
        audioSource = GetComponent<AudioSource>();
    }

    void Awake() 
    {
        //rumble = gameObjectRumble.GetComponent<JoyConRumble>();
        currentForce = otherGameObject.GetComponent<CurrentForce>();
    }

    // Update is called once per frame
    void Update()
    {
        Joycon j = joycons[jc_ind];
        //Tekst wordt omgezet naar Goed bezig!
        warning.text = "Goed bezig!";
        if (currentForce.joint.currentForce[1] > -600)
        {
            alreadyPlayed = false;
        }
            //Als de force op as Y lager is dan -700 dan moet de tekst "Je knie mag niet voorbij je tenen!" zijn.
            if (currentForce.joint.currentForce[1] < -600)
        {

            Debug.Log("Rumble");
            //Verstuurt rumble naar joy-con wanneer knie te ver naar voren staat.
            j.SetRumble(160, 160, 0.6f, 1000);

            warning.text = "Je knie mag niet voorbij je tenen!";
            if (!alreadyPlayed) { 
                if (feedbackSound != null)
                {
                    audioSource.PlayOneShot(feedbackSound, 0.7f);
                    alreadyPlayed = true;
                }
            }

        }
    }
}

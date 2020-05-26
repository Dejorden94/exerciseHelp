using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


//Bron: https://github.com/PasternakMichal/SimGen/blob/ebd9882744858c490144d9b9179ca168ff40dcf8/SimGen%20Unity%20Framework/Assets/Resources/RocketUtilities/EngineControl.cs
public class CurrentForce : MonoBehaviour
{
    public Rigidbody rb;
    public SpringJoint joint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        joint = GetComponent<SpringJoint>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Joint force X: " + joint.currentForce[0]);
        Debug.Log("Joint force Y: " + joint.currentForce[1]);
        Debug.Log("Joint force Z: " + joint.currentForce[2]);
        
    }
}

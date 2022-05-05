using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;

public class InitFirebase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            UnityEngine.Debug.Log("firebase initialized.");
            // Do things once initialized to set up firestore
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

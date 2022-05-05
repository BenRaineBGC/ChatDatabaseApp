using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;


[FirestoreData]
public struct ChatData
{
    [FirestoreProperty]
    public string Name { get; set; }

    [FirestoreProperty]
    public string MessageBody { get; set; }
}

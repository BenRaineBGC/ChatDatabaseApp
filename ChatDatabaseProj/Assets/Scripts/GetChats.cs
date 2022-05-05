using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Firebase;
using Firebase.Firestore;
using Firebase.Extensions;

public class GetChats : MonoBehaviour
{
    FirebaseFirestore db;
    CollectionReference chats;

    [SerializeField]
    private TMP_Text _mainText;
    public void Start()
    {
        db = FirebaseFirestore.DefaultInstance;
        chats = db.Collection("Chats");

        chats.Listen(snapshot => {
                _mainText.text = "";
                foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
                {
                    Dictionary<string, object> chat = documentSnapshot.ToDictionary();

                    _mainText.text += chat["Name"] + ":" + chat["MessageBody"] + "\n";
                }
            });
        //this.GetData();
    }

    /*public void GetData()
    {
        Query allChatsQ = db.Collection("Chats");
        allChatsQ.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            QuerySnapshot allCitiesQuerySnapshot = task.Result;
            _mainText.text = "";
            foreach (DocumentSnapshot documentSnapshot in allCitiesQuerySnapshot.Documents)
            {
                Dictionary<string, object> chat = documentSnapshot.ToDictionary();

                _mainText.text += chat["Name"] + ":" + chat["MessageBody"] + "\n";
            }
        });
    }*/
}

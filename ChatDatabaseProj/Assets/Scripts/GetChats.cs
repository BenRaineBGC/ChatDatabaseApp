using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Firebase;
using Firebase.Firestore;
using Firebase.Extensions;
using System.Linq;

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

            var allDocumentsAsAList = snapshot.Documents.Select(x => x.ConvertTo<ChatData>());

            var allDocsSorted = allDocumentsAsAList.OrderBy(x => x.TimeSent).ToList();

            
            foreach (ChatData chat in allDocsSorted)
            {
                _mainText.text += chat.Name + ":" + chat.MessageBody + "\n";
            }
        });


    }
}

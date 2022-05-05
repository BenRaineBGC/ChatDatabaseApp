using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Firebase;
using Firebase.Firestore;
using Firebase.Extensions;


public class AddChatData : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _profileNameBox;

    [SerializeField]
    private TMP_InputField _textBox;

    [SerializeField]
    private Button _sendButton;


    void Start()
    {
        _sendButton.onClick.AddListener(() =>
        {
            var chatData = new ChatData
            {
                Name = _profileNameBox.text,
                MessageBody = _textBox.text,
                TimeSent = Timestamp.GetCurrentTimestamp()
            };

            var db = FirebaseFirestore.DefaultInstance;
            db.Collection("Chats").AddAsync(chatData);
        });
    }
}

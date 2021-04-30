using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    public Action IWin = delegate { };

    [SerializeField] TextMeshProUGUI textLimitTime;
    [SerializeField] TextMeshProUGUI textChat;
    [SerializeField] DataChats dataChat;

    int indexLastChat = 0;
    // Start is called before the first frame update
    void Start()
    {
        textLimitTime.text = ControlTime.Instance.GetLimitTime().ToString();
    }

    public void NewConversation() {
        if (indexLastChat >= dataChat.LargeOfTheTextChat())
        {
            IWin.Invoke();
            NewConversationWin();
            return;
        }
        textLimitTime.gameObject.SetActive(false);
        textChat.text = dataChat.GetTextChat(indexLastChat);
        indexLastChat++;
    }

    public void NewConversationLost() {
        textLimitTime.gameObject.SetActive(false);
        textChat.text = dataChat.GetTextLost();
    }

    public void NewConversationWin()
    {
        textLimitTime.gameObject.SetActive(false);
        textChat.text = dataChat.GetTextWin();
    }
}

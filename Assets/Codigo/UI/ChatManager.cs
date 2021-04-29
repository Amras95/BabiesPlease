using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textLimitTime;

    // Start is called before the first frame update
    void Start()
    {
        textLimitTime.text = ControlTime.Instance.GetLimitTime().ToString();
    }
}

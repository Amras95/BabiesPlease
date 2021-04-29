using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlBaby : MonoBehaviour
{
    [SerializeField] DataBaby dataBaby;
    [SerializeField] Image imageBaby;
    [SerializeField] TextMeshProUGUI textNameBaby;
    [SerializeField] TextMeshProUGUI textPriceBaby;


    void Start()
    {
        imageBaby.sprite = dataBaby.GetSpriteBaby();
        textNameBaby.text = dataBaby.GetNameBaby();
        textPriceBaby.text = dataBaby.GetPriceBaby().ToString();
    }

    public DataBaby GetDataBaby() => dataBaby;
}

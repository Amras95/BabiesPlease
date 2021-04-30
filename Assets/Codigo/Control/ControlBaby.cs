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
    [SerializeField] TextMeshProUGUI textGenerationBySecondBaby;

    void Start()
    {
        UpdateUIWithInfoBaby();
    }

    public DataBaby GetDataBaby() => dataBaby;

    public void SetNewDataBaby(DataBaby baby) {
        dataBaby = baby;
        UpdateUIWithInfoBaby();
    }

    private void UpdateUIWithInfoBaby() {
        imageBaby.sprite = dataBaby.GetSpriteBaby();
        textNameBaby.text = dataBaby.GetNameBaby();
        textGenerationBySecondBaby.text = dataBaby.GetTimeWorkBaby().ToString() + "s";
        textPriceBaby.text = dataBaby.GetPriceBaby().ToString();
    }
}

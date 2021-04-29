using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiStoreBabies : MonoBehaviour
{
    [SerializeField] ControlBaby[] controlDataBaby;
    [SerializeField] bool[] BoolSaveDataBaby;
    [SerializeField] Image imageBaby;
    [SerializeField] TextMeshProUGUI textNameBaby;
    [SerializeField] TextMeshProUGUI textPriceBaby;
    [SerializeField] TextMeshProUGUI textInfoBaby;

    [Header("Control UI store")]
    [SerializeField] TextMeshProUGUI textActualCoinPlayer;
    [SerializeField] GameObject gameObjectButtonBuy;

    int m_lastIndex = 0;
    DataBaby lastDataBaby = null;

    // Start is called before the first frame update
    void Start()
    {
        //verify which is purchased
        BoolSaveDataBaby = ControlDataBetweenScenes.Instance.BoolSaveDataBaby;

        for (int i = 0; i < controlDataBaby.Length; i++) {
            if (BoolSaveDataBaby[i]) {
                DesactiveControlBabyByIndex(i);
            }
        }

        //update ui
        UpdateDataInUIPlayer();
    }

    public void ActivatedDescriptionWithIndex(int index) {
        if (index >= controlDataBaby.Length) Debug.LogError("Te estas equivocando, no recibo un index con un valor de 6");
        lastDataBaby = controlDataBaby[index].GetDataBaby();
        imageBaby.sprite = lastDataBaby.GetSpriteBaby();
        textNameBaby.text = lastDataBaby.GetNameBaby();
        textInfoBaby.text = lastDataBaby.GetInfoTextBaby();
        textPriceBaby.text = lastDataBaby.GetPriceBaby().ToString();
        gameObjectButtonBuy.SetActive(true);
        m_lastIndex = index;

    }

    public void BuyNewItem() {
        if (lastDataBaby.GetPriceBaby() <= ControlCoin.Instance.Coin)
        {
            ControlCoin.Instance.SetCoinSubstractValue(lastDataBaby.GetPriceBaby());
            ControlDataBetweenScenes.Instance.AddNewDataBaby(lastDataBaby);
            gameObjectButtonBuy.SetActive(false);
            UpdateDataInUIPlayer();
            DesactiveControlBabyByIndex(m_lastIndex);
            print("Comprar el " + m_lastIndex);
        }
    }

    private void UpdateDataInUIPlayer() {
        textActualCoinPlayer.text = ControlCoin.Instance.Coin.ToString();
    }

    private void DesactiveControlBabyByIndex(int index) => controlDataBaby[index].gameObject.SetActive(false);
}

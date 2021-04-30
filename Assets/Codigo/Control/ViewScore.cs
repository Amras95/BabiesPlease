using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewScore : MonoBehaviour
{
    [Header("Control UI store")]
    [SerializeField] TextMeshProUGUI textActualCoinPlayerStore;
    [SerializeField] TextMeshProUGUI textActualCoinPlayerFactory;
    [SerializeField] TextMeshProUGUI textActualCoinPlayerCollection;

    private void Start()
    {
        ControlCoin.Instance.NewCoinUpdate += UpdateDataInUIPlayer;
        UpdateDataInUIPlayer(ControlCoin.Instance.Coin);
    }

    public void UpdateDataInUIPlayer(int coin)
    {
        textActualCoinPlayerStore.text = coin.ToString();
        textActualCoinPlayerFactory.text = coin.ToString();
        textActualCoinPlayerCollection.text = coin.ToString();
    }
}

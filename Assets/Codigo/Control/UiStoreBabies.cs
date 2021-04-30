using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiStoreBabies : MonoBehaviour
{
    [Header("Control data baby")]
    [SerializeField] ControlBaby[] controlDataBaby;
    [SerializeField] CycleBabies cycleBabies;
    [SerializeField] Image imageBaby;
    [SerializeField] TextMeshProUGUI textNameBaby;
    [SerializeField] TextMeshProUGUI textPriceBaby;
    [SerializeField] TextMeshProUGUI textInfoBaby;

    [Header("Collections")]
    [SerializeField] CollectionManager[] controlCollectionsMan;
    [SerializeField] GameObject[] buttonesControlCollections;

    [Header("Control UI store")]
    [SerializeField] TextMeshProUGUI textActualCoinPlayer;
    [SerializeField] GameObject gameObjectButtonBuy;
    [SerializeField] GameObject gameObjectFactory;
    [SerializeField] GameObject gameObjectStore;
    [SerializeField] GameObject gameObjectStoreItems;

    int m_lastIndex = 0;
    DataBaby lastDataBaby = null;
    List<DataBaby> ListBabies = new List<DataBaby>();

    // Start is called before the first frame update
    void Start()
    {
        ListBabies = cycleBabies.GetListBabies();
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

    public void BuyNewBabyPlayer() {
        if (lastDataBaby.GetPriceBaby() <= ControlCoin.Instance.Coin)
        {
            ControlCoin.Instance.SetCoinSubstractValue(lastDataBaby.GetPriceBaby());
            ControlDataBetweenScenes.Instance.AddNewDataBaby(lastDataBaby);

            gameObjectFactory.SetActive(true);

            ControlSlotInformation.Instance.ReturnToFactory(lastDataBaby);

            gameObjectStore.SetActive(false);

            if (ListBabies.Count <= 0)
            {
                gameObjectButtonBuy.SetActive(false);
                DesactiveControlBabyByIndex(m_lastIndex);
            }
            else {
                controlDataBaby[m_lastIndex].SetNewDataBaby(ListBabies[0]);
                ListBabies.RemoveAt(0);
            }
        }
    }

    public void BuyNewItemCollection(int index) {
        if (controlCollectionsMan[index].GetDataCollection().GetCoinToPurchased() <= ControlCoin.Instance.Coin)
        {
            ControlCoin.Instance.SetCoinSubstractValue(controlCollectionsMan[index].GetDataCollection().GetCoinToPurchased());

            gameObjectFactory.SetActive(true);

            ControlSlotInformation.Instance.ReturnToFactoryItemCollection(controlCollectionsMan[index].GetDataCollection());

            gameObjectStoreItems.SetActive(false);
            //buttonesControlCollections[index].SetActive(false);

            //print("Comprar el " + index);
        }
    }


    private void DesactiveControlBabyByIndex(int index) => controlDataBaby[index].gameObject.SetActive(false);
}

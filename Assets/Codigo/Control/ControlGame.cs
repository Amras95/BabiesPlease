using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGame : MonoBehaviour
{
    [SerializeField] ChatManager chatManager;
    [SerializeField] int countCoinsToGetPlayerToSutrvive = 100;

    [Header("GameObjects")]
    [SerializeField] GameObject gameObjectFondoChat;
    [SerializeField] GameObject gameObjectFactory;
    [SerializeField] GameObject gameObjectStore;
    [SerializeField] GameObject gameObjectStoreItems;
    [SerializeField] GameObject gameObjectStoreDescription;

    [Header("Menu")]
    [SerializeField] GameObject gameObjectButtonChat;
    [SerializeField] GameObject gameObjectButtonMenu;

    void Start()
    {
        chatManager.IWin += WinTheGame;
    }

    public void TheTerroristReturn() {
        print("Llegamos al limite de tiempo, cagaste");
        if (ControlCoin.Instance.Coin >= countCoinsToGetPlayerToSutrvive)
        {


            //data
            ControlCoin.Instance.SetCoinSubstractValue(countCoinsToGetPlayerToSutrvive);

            chatManager.NewConversation();

        }
        else {
            print("Estas bien muerto");
            chatManager.NewConversationLost();
            TerminatedGame();
        }

        StopTheGame();
    }

    public void WinTheGame() {
        TerminatedGame();
        print("Ganaste crack");
    }

    public void BackToTheGame() {
        GetComponent<ControlSlotInformation>().ChangeGenerationTime(false);
    }

    private void StopTheGame() {
        //go
        gameObjectFondoChat.SetActive(true);
        gameObjectFactory.SetActive(false);
        gameObjectStore.SetActive(false);
        gameObjectStoreItems.SetActive(false);
        gameObjectStoreDescription.SetActive(false);
        GetComponent<ControlSlotInformation>().ChangeGenerationTime(true);
    }

    private void TerminatedGame() {
        gameObjectButtonMenu.SetActive(true);
        gameObjectButtonChat.SetActive(false);
    }
}

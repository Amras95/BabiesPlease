using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGame : MonoBehaviour
{
    [SerializeField] int countCoinsToGetPlayerToSutrvive = 100;

    void Start()
    {
        
    }

    public void TheTerroristReturn() {
        print("Llegamos al limite de tiempo, cagaste");
        if (ControlCoin.Instance.Coin < countCoinsToGetPlayerToSutrvive) {
            print("Estas bien muerto");
        }
    }
}

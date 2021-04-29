using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCoin : MonoBehaviour
{
    public static ControlCoin Instance = null;
    public Action<int> NewCoinUpdate = delegate { };

    [Header("Principal var")]
    [SerializeField] private int m_initialCoin = 0;

    private int _coin = 0;

    [HideInInspector] public int Coin { get => _coin; private set { _coin = value; } }

    private void Awake()
    {
       // DontDestroyOnLoad(gameObject);
        Instance = this;

        Coin = m_initialCoin;

    }

    public void SetCoinSubstractValue(int newValueSubstract)
    {
        Coin -= newValueSubstract;
        ActiveEventCoin();
    }

    public void SetCoinAugmentValue(int newValueSubstract)
    {
        Coin += newValueSubstract;
        ActiveEventCoin();
    }

    private void ActiveEventCoin() => NewCoinUpdate.Invoke(Coin);

}

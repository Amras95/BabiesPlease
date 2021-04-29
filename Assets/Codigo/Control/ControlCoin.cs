using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCoin : MonoBehaviour
{
    public static ControlCoin Instance = null;

    [Header("Principal var")]
    [SerializeField] private int m_initialCoin = 0;
    [SerializeField]

    private int _coin = 0;

    [HideInInspector] public int Coin { get => _coin; private set { _coin = value; } }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;

        Coin = m_initialCoin;
    }

    void Start()
    {

    }

    public void SetCoinSubstractValue(int newValueSubstract)
    {
        Coin -= newValueSubstract;

    }


}

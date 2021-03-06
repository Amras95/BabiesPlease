using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataCollection 1", menuName = "New data /new Type Collection", order = 0)]
public class TypeCollection : ScriptableObject
{
    [SerializeField] Sprite spriteCollection;
    [SerializeField] string nameItemCollection = "";
    [SerializeField] int[] rewardCoinByItem;
    [SerializeField] int coinToPuchasedItem = 15;
    [SerializeField] public int coinMultiplicator = 15;

    public int GetRewardCoin(int index)
    {
        if (rewardCoinByItem.Length > index)
        {
            return rewardCoinByItem[index];
        }
        return 0;
    }

    public int GetMaxLevel() => rewardCoinByItem.Length-1;

    public int GetCoinToPurchased() => coinToPuchasedItem;

    public string GetNameTypeCollection() => nameItemCollection;

    public Sprite GetSpriteCollection() => spriteCollection;

    
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectionManager : MonoBehaviour
{
    [SerializeField] Image imageItem;
    [SerializeField] TextMeshProUGUI textNameItem;
    [SerializeField] TextMeshProUGUI textPriceItem;
    [SerializeField] TypeCollection typeCollection;

    void Start()
    {
        imageItem.sprite = typeCollection.GetSpriteCollection();
        textNameItem.text = typeCollection.GetNameTypeCollection();
        textPriceItem.text = typeCollection.GetCoinToPurchased().ToString();
    }

    public TypeCollection GetDataCollection() => typeCollection;
}

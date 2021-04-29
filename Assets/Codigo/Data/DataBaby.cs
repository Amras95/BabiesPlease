using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Baby", menuName = "New data baby/new baby", order = 0)]
public class DataBaby : ScriptableObject
{
    [SerializeField] Sprite spriteBaby;
    [SerializeField] int priceBaby = 0;
    [SerializeField] string textNameBaby;
    [TextArea][SerializeField] string textInformation;

    public Sprite GetSpriteBaby() => spriteBaby;

    public string GetInfoTextBaby() => textInformation;

    public string GetNameBaby() => textNameBaby;

    public int GetPriceBaby() => priceBaby;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataChat ", menuName = "New data /new chat Data", order = 0)]
public class DataChats : ScriptableObject
{
    [TextArea(15, 20)] [SerializeField] private string[] TextChats;
    [TextArea(15, 20)] [SerializeField] private string TextLost;
    [TextArea(15, 20)] [SerializeField] private string TextWin;

    public string GetTextChat(int index) => TextChats[index];

    public string GetTextWin( ) => TextWin;

    public string GetTextLost() => TextLost;

    public int LargeOfTheTextChat() => TextChats.Length;
}

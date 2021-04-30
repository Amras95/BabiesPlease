using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataChat ", menuName = "New data /new chat Data", order = 0)]
public class DataChats : ScriptableObject
{
    [TextArea][SerializeField] private string[] TextChats;
    [TextArea][SerializeField] private string TextLost;
    [TextArea][SerializeField] private string TextWin;

    public string GetTextChat(int index) => TextChats[index];

    public string GetTextWin( ) => TextWin;

    public string GetTextLost() => TextLost;

    public int LargeOfTheTextChat() => TextChats.Length;
}

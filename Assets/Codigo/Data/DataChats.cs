using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataChat ", menuName = "New data /new chat Data", order = 0)]
public class DataChats : ScriptableObject
{
    [TextArea][SerializeField] private string[] TextChats;

    public string GetTextChat(int index) {
        return TextChats[index];
    }

    public int LargeOfTheTextChat() => TextChats.Length;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataSlot1", menuName = "New data /new Data slots Main in scene", order = 0)]
public class DataSlotsMainInScene : ScriptableObject
{
    [SerializeField] public SlotMain[] allSlotsMain;
}

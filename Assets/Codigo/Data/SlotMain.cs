using System;
using System.Collections.Generic;
using UnityEngine;

public class SlotMain : MonoBehaviour
{
    public Action<int, SlotMain> NewUpgradeLevelSlot = delegate { };

    [SerializeField] int indexSlotMain = 0;

    private float generationBySecond = 0;

    // Start is called before the first frame update
    void Start()
    {
        generationBySecond = ControlSlotInformation.Instance.GetGenerationByIndex(this);
    }
}

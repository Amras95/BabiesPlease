using System;
using System.Collections.Generic;
using UnityEngine;

public class ControlSlotInformation : MonoBehaviour
{
    public static ControlSlotInformation Instance;

    [Header("Count different Slots")]
    [SerializeField] DataSlotsMainInScene dataSlotsMainInScene;
    [SerializeField] SlotMain[] allSlotsMain;

    Dictionary<SlotMain, float> dataSlotInfoGeneration = new Dictionary<SlotMain, float>();
    Dictionary<SlotMain, int> dataSlotInfoLevel = new Dictionary<SlotMain, int>();

    int actualLevel = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        allSlotsMain = dataSlotsMainInScene.allSlotsMain;
    }

    int m_lastTime = 1;
    float m_time = 0;

    private void Update()
    {
        m_time += Time.deltaTime;
        if (m_time > m_lastTime) {
            m_lastTime =(int) m_time;
        }
    }

    /*private void OnDisable()
    {
        //control slot when upgrade
        for (int i = 0; i < allSlotsMain.Length; i++)
        {
            allSlotsMain[i].NewUpgradeLevelSlot -= AugmentLevelSlotMainByType;
        }
    }*/

    public void ReturnToFactory()
    {
        //control slot when upgrade
        for (int i = 0; i < allSlotsMain.Length; i++)
        {
            allSlotsMain[i].NewUpgradeLevelSlot += AugmentLevelSlotMainByType;
        }

        //when no data
        if (dataSlotInfoGeneration.Count <= 0)
            for (int i = 0; i < allSlotsMain.Length; i++)
            {
                dataSlotInfoGeneration.Add(allSlotsMain[i], 0);
            }

    }

    public float GetLevelByIndex(SlotMain typeSlotMain) =>
        dataSlotInfoLevel[typeSlotMain];

    public float GetGenerationByIndex(SlotMain typeSlotMain) =>
        dataSlotInfoGeneration[typeSlotMain];

    private void AugmentLevelSlotMainByType(int newLevel, SlotMain typeSlotMainBusiness)
    {
        if (newLevel < dataSlotInfoLevel[typeSlotMainBusiness]) Debug.LogError("Error level int: the new level is smaller than the actual value.");

        dataSlotInfoLevel[typeSlotMainBusiness] = newLevel;
    }
}

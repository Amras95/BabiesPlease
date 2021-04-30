using System;
using System.Collections.Generic;
using UnityEngine;

public class ControlSlotInformation : MonoBehaviour
{
    public static ControlSlotInformation Instance;
    public Action<int> NewTimeToVerify = delegate { };

    [Header("Count different Slots")]
    [SerializeField] DataSlotsMainInScene dataSlotsMainInScene;
    [SerializeField] SlotMain[] allSlotsMain;

    Dictionary<SlotMain, float> dataSlotInfoGeneration = new Dictionary<SlotMain, float>();
    Dictionary<SlotMain, int> dataSlotInfoLevel = new Dictionary<SlotMain, int>();

    ControlDataBetweenScenes controlBetweenScenes;
    int actualLevel = 0;

    float m_lastTime = 1;
    int m_lastIndexSlotMainNeedBaby = 0;
    int m_time = 0;
    bool m_CantCountTimeInTheGame = false;

    private void Awake()
    {
        Instance = this;

        controlBetweenScenes = GetComponent<ControlDataBetweenScenes>();
    }

    void Start()
    {
        //allSlotsMain = dataSlotsMainInScene.allSlotsMain;

        //control slot when upgrade
        for (int i = 0; i < allSlotsMain.Length; i++)
        {
            allSlotsMain[i].NewUpgradeLevelSlot += AugmentLevelSlotMainByType;
        }

        for (int i = 0; i < allSlotsMain.Length; i++)
        {
            NewTimeToVerify += allSlotsMain[i].NewUpdateTime;
        }

        //when no data
        if (dataSlotInfoGeneration.Count <= 0)
            for (int i = 0; i < allSlotsMain.Length; i++)
            {
                dataSlotInfoGeneration.Add(allSlotsMain[i], 0);
            }
    }

    private void Update()
    {
        if (m_CantCountTimeInTheGame) return;
        m_lastTime += Time.deltaTime;
        if (m_lastTime > 1) {
            m_lastTime = 0;
            m_time += 1;
            NewTimeToVerify.Invoke(m_time);
        }
    }

    public void LastSlotMainToNeedNewBaby(int index) => m_lastIndexSlotMainNeedBaby = index;

    public void ChangeGenerationTime(bool value) {
        m_CantCountTimeInTheGame = value;
    }

    /*private void OnDisable()
    {
        //control slot when upgrade
        for (int i = 0; i < allSlotsMain.Length; i++)
        {
            allSlotsMain[i].NewUpgradeLevelSlot -= AugmentLevelSlotMainByType;
        }
    }*/

    public void ReturnToFactory(DataBaby NewDataBaby)
    {
        m_CantCountTimeInTheGame = false;
        allSlotsMain[m_lastIndexSlotMainNeedBaby].SetNewDataBaby(NewDataBaby);
        /*List<DataBaby> newListDataBabies = controlBetweenScenes.GetAllBabiesBuy();

        for (int i = 0; i < newListDataBabies.Count && i < allSlotsMain.Length; i++) {
            allSlotsMain[i].SetNewDataBaby(newListDataBabies[i]);
        }*/
    }

    public void ReturnToFactoryItemCollection(TypeCollection typeCollection)
    {
        m_CantCountTimeInTheGame = false;
        allSlotsMain[m_lastIndexSlotMainNeedBaby].SetNewDataCollection(typeCollection);
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

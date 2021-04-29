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

    int m_lastTime = 1;
    int m_lastIndexSlotMainNeedBaby = 0;
    float m_time = 0;
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
        m_time += Time.deltaTime;
        if (m_time > m_lastTime) {
            m_lastTime =(int) m_time;
            NewTimeToVerify.Invoke(m_lastTime);
        }
    }

    public void LastSlotMainToNeedNewBaby(int index)
    {
        m_CantCountTimeInTheGame = true;
        m_lastIndexSlotMainNeedBaby = index;
    }

    public void BuyNewBabyForSlotMain(DataBaby NewDataBaby) {
        allSlotsMain[m_lastIndexSlotMainNeedBaby].SetNewDataBaby(NewDataBaby);
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
        m_CantCountTimeInTheGame = false;
        /*List<DataBaby> newListDataBabies = controlBetweenScenes.GetAllBabiesBuy();

        for (int i = 0; i < newListDataBabies.Count && i < allSlotsMain.Length; i++) {
            allSlotsMain[i].SetNewDataBaby(newListDataBabies[i]);
        }*/
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

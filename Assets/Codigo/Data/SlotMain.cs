using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotMain : MonoBehaviour
{
    public Action<int, SlotMain> NewUpgradeLevelSlot = delegate { };
    [Header("UI")]
    [SerializeField] Image imageBabyWork;
    [SerializeField] Image imageCollectionItemWork;
    [SerializeField] TextMeshProUGUI textActualValueToUpgrade;
    [SerializeField] TextMeshProUGUI textActualValueGeneration;
    [SerializeField] TextMeshProUGUI textActualName;
    [SerializeField] Slider SliderTimeWork;

    [Header("Data")]
    [SerializeField] int indexSlotMain = 0;
    [SerializeField] int counSlotToUpgrade = 1;
    [SerializeField] TypeCollection typeCollection;



    [Header("Menu")]
    [SerializeField] GameObject controlMenuSlot = null;

    DataBaby dataBaby;
    // private float generationBySecond = 0;
    private int m_lastTime = 0;
    private float timeGeneration = 0;
    private int m_levelActual = 0;

    void Start()
    {
        SetTimeGeneration();
        //generationBySecond = ControlSlotInformation.Instance.GetGenerationByIndex(this);
        if (DataBabyNotNull())
        {
            textActualValueToUpgrade.text = counSlotToUpgrade.ToString();
            UpdateTextInGenerationByWork();
        }
    }

    public void OnTouchThisObject() {
        controlMenuSlot.SetActive(true);
    }

    public void UpgradeSlot()
    {
        if (DataBabyNotNull())
        {
            if (ControlCoin.Instance.Coin > counSlotToUpgrade && m_levelActual < typeCollection.GetMaxLevel())
            {
                m_levelActual++;
                ControlCoin.Instance.SetCoinSubstractValue(counSlotToUpgrade);
                counSlotToUpgrade = counSlotToUpgrade * 2;
                textActualValueToUpgrade.text = counSlotToUpgrade.ToString();
                UpdateTextInGenerationByWork();
            }
            else if (ControlCoin.Instance.Coin > counSlotToUpgrade && m_levelActual >= typeCollection.GetMaxLevel())
            {
                textActualValueToUpgrade.text = "Max";
            }
        }
    }

    public void NewUpdateTime(int timeActual) {
        if (dataBaby != null)
        {
            if (timeActual >= m_lastTime + timeGeneration)
            {
                m_lastTime = timeActual;
                SliderTimeWork.value = 0;
                NewRewardPrice();
            }
            else {
                SliderTimeWork.value = SliderTimeWork.value + 1;
            }
        }
    }

    public void SetNewDataCollection() {
        m_levelActual = 0;
        counSlotToUpgrade = 1;
        UpdateTextInGenerationByWork();
        //more things
    }

    public void SetNewDataBaby(DataBaby newData) {
        dataBaby = newData;
        imageBabyWork.sprite = newData.GetSpriteBaby();
        imageCollectionItemWork.sprite = typeCollection.GetSpriteBaby();
        textActualName.text = newData.GetNameBaby();
        SetTimeGeneration();
        print(dataBaby.name);
    }

    private void NewRewardPrice() {
        print("animation bien copada de que el collection sube");
        ControlCoin.Instance.SetCoinAugmentValue(typeCollection.GetRewardCoin(m_levelActual));
        UpdateTextInGenerationByWork();
    }

    private void SetTimeGeneration() {
        if (DataBabyNotNull())
        {
            timeGeneration = dataBaby.GetTimeWorkBaby();
            SliderTimeWork.maxValue = timeGeneration;
        }
    }

    private bool DataBabyNotNull() => dataBaby != null;

    private void UpdateTextInGenerationByWork() => textActualValueGeneration.text = typeCollection.GetRewardCoin(m_levelActual).ToString();
}

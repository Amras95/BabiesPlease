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
    [SerializeField] ParticleSystem particleSystemMoney;

    [Header("Data")]
    [SerializeField] int indexSlotMain = 0;
    [SerializeField] int counSlotToUpgrade = 1;
    [SerializeField] TypeCollection typeCollection;

    [Header("Menu")]
    [SerializeField] GameObject controlMenuSlot = null;
    [SerializeField] GameObject ButtonUpgrade = null;
    [SerializeField] AudioSource audioSourceUpgrades;

    DataBaby dataBaby;
    TypeCollection ActualTypeCollection;
    // private float generationBySecond = 0;
    private int m_lastTime = 0;
    private float timeGeneration = 0;
    private int m_levelActual = 0;

    private void Awake()
    {
        ActualTypeCollection = typeCollection;
    }

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
        ButtonUpgrade.SetActive(true);
    }

    public void UpgradeSlot()
    {
        if (DataBabyNotNull())
        {
            if (ControlCoin.Instance.Coin > counSlotToUpgrade && m_levelActual < ActualTypeCollection.GetMaxLevel())
            {
                ControlCoin.Instance.SetCoinSubstractValue(counSlotToUpgrade);
                counSlotToUpgrade = counSlotToUpgrade * 2;
                textActualValueToUpgrade.text = counSlotToUpgrade.ToString();

                m_levelActual++;
                UpdateTextInGenerationByWork();
                audioSourceUpgrades.Play();
                if (m_levelActual >= ActualTypeCollection.GetMaxLevel()) {
                    textActualValueToUpgrade.text = "Max";
                }
            }
        }
    }

    public void NewUpdateTime(int timeActual) {
        if (dataBaby != null)
        {
            if (timeActual >= m_lastTime + timeGeneration)
            {
                m_lastTime = timeActual;
                SliderTimeWork.value = SliderTimeWork.maxValue;
                NewRewardPrice();
            }
            else {
                if (SliderTimeWork.maxValue == SliderTimeWork.value) SliderTimeWork.value = 0;
                SliderTimeWork.value = SliderTimeWork.value + 1;
            }
        }
    }

    public void SetNewDataCollection(TypeCollection newtypeCollection) {
        ResetCollectionDataLevel();
        ActualTypeCollection = newtypeCollection;

        print(ActualTypeCollection.GetNameTypeCollection());
        imageCollectionItemWork.sprite = ActualTypeCollection.GetSpriteCollection();
        textActualValueToUpgrade.text = counSlotToUpgrade.ToString();
        //more things
    }

    public void SetNewDataBaby(DataBaby newData) {
        dataBaby = newData;
        imageBabyWork.sprite = newData.GetSpriteBaby();

        textActualName.text = newData.GetNameBaby();
        SetTimeGeneration();

        if (DataBabyNotNull())
        {
            if (ActualTypeCollection == null) {
                print("El collection es null?");
                ActualTypeCollection = typeCollection;
            }
            ResetCollectionDataLevel();
            textActualValueToUpgrade.text = counSlotToUpgrade.ToString();
        }

        imageCollectionItemWork.sprite = ActualTypeCollection.GetSpriteCollection();
    }

    private void NewRewardPrice() {
        print("animation bien copada de que el collection sube");
        particleSystemMoney.Play();
        ControlCoin.Instance.SetCoinAugmentValue(ActualTypeCollection.GetRewardCoin(m_levelActual));
        UpdateTextInGenerationByWork();
    }

    private void SetTimeGeneration() {
        if (DataBabyNotNull())
        {
            timeGeneration = dataBaby.GetTimeWorkBaby();
            SliderTimeWork.maxValue = timeGeneration;
        }
    }

    private void ResetCollectionDataLevel() {
        m_levelActual = 0;
        counSlotToUpgrade = 1;
        UpdateTextInGenerationByWork();
    }

    private bool DataBabyNotNull() => dataBaby != null;

    private void UpdateTextInGenerationByWork() => textActualValueGeneration.text = ActualTypeCollection.GetRewardCoin(m_levelActual).ToString();
}

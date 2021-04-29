using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMain : MonoBehaviour
{
    public Action<int, SlotMain> NewUpgradeLevelSlot = delegate { };
    [Header("Data")]
    [SerializeField] Image imageBabyWork;
    [SerializeField] Image imageCollectionItemWork;
    [SerializeField] int indexSlotMain = 0;
    [SerializeField] int counSlotToUpgrade = 0;
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
    }

    public void OnTouchThisObject() {
        controlMenuSlot.SetActive(true);
    }

    public void UpgradeSlot() {
        if (ControlCoin.Instance.Coin > counSlotToUpgrade && m_levelActual < typeCollection.GetMaxLevel()) {
            m_levelActual++;
            counSlotToUpgrade = counSlotToUpgrade * 2;
        }
    }

    public void NewUpdateTime(int timeActual) {
        if (dataBaby != null)
        {
            if (timeActual >= m_lastTime + timeGeneration)
            {
                m_lastTime = timeActual;
                NewRewardPrice();
            }
        }
    }

    public void SetNewDataBaby(DataBaby newData) {
        dataBaby = newData;
        imageBabyWork.sprite = dataBaby.GetSpriteBaby();
        imageCollectionItemWork.sprite = typeCollection.GetSpriteBaby();
        SetTimeGeneration();
        print(dataBaby.name);
    }

    private void NewRewardPrice() {
        print("animation bien copada de que el collection sube");
        ControlCoin.Instance.SetCoinAugmentValue(typeCollection.GetRewardCoin(m_levelActual));
    }

    private void SetTimeGeneration() {
        if (dataBaby != null)
        {
            timeGeneration = dataBaby.GetTimeWorkBaby();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlTime : MonoBehaviour
{
    public static ControlTime Instance = null;
    [SerializeField] private int[] _limiteTime;
    [SerializeField] TextMeshProUGUI textTimeComeEnemy;

    private bool m_startCount = false;
    private float m_timeInTheGame = 0;
    private ControlGame controlGame;


    float m_time = 1;
    int m_indexTime = 0;
    int m_timeByTextPro = 0;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        controlGame = GetComponent<ControlGame>();
        m_timeByTextPro = _limiteTime[m_indexTime];
        textTimeComeEnemy.text = m_timeByTextPro.ToString();
    }

    void Update()
    {
        if (m_startCount) {
            m_timeInTheGame += Time.deltaTime;

            if (m_timeInTheGame > m_time+1)
            {
                m_time += 1;
                m_timeByTextPro--;
                textTimeComeEnemy.text = m_timeByTextPro.ToString();
            }

            if (m_timeInTheGame > _limiteTime[m_indexTime]) {
                m_startCount = false;
                m_timeInTheGame = 0;
                textTimeComeEnemy.text = "0";
                m_time = 0;
                if (m_indexTime < _limiteTime.Length-1) m_indexTime++;
                m_timeByTextPro = _limiteTime[m_indexTime];
                controlGame.TheTerroristReturn();
            }
        }
    }

    public void StartCountTime() {
        m_startCount = true;
    }

    public int GetLimitTime() => _limiteTime[m_indexTime];
}

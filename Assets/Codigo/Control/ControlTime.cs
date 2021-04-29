using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTime : MonoBehaviour
{
    public static ControlTime Instance = null;
    [SerializeField] private int _limiteTime = 50;

    private bool m_startCount = false;
    private float m_timeInTheGame = 0;
    private ControlGame controlGame;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        controlGame = GetComponent<ControlGame>();
    }

    void Update()
    {
        if (m_startCount) {
            m_timeInTheGame += Time.deltaTime;
            if (m_timeInTheGame > _limiteTime) {
                controlGame.TheTerroristReturn();
            }
        }
    }

    public void StartCountTime() {
        m_startCount = true;
    }

    public int GetLimitTime() => _limiteTime;
}

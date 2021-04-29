using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActiveTime : MonoBehaviour
{
    public void ActiveTimeInTheGame() {
        ControlTime.Instance.StartCountTime();
    }
}

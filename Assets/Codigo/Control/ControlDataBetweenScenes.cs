using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDataBetweenScenes : MonoBehaviour
{
    public static ControlDataBetweenScenes Instance = null;
    public bool[] BoolSaveDataBaby;

    List<DataBaby> dataBabies = new List<DataBaby>();

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    public void AddNewDataBaby(DataBaby NewDataBaby) {
        dataBabies.Add(NewDataBaby);
    }

    public List<DataBaby> GetAllBabiesBuy() => dataBabies;
}

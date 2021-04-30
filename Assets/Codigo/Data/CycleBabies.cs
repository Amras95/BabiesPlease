using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CycleBabies 1", menuName = "New data/new Cycle Babies", order = 0)]
public class CycleBabies : ScriptableObject
{
    [SerializeField] DataBaby[] dataBabies;

    public List<DataBaby> GetListBabies() {
        List<DataBaby> ListBabies = new List<DataBaby>();


        for (int i = 0; i < dataBabies.Length; i++) {
            ListBabies.Add(dataBabies[i]);
        }

        return ListBabies;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Principal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Al darle al bot�n para jugar nos lleva al tutorial
    public void Play()
    {
        SceneManager.LoadScene("Tutorial");
    }

    // Se encarga de salir de la aplicaci�n
    public void Quit()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}

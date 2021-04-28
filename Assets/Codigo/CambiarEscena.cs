using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Nos permitirá cambiar entre escenas con tan solo indicar el nombre en el editor
    public void LoadScene(string s)
    {
        SceneManager.LoadSceneAsync(s);
    }
}

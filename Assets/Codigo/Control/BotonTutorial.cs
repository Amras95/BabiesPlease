using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonTutorial : MonoBehaviour
{
    public GameObject[] ListaImagen;
    private GameObject imagenTemp;
    /// <summary>
    /// Metodo que se encargará de activar el objeto de la lista del tutorial 
    /// </summary>
    public void Siguiente()
    {
        
        for(int i=0; i < ListaImagen.Length; i++)
        {
            if (i != 0)
            {
                if (ListaImagen[i - 1].activeInHierarchy == true && ListaImagen[i].activeInHierarchy == false)
                {
                    imagenTemp = ListaImagen[i];
                }
            }
        }
        imagenTemp.SetActive(true);
    }
    /// <summary>
    /// Metodo que se encargará de poner las imagenes a su valor por defecto
    /// </summary>
    public void Volver()
    {
        for (int i = 0; i < ListaImagen.Length; i++)
        {
            if (i != 0)
            {
                ListaImagen[i].SetActive(false);
            }
        }
    }
}

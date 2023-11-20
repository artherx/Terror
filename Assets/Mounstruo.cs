using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mounstruo : MonoBehaviour
{
    public GameObject tuki;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de ajustar la etiqueta según tus necesidades
        {
           tuki.SetActive(true);
        }
    }
}

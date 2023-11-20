using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puerta : MonoBehaviour
{
    public AudioSource griton;
    public GameObject tuki;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) // Asegúrate de ajustar la etiqueta según tus necesidades
        {
            tuki.SetActive(true);
            griton.Play();
            Debug.Log("El cubo ha entrado en el trigger.");
        }
    }
}

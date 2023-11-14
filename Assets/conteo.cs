using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conteo : MonoBehaviour
{
    public GameObject ascensor;
   private bool insideTrigger = false;
    private float tiempoDentro = 0f;

    private void Update()
    {
        if (insideTrigger)
        {
            tiempoDentro += Time.deltaTime;
            Debug.Log("Tiempo dentro del trigger: " + tiempoDentro + " segundos");
        }
        if(tiempoDentro>=4f && tiempoDentro <8)
        {
            transform.Rotate(0,0,1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de ajustar la etiqueta según tus necesidades
        {
            insideTrigger = true;
            Debug.Log("El cubo ha entrado en el trigger.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de ajustar la etiqueta según tus necesidades
        {
            insideTrigger = false;
            tiempoDentro = 0f; // Reiniciar el tiempo cuando el cubo sale del trigger
            Debug.Log("El cubo ha salido del trigger.");
        }
    }
}

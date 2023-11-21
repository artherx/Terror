using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puerta : MonoBehaviour
{
    public AudioSource griton;
    public GameObject tuki;
    private bool salir=false;
    private float tiempo = 0f;

    private void Update() {
        if(salir == true)
        {
            tiempo+=Time.deltaTime;
            if(tiempo >=2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
            }
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) // Asegúrate de ajustar la etiqueta según tus necesidades
        {
            salir=true;
            tuki.SetActive(true);
            griton.Play();
            Debug.Log("El cubo ha entrado en el trigger.");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class conteo : MonoBehaviour
{
    public GameObject ascensor;
    public GameObject ascensor1;
    public GameObject puerta;
    public GameObject puerta1;
    public GameObject alarmaP;
    public GameObject pasos;
   private bool insideTrigger = false;
    private float tiempoDentro = 0f;
    private float tiempoDentroT = 0f;
    private float digitos = 4f;
    private Vector3 pos, pos1;
    public Light luz;
    private Vector3 finalp, finalp1;
    public float velo = 1.0f;
    private bool derub=false;
    private float luzT;
    private bool termino=false;

    private void Start() {
        pos = new Vector3(-2.44000006f,1.24799991f,3.92600012f);        
        pos1 =new Vector3(0.180000007f,1.24799991f,3.92600012f);
        finalp = new Vector3(-1.59000003f,1.24799991f,3.92600012f);  
        finalp1 =new Vector3(-0.649999976f,1.24799991f,3.92600012f); 
    }
    private void Update()
    {
        float pasos = velo * Time.deltaTime;
        if( derub == true)
        {
            luzT += Time.deltaTime;
            if (luzT >=.35 )
            {
                luzT = 0;
                if (luz.intensity==0)
                    luz.intensity=1;
                else
                    luz.intensity=0;
                
            }
            
        }
        if (termino==false)
        {
            if (insideTrigger)
            {
                tiempoDentro += Time.deltaTime;
                Debug.Log("Tiempo dentro del trigger: " + tiempoDentro + " segundos");
                puerta.transform.position = Vector3.Lerp(puerta.transform.position,finalp,pasos);
                puerta1.transform.position = Vector3.Lerp(puerta1.transform.position,finalp1,pasos);
            }
            if(tiempoDentro>=4f && tiempoDentro <8)
            {
                tiempoDentroT += Time.deltaTime;
                 alarmaP.SetActive(true);
                derub = true;
                if (tiempoDentroT>=0.1f&&tiempoDentro>=4f)
                {

                    transform.Rotate(digitos,-digitos,digitos);
                    digitos*=-1;
                    tiempoDentroT=0;

                }

            }
            
        }
        if (tiempoDentro >=8)
            {
                Destroy(ascensor);
                ascensor1.SetActive(true);
                termino = true;
                puerta.transform.position = Vector3.Lerp(puerta.transform.position,pos,pasos);
                puerta1.transform.position = Vector3.Lerp(puerta1.transform.position,pos1,pasos);
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de ajustar la etiqueta según tus necesidades
        {
            insideTrigger = true;
            Destroy(pasos);
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

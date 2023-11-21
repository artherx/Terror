using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caminando : MonoBehaviour
{
    private Vector3 final;
    public AudioSource mu;
    public float velo = 1.0f;
    void Start() {
        final = transform.position + new Vector3(7,0,0);
        mu.Play();
    }
    
    private void Update() {
        float pasos = velo * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position,final,pasos);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torre : MonoBehaviour
{


    public GameObject projetilPrefab;

    public float tempoderecarga = 1f;

    private float momentodoultimodisparo;

        
    // Start is called before the first frame update
    void Start()
    {
        Atira();
    }

    // Update is called once per frame
    void Update()
    {
        Atira();
    }

    private void Atira()
    {
        float tempoAtual = Time.time;
        if (tempoAtual > momentodoultimodisparo + tempoderecarga)
        {
            momentodoultimodisparo = tempoAtual;
            GameObject pontodedisparo = this.transform.Find("canhaodatorre/pontodedisparo").gameObject;
            Vector3 posicaoDopontodedisparo = pontodedisparo.transform.position;
            Instantiate(projetilPrefab, posicaoDopontodedisparo, Quaternion.identity);
        }



    }
}

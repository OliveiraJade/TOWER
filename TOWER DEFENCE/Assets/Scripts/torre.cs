using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torre : MonoBehaviour
{


    public GameObject projetilPrefab;

    public float tempoderecarga = 1f;

    private float momentodoultimodisparo;

    [SerializeField] private float raioDeAlcance;

        
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Inimigo alvo = EscolheAlvo();
        if(alvo != null)
        {
            Atira(alvo);
        }
      
    }

    private void Atira(Inimigo inimigo)
    {
        float tempoAtual = Time.time;
        if (tempoAtual > momentodoultimodisparo + tempoderecarga)
        {
            momentodoultimodisparo = tempoAtual;
            GameObject pontodedisparo = this.transform.Find("canhaodatorre/pontodedisparo").gameObject;
            Vector3 posicaoDopontodedisparo = pontodedisparo.transform.position;
            //Instantiate(projetilPrefab, posicaoDopontodedisparo, Quaternion.identity);
            GameObject projetilObject = (GameObject)Instantiate(projetilPrefab, posicaoDopontodedisparo, Quaternion.identity);
            missil missilpropriedade = projetilObject.GetComponent<missil>();
            missilpropriedade.DefineAlvo(inimigo);

        }
    }

    private Inimigo EscolheAlvo()
    {
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");
        foreach(GameObject inimigo in inimigos)
        {
            if (EstaNoRaioDeAlcance(inimigo))
            {
                return inimigo.GetComponent<Inimigo>();
            }
        }
        return null;
    }

    private bool EstaNoRaioDeAlcance(GameObject inimigo)
    {
        Vector3 posicaoDoInimigoNoPlano = Vector3.ProjectOnPlane(inimigo.transform.position, Vector3.up);
        Vector3 posicaoDaTorreNoPlano = Vector3.ProjectOnPlane(this.transform.position, Vector3.up);
        float distanciaParaInimigo = Vector3.Distance(posicaoDaTorreNoPlano, posicaoDoInimigoNoPlano);
        return distanciaParaInimigo <= raioDeAlcance;
    }
}

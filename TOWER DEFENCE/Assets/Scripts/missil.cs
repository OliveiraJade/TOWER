using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missil : MonoBehaviour
{
    private float velocidade = 5f;

    private Inimigo alvo;

    [SerializeField] private int pontosDeDano;


    private void Start()
    {
   
        AutoDestroiDepoisDeSegundos(4);
    }

    public void DefineAlvo(Inimigo inimigo)
    {
        alvo = inimigo;
    }
    // Update is called once per frame
    void Update()
    {
        Anda();
        AlteraDirecao();
    }

    private void AlteraDirecao()
    {
        Vector3 posicaoAtual = transform.position;
        Vector3 posicaodoalvo = alvo.transform.position;
        Vector3 direcaodoalvo = posicaodoalvo - posicaoAtual;
        transform.rotation = Quaternion.LookRotation(direcaodoalvo);
    }

    private void Anda()
    {
        Vector3 posicaoAtual = transform.position;
        Vector3 deslocamento = transform.forward * Time.deltaTime * velocidade;
        transform.position = posicaoAtual + deslocamento;
    }

    private void OnTriggerEnter(Collider elementoColidido)
    {
        if (elementoColidido.CompareTag("Inimigo"))
        {
            Destroy(this.gameObject);
            //Destroy(elementoColidido.gameObject);
            Inimigo inimigo = elementoColidido.GetComponent<Inimigo>();
            inimigo.RecebeDano(pontosDeDano);
        }

    }
    


    private void AutoDestroiDepoisDeSegundos(float segundos)
    {
        Destroy(this.gameObject, segundos);
    }
}

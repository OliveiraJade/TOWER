using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogo : MonoBehaviour
{
    [SerializeField] private GameObject torrePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ClicouComBotaoPrimario())
        {
            ContruirTorre();
        }
    }

    private bool ClicouComBotaoPrimario()
    {
        return Input.GetMouseButtonDown(0);
    }

    private void ContruirTorre()
    {
        Vector3 posicaoDoClique = Input.mousePosition;
        RaycastHit elementoAtigidoPeloRaio = DisparaRaioDaCameraAteUmPonto(posicaoDoClique);
        if(elementoAtigidoPeloRaio.collider != null)
        {
            Vector3 posicaoDoElemento = elementoAtigidoPeloRaio.point;
            Instantiate(torrePrefab, posicaoDoElemento, Quaternion.identity);
        }
    }

    private RaycastHit DisparaRaioDaCameraAteUmPonto(Vector3 ponto)
    {
        Ray raio = Camera.main.ScreenPointToRay(ponto);
        RaycastHit elementoAtigidoPeloRaio;
        float comprimentoMaximoDoRaio = 100f;
        Physics.Raycast(raio, out elementoAtigidoPeloRaio, comprimentoMaximoDoRaio);

        return elementoAtigidoPeloRaio;
    }
}

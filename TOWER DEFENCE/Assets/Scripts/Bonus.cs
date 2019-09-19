using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bonus : MonoBehaviour
{
    private Text campoTexto;

    public Jogador jogador;

    // Start is called before the first frame update
    void Start()
    {
        campoTexto = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        campoTexto.text = "Bônus: " + jogador.GetBonus();
    }
}

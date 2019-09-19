using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    [SerializeField] private int vida;

    private int bonus;

    public int GetVida()
    {
        return vida;
    }

    public void PerdeVida()
    {
        if(EstaVivo()){
            vida--;
        }
    }

    public bool EstaVivo()
    {
        return vida > 0;
    }

    public void AumentaVida()
    {
        vida++;

    }

    public int GetBonus()
    {
        return bonus;
    }

    public void AumentaBonus()
    {
        bonus++;
        if(bonus >= 3)
        {
            AumentaVida();
            ZeraBonus();
        }
    }

    public void ZeraBonus()
    {
        bonus = 0;
    }
}

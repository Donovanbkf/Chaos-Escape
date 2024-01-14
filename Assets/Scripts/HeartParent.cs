using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartParent : MonoBehaviour
{
    public GameObject[] vidas;
    public LogicaCambiarNivel level;
    public PlayerMovement player;
    private int CantVidas = 3;

    public void DesactivarVida()
    {
        
        if (CantVidas > 0)
        {
            CantVidas -= 1;
            vidas[CantVidas].SetActive(false);
            if (CantVidas == 0)
            {
                CantVidas = 3;
                //player.Morir();
                level.CambiarNivel(1);
            }
        }
        
        
    }

    public void ActivarVida()
    {
        vidas[2].SetActive(true);
    }
}

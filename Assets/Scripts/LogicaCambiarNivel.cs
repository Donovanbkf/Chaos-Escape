using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaCambiarNivel : MonoBehaviour
{
    public int indiceNivel;

    public void CambiarNivel(int indice)
    {
        SceneManager.LoadScene(indice);
    }
}


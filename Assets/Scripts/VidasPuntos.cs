using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidasPuntos : MonoBehaviour
{
    public static VidasPuntos instance;
    
    [SerializeField] private TextMeshProUGUI vidasTexto;
    [SerializeField] private TextMeshProUGUI puntosTexto;

    [SerializeField] private GameObject perdisteCanvas;
    [SerializeField] private GameObject ganasteCanvas;

    [SerializeField] private GameObject bloquesParent;

    [SerializeField]  private int vidasActuales;
    private int puntosActuales;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        vidasTexto.text = vidasActuales.ToString();
        perdisteCanvas.SetActive(false);
        ganasteCanvas.SetActive(false);
    }

    public void SumarPuntos(int puntos)
    {
        puntosActuales += puntos;
        puntosTexto.text = puntosActuales.ToString();

        if (bloquesParent.transform.childCount <= 1)
        {
            ganasteCanvas.SetActive(true);
        }
    }

    public void CambiarVidas(int vidas)
    {
        vidasActuales += vidas;
        vidasTexto.text = vidasActuales.ToString();

        if (vidasActuales <= 0)
        {
            perdisteCanvas.SetActive(true);
        }
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

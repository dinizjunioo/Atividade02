using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlvoVida : MonoBehaviour, IDamageAlvo
{
    // Start is called before the first frame update
    [SerializeField] private AlvoStatusSO alvoStatus;
    private int vidaAtual;
    void Start()
    {
        vidaAtual = alvoStatus.vida;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void danoCausado(int dano)
    {
        vidaAtual -= dano;
        VerificaSeEstaMorto();
    }
    private void VerificaSeEstaMorto()
    {
        if (vidaAtual <= 0)
            Destroy(gameObject);
    }
}

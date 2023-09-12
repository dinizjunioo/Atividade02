using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AlvoVida : MonoBehaviour, IDamageAlvo
{
    // Start is called before the first frame update
    [SerializeField] private AlvoStatusSO alvoStatus;
    [SerializeField] private Slider vidaBarSlider;
    [SerializeField] private Image imageVida;
    [SerializeField] private Color maxVidaColor;
    [SerializeField] private Color zeroVidaColor;
    //[SerializeField] private GameObject damageText;

    private int vidaAtual;
    void Start()
    {
        vidaAtual = alvoStatus.vida;
        setHealBarUI();
    }

    public void setHealBarUI()
    {
        float percentualVida = calculePV();
        vidaBarSlider.value = percentualVida;
        imageVida.color = Color.Lerp(zeroVidaColor, maxVidaColor, percentualVida / 100);
    }

    private float calculePV()
    {
        return ((float)vidaAtual / (float)alvoStatus.vida ) * 100;
    }
    public void danoCausado(int dano)
    {
        vidaAtual -= dano;
        //Instantiate(damageText, transform.position, Quaternion.identity).GetComponent< DamageText >().
        VerificaSeEstaMorto();
    }
    private void VerificaSeEstaMorto()
    {
        if (vidaAtual <= 0)
            Destroy(gameObject);
    }
}

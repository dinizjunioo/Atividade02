using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;

[CreateAssetMenu(fileName ="Inventario", menuName ="Inventario/Inventary")]
public class InventarioSO : ScriptableObject
{
    [Tooltip("Colecoes de armas e municoes")]
    //[SerializeField]
    public List<Arma> _armas = new List<Arma>();
    public List<Municao> municoes = new List<Municao>();
    // terá objetos municao e armas na cena com memoria já pré-alocada para eles

    //public List<Arma> GetArmas()
    //{
    //    return _armas;
    //}
    //
    //public List<Municao> GetMunicao()
    //{
    //    return municoes;
    //}

}

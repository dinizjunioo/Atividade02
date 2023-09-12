using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;
[CreateAssetMenu(fileName = "Municao", menuName = "Inventario/Municao")]
public class Municao : ScriptableObject
{
   
    [TextArea(3, 3)] public string descricao;
    
    public AmmoType tipo;
    public int num_balas;
   
    public GameObject prefab;
    //public Texture icon;
    //public InventarioSO inventario;
    //public string Item => tipo;
    public enum AmmoType
    {
        ShotgunShells,
        RifleAmmo,
        PistolAmmo,
        // Outros tipos de munições
    }
}

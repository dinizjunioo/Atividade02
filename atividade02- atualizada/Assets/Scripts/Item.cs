using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create new Item")]
[System.Serializable]
public class Item : ScriptableObject
{

    public int id;

    [TextArea(3, 3)] public string description;

    public Tipo tipo;
    public string itemNome;

    
    public enum Tipo
    {
        arma,
        municao,
    }
    
    public GameObject prefab;
    public Texture icon;

    
}


#region test
//private static int current_id;
//public Items()
//{
//    id = current_id;
//    current_id++;
//}
//[Header("Don't touch id!!!")]
#endregion
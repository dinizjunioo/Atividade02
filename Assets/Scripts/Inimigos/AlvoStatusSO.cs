using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Inimigo", menuName = "Inimigo/Inimigo")]
public class AlvoStatusSO : ScriptableObject
{
    [Header("Status do inimigo")]
    public string nome;
    public int vida;
}

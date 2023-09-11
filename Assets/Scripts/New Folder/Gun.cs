using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName ="Gun")]
public class Gun : ScriptableObject
{
    // Start is called before the first frame update
    public string gunName;
    public GameObject gunPrefab;

    [Header("status ")]
    public int minimumDamage;
    public int maximumDamage;
    public float maximumRange;

    public virtual void OnMouseDown(Transform cameraPos)
    {

    }

    public virtual void OnMouseHold(Transform cameraPos)
    {

    }

}

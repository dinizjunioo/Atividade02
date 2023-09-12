using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looting : MonoBehaviour
{

    private Ilootable currentTarget;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if (currentTarget != null)
                currentTarget.OnInteract();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Municao"))
        {
            Debug.Log("Bateu");
            Ilootable ilootable = collision.gameObject.GetComponent<Ilootable>();
            if (ilootable != null)
            {
                if (ilootable == currentTarget) return;
                else if (currentTarget != null) currentTarget = ilootable;
            }
            else
            {
                if (currentTarget != null)
                    currentTarget = null;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemIteration : MonoBehaviour
{

    Transform cam;
    [SerializeField] LayerMask itemLayer;
    InventorySystem inventorySystem;

    [SerializeField] TextMeshProUGUI txt_HoveredItem;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        inventorySystem = GetComponent<InventorySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, 2, itemLayer))
        {
            if (!hit.collider.GetComponent<Municao>())
                return;



            //txt_HoveredItem.text = $"Press 'F' to pick up {hit.collider.GetComponent<Municao>().num_balas}x {hit.collider.GetComponent<ItemObject>().itemStats.name}";

            if (Input.GetKeyDown(KeyCode.F))
            {
               // inventorySystem.PickUpItem(hit.collider.GetComponent<Municao>());
            }



        }
        else
        {
            txt_HoveredItem.text = string.Empty;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class objectSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnpoint;

    private void Update()
    {
        if (mouseOverUI())
        {
            //Debug.Log("mouse over UI");
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("mouse down");
                Instantiate(prefab, spawnpoint.position, spawnpoint.rotation);
            }
        }
    }

    private bool mouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    /*
    private void OnMouseOver()
    {
        Debug.Log("mouse over");
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("mouse down");
            Instantiate(prefab, spawnpoint.position, spawnpoint.rotation);
        }
    }
    */
}

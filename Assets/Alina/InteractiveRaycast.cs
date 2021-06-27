using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class InteractiveRaycast : MonoBehaviour
{
    private GameObject box;
    private GameObject next;


    [SerializeField]
    private GameObject prefab;

    private Vector3 scale;

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit))
            {
                /*Debug.Log(hit.collider.gameObject.name);
                 new Vector3 (hit.collider.gameObject.transform.position.x , hit.collider.gameObject.transform.position.y + prefab.transform.localScale.y/2 ,hit.collider.gameObject.transform.position.z)*/
                if (hit.collider.gameObject.CompareTag("InteractivePlane"))
                {
                    Vector3 pos = hit.collider.gameObject.transform.position;
                    Instantiate(prefab, pos , Quaternion.identity, hit.collider.gameObject.transform);

                }
                if (hit.collider.gameObject.GetComponent<InteractiveBox>()) 
                {
                    if (box == null)
                    {
                        box = hit.collider.gameObject;
                    }
                    else
                    {
                        next = hit.collider.gameObject;
                        box.GetComponent<InteractiveBox>().AddNext(next.GetComponent<InteractiveBox>());
                        box = null;
                        next = null;
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit))
            {
                /*Debug.Log(hit.collider.gameObject.name);*/
                if (hit.collider.gameObject.CompareTag("InteractivePlane"))
                {
                    Instantiate(prefab, new Vector3(hit.normal.x, prefab.transform.localScale.y / 2, hit.normal.z), Quaternion.identity);
                }
            }
        }

    }
}
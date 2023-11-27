using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera _camera;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<PlayerLook>().Cam;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, distance, layerMask))
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Debug.Log(hitInfo.collider.GetComponent<Interactable>().promtMessage);
            }
        }
    }
}

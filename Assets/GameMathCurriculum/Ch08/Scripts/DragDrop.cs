using Unity.Collections;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public Camera cam;
    public LayerMask dragObject;
    public LayerMask dropZone;
    public LayerMask ground;
    private bool isDraging = false;
    private DragObject draginObject;
    private GameObject dropinZone;

    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, dragObject))
            {
                isDraging = true;
                draginObject = hitInfo.collider.GetComponent<DragObject>();
                draginObject.DragStart();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (isDraging)
            {
                if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, dropZone))
                {
                    draginObject.DragEnd();
                    dropinZone = GameObject.FindGameObjectWithTag("Target");
                    draginObject.transform.position = dropinZone.transform.position + new Vector3(0,0.4f, 0);
                }
                else
                {
                    draginObject.Return();
                }
            }
            isDraging = false;
            draginObject = null;
        }
        else if (isDraging)
        {
            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, ground))
            {
                draginObject.transform.position = hitInfo.point;
            }
        }
    }
}
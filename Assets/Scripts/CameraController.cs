using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public delegate void OnTileClickedHandler(Vector2Int pos);

    public event OnTileClickedHandler TileClicked;

    private Vector3 camMinPos; private Vector3 camMaxPos;

    public void Update()
    {
        Moving();
        CheckMouseClick();
    }

    private void Moving() { 
    
        float axisX = Input.GetAxis("Horizontal");
        float axisZ = Input.GetAxis("Vertical");
        float axisY = Input.GetAxis("Mouse ScrollWheel");

        transform.position += new Vector3(axisX, axisY * GameConfig.SCROLL_WHEEL_SPEED_MULTIPLIER, axisZ) * GameConfig.CAMERA_SPEED * Time.deltaTime;
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, camMinPos.x, camMaxPos.x), 
            Mathf.Clamp(transform.position.y, camMinPos.y, camMaxPos.y), 
            Mathf.Clamp(transform.position.z, camMinPos.z, camMaxPos.z)
        );
    }

    private void CheckMouseClick()
    {
        if (Input.GetMouseButtonDown(0)) // À Ã
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 hitPoint = hit.point;

                TileClicked?.Invoke(new Vector2Int((int)(hitPoint.x - 0.5f), (int)(hitPoint.z - 0.5f)));
            }
        }
    }

    public void SetMoveLimits(Vector3 minPos, Vector3 maxPos)
    {
        camMinPos = minPos;
        camMaxPos = maxPos;
    }


}

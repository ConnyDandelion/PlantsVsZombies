using UnityEngine;
using UnityEngine.Events;
public class GunCreate : MonoBehaviour
{
    [SerializeField]
    private float raycastDistance = 100f;
    [SerializeField]

    private LayerMask targetLayer;
    [SerializeField]

    private string stepTag = "Step";

    private Transform objetcToPlace;

    private bool objectPlaced = false;

    private void Update()
    {
        if (objetcToPlace == null) return;
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.Main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, raycastDistance, targetLayer))
            {
                if (hitInfo.collider.CompareTag(stepTag))
                {
                    currentStep = hitInfo.collider.GetComponent<Step>();
                    objetcToPlace.position = hitInfo.collider.transform.position;
                    objectPlaced = true;

                }
                else
                {
                    objectPlaced = false;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (!objectPlaced || currentStep == null || currentStep.IsOccupied)
            {
                objetcToPlace.gameObject.SetActive(false);
            }
            else
            {
                if (hitInfo.collider.CompareTag("Floor"))
                {
                    objetcToPlace.position = hitInfo.point;
                }

                objectPlaced = false;
                currentStep = null;
            }
        }
    }

    public void SetObjectToPlace(Transform objTransform)
    {
        objetcToPlace = objTransform;
        objectPlaced = false;
        currentStep = null;
    }
}

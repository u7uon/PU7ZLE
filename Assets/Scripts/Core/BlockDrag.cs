using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BlockDrag : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 offset;
    private Camera cam;

    private bool isDragging = false;

    [Header("Drag Effects")]
    [SerializeField] private float liftScale = 1.1f;
    [SerializeField] private float followSpeed = 20f;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        startPosition = transform.position;
        isDragging = true;

        Vector3 mouseWorld = GetMouseWorldPos();
        offset = transform.position - mouseWorld;

        transform.localScale *= liftScale;
    }

    private void OnMouseDrag()
    {
        Debug.Log("OnMouseDrag");
        if (!isDragging) return;

        Vector3 targetPos = GetMouseWorldPos() + offset;
        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            Time.deltaTime * followSpeed
        );
    }

    private void OnMouseUp()
    {
        Debug.Log("OnMouseUp");
        isDragging = false;

        transform.localScale /= liftScale;

        // TẠM THỜI: thả ra quay về vị trí cũ
        transform.position = startPosition;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mouse = Input.mousePosition;
        mouse.z = Mathf.Abs(cam.transform.position.z);
        return cam.ScreenToWorldPoint(mouse);
    }
}
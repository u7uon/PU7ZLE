using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BlockDrag : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 offset;
    private Camera cam;

    private bool isDragging = false;

    [Header("Drag Effects")]
    [SerializeField] private float liftScale = 2f;
    [SerializeField] private float followSpeed = 20f;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void OnMouseDown()
    {
        startPosition = transform.position;
        isDragging = true;

        Vector3 mouseWorld = GetMouseWorldPos();
        offset = transform.position - mouseWorld;
        transform.localScale = Vector3.one ;;

    }

    private void OnMouseDrag()
    {
        if (!isDragging) return;

        Vector3 targetPos = GetMouseWorldPos() + offset;
        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            Time.deltaTime * followSpeed
        );
        CusorManager.instance.OnHolding();
    }

    private void OnMouseEnter()
    {
        if (!isDragging)
        {
            CusorManager.instance.OnHover();
        }
    }

    private void OnMouseExit()
    {
        if (!isDragging)
        {
            CusorManager.instance.OnNormal();
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;

        transform.localScale /= liftScale;
        // TẠM THỜI: thả ra quay về vị trí cũ
        transform.position = startPosition;
        gameObject.transform.localScale = 0.5f * Vector3.one;
        CusorManager.instance.OnNormal();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mouse = Input.mousePosition;
        mouse.z = Mathf.Abs(cam.transform.position.z);
        return cam.ScreenToWorldPoint(mouse);
    }
}
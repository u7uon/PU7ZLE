using UnityEngine;
using UnityEngine.UI;

public class CusorManager : MonoBehaviour
{
    public static CusorManager instance;
    
    [SerializeField] private Texture2D cursorNormal;
    [SerializeField] private Texture2D cursorHolding;

    [SerializeField] private Texture2D cursorHover;

    void Awake()
    {
        instance = this;

    }

    public void OnHolding()
    {
        Cursor.SetCursor(cursorHolding, new Vector2(0.0873726606f, 0.922570348f), CursorMode.Auto);
    }

    public void OnNormal()
    {
        Cursor.SetCursor(cursorNormal, new Vector2(0.0873726606f, 0.922570348f), CursorMode.Auto);
    }
    

    public void OnHover()
    {
        
        Cursor.SetCursor(cursorHover, new Vector2(0.0873726606f, 0.922570348f), CursorMode.Auto);   
    }
}

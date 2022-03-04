using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveMouse : MonoBehaviour
{
    public Texture2D ReleasedState;
    public Texture2D PressedState;
    private Vector2 _hotspot = Vector2.zero;
    private CursorMode _cursorMode = CursorMode.Auto;
    public static ReactiveMouse instance;
    Element element;
    Vector3 mouseWorldPosition;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Cursor.SetCursor(ReleasedState, _hotspot, _cursorMode);
    }

    private void Update()
    {
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = Camera.main.nearClipPlane;
        RaycastHit2D hitData = Physics2D.Raycast(new Vector2(mouseWorldPosition.x, mouseWorldPosition.y), Vector2.zero, 0);

        Debug.Log($"Mouse position is {mouseWorldPosition.x}, {mouseWorldPosition.y}");

        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(PressedState, _hotspot, _cursorMode);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(ReleasedState, _hotspot, _cursorMode);
        }
    }

    






}

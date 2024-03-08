using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManage : MonoBehaviour
{
    [SerializeField] Texture2D cursorTexture;
    private Vector2 cursorPosition;
    void Start()
    {
        cursorPosition = new Vector2(cursorTexture.width, cursorTexture.height);
        Cursor.SetCursor(cursorTexture, cursorPosition, CursorMode.Auto);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControler : MonoBehaviour
{
    public Sprite[] cursorSprite;

    void Start()
    {
        Cursor.SetCursor(cursorSprite[0].texture, Vector2.zero, CursorMode.Auto);
    }


    void Update()
    {
        
    }
}

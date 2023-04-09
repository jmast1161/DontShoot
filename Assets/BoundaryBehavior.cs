using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryBehavior : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2 - 1f;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2 - 1f;
    }

    private void LateUpdate() 
    {
        var viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 - objectWidth, screenBounds.x + objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y,  screenBounds.y * -1 - objectHeight, screenBounds.y + objectHeight);
        transform.position = viewPos;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    private bool _isInCollider;

    private void OnMouseDrag()
    {
        if (_isInCollider)
            return;
        
        transform.position = GetMouseWorldPos() + mOffset;
    }

    private void OnCollisionEnter(UnityEngine.Collision other)
    {
        _isInCollider = true;
    }

    private void OnCollisionExit(UnityEngine.Collision other)
    {
        _isInCollider = false;
    }

    void OnMouseDown()
    {
        _isInCollider = false;
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
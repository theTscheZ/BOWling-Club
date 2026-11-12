using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class BowString : MonoBehaviour
{
    [SerializeField]
    private Transform _stringStart, _stringEnd;
    
    private LineRenderer _lineRenderer;
    
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void CreateString(Vector3? midPosition)
    {
        Vector3[] linePoints = new Vector3[midPosition == null? 2 : 3];
        linePoints[0] = _stringStart.localPosition;
        if(midPosition != null)
        {
            linePoints[1] = transform.InverseTransformPoint(midPosition.Value);
        }
        linePoints[^1] = _stringEnd.localPosition;
        
        _lineRenderer.positionCount = linePoints.Length;
        _lineRenderer.SetPositions(linePoints);
    }
    
    void Start()
    {
        CreateString(null);
    }
}

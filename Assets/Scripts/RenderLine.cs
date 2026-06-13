using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderLine : MonoBehaviour
{
    public LineRenderer Line;
    public LinePoint[] Points;
    public int Interpolation = 1;
    // Start is called before the first frame update
    void Start()
    {
        BuildLine();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLine();
    }

    void BuildLine() 
    {
        Line.useWorldSpace = true;
        Line.positionCount = ((Points.Length -1 ) * Interpolation) + 1;
    }

    void UpdateLine()
    {
        for (int i = 0; i < Points.Length; i++)
        {
            LinePoint point = Points[i];
            Vector3 pointObjectPosition = point.PointObject.transform.position;
            Vector3 pointPosition = new Vector3(pointObjectPosition.x + point.AnchorX, pointObjectPosition.y + point.AnchorY, -0.1f);
            Line.SetPosition(i * Interpolation, pointPosition);
            if (i == Points.Length - 1) break;
            for (int i2 = 1; i2 < Interpolation; i2++)
            {
                LinePoint nextPoint = Points[i + 1];
                Vector3 nextPointObjectPosition = nextPoint.PointObject.transform.position;
                Vector3 nextPointPosition = new Vector2(nextPointObjectPosition.x + nextPoint.AnchorX, nextPointObjectPosition.y + nextPoint.AnchorY);
                float progress = i2 / (float) Interpolation;
                Vector3 newPointPosition = CalculateCurve(pointPosition.x, nextPointPosition.x, pointPosition.y, nextPointPosition.y, progress, i);
                Line.SetPosition((i * Interpolation) + i2, newPointPosition);
            }
        }
    }

    Vector3 CalculateCurve(float oldX, float nextX, float oldY, float nextY, float amount, int iteration)
    {
        float newX = Mathf.Lerp(oldX, nextX, amount);
        float newY = Mathf.Lerp(oldY, nextY, amount);
        Vector2 direction = new Vector2(oldX, oldY) - new Vector2 (nextX, nextY);
        float length = direction.magnitude;
        direction.Normalize();
        Vector2 curve = new Vector2(newX, newY);
        curve += Vector2.Perpendicular(direction) * (Mathf.Sqrt(length / 16) * Mathf.Sin(amount * Mathf.PI)) * ((iteration % 2 * -2) +1);
        return new Vector3 (curve.x, curve.y, -0.1f);
    }
}

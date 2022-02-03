using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CubicBezierDemo : MonoBehaviour
{
    public Transform AnchorStart;
    public Transform AnchorEnd;
    public Transform ControlStart;
    public Transform ControlEnd;

    [Range(2, 100)]
    public int CurveResolution = 10;

    public float TweenTimeLength = 3;
    private float TweenTimeCurrent = 0;

    private bool isPlaying = false;

    public AnimationCurve temporalEasing;

    void Start()
    {
        
    }

    void Update()
    {
        if (isPlaying) TweenTimeCurrent += Time.deltaTime;

        float p = Mathf.Clamp(TweenTimeCurrent / TweenTimeLength, 0, 1);
        p = temporalEasing.Evaluate(p);

        Vector3 pos = FindPointOnCurve(p);
        transform.position = pos;

        Vector3 pos2 = FindPointOnCurve(p + 0.5f);
        Vector3 curveForward = (pos2 - pos).normalized;

        Quaternion rot = Quaternion.LookRotation(curveForward);
        transform.rotation = rot;

        if (TweenTimeCurrent >= TweenTimeLength) isPlaying = false;
    }

    public void PlayTween(bool fromBeginning = true)
    {
        isPlaying = true;
        if(fromBeginning) TweenTimeCurrent = 0;
    }

    private void OnDrawGizmos()
    {
        for(int i = 0; i < CurveResolution; i++)
        {
            Vector3 a = FindPointOnCurve(i / (float)CurveResolution);
            Vector3 b = FindPointOnCurve((i+1)/(float)CurveResolution);
            Gizmos.DrawLine(a, b);
        }
    }

    Vector3 FindPointOnCurve(float percent)
    {
        // A = point between start control and end control
        Vector3 a = AnimMath.Lerp(ControlStart.position, ControlEnd.position, percent);
        // B = point between start anchor and start control
        Vector3 b = AnimMath.Lerp(AnchorStart.position, ControlStart.position, percent);

        // C = point between end control and end anchor
        Vector3 c = AnimMath.Lerp(ControlEnd.position, AnchorEnd.position, percent);

        // D = point between B and A
        Vector3 d = AnimMath.Lerp(b, a, percent);

        // E = point between A and C
        Vector3 e = AnimMath.Lerp(a, c, percent);

        // F point betwwen D and E
        return AnimMath.Lerp(d, e, percent);
    }
}

[CustomEditor(typeof(CubicBezierDemo))]
public class CubicBezierDemoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Play Tween"))
        {
            (target as CubicBezierDemo).PlayTween(true);
        }
    }
}

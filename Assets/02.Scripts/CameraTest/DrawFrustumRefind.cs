using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class DrawFrustumRefind : MonoBehaviour
{


    private Camera Cam = null;
    public bool ShowCamGizmo = true;


    private void Awake()
    {
        Cam = GetComponent<Camera>();

    }


    void OnDrawGizmos()
    {
        // 기즈모를 보여줄 것인가!
        if (!ShowCamGizmo) return;


        // Game 탭의 크기(면적)을 구한다.
        Vector2 v = DrawFrustumRefind.GetGameViewSize();

        float GameAspect = v.x / v.y;  // 탭의 종횡비를 계산
        float FinalAspect = GameAspect / Cam.aspect;  // 카메라 종횡비로 나눈다.

        Matrix4x4 LocalToWorld = transform.localToWorldMatrix;

        //카메라 기즈모를 그리기 위한 스케일 행렬을 만든다.
        Matrix4x4 ScaleMatrix = Matrix4x4.Scale(
                        new Vector3(Cam.aspect * (Cam.rect.width / Cam.rect.height),
                        FinalAspect, 1));

        Gizmos.matrix = LocalToWorld * ScaleMatrix;

        // 카메라 프러스트럼을 그린다.
        Gizmos.DrawFrustum(transform.position,
                            Cam.fieldOfView, Cam.nearClipPlane,
                            Cam.farClipPlane, FinalAspect);
        Gizmos.matrix = Matrix4x4.identity;  //기즈모 행렬을 초기화한다.

    }


    //Game탭의 면적을 구하기 위한 함수.
    public static Vector2 GetGameViewSize()
    {
        System.Type T = System.Type.GetType("UnityEditor.GameView,UnityEditor");
        System.Reflection.MethodInfo GetSizeOfMainGameView
            = T.GetMethod("GetSizeOfMainGameView",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Static);

        return (Vector2)GetSizeOfMainGameView.Invoke(null, null);

    }
}
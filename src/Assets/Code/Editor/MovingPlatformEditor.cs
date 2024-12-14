using Assets.Code.Gameplay.Logic;
using UnityEditor;
using UnityEngine;

namespace Assets.Code.Editor
{
    [CustomEditor(typeof(MovingPlatform))]
    public class MovingPlatformEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Selected)]
        private static void RenderCustomGizmo(IMoving platform, GizmoType gizmo)
        {
            if (platform == null) return;

            (Transform PointA, Transform PointB) = platform.GetPoints();

            if (PointA == null || PointB == null) return;

            Handles.color = Color.red;
            Handles.DrawLine(PointA.position, PointB.position);

            Handles.SphereHandleCap(0, PointA.position, Quaternion.identity, 0.2f, EventType.Repaint);
            Handles.SphereHandleCap(0, PointB.position, Quaternion.identity, 0.2f, EventType.Repaint);

            Handles.Label(PointA.position, "Point A", EditorStyles.boldLabel);
            Handles.Label(PointB.position, "Point B", EditorStyles.boldLabel);
        }
    }
}
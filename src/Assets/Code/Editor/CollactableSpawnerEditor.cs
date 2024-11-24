using UnityEngine;
using UnityEditor;
using Assets.Code.Extensions;
using Assets.Code.Gameplay.Logic;
using System;

namespace Assets.Code.Editor
{
    [CustomEditor(typeof(CollectableSpawner))]
    public class CollactableSpawnerEditor : UnityEditor.Editor
    {
        private const float Thickeness = 3;

        [DrawGizmo(GizmoType.Active | GizmoType.Selected | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(CollectableSpawner spawner, GizmoType gizmoType)
        {
            Vector3 position = spawner.transform.position;

            var (Min, Max) = spawner.GetRandomDeltaXRange();

            Handles.DrawLine(position.AddX(Min), position.AddX(Max), Thickeness);
        }
    }
}
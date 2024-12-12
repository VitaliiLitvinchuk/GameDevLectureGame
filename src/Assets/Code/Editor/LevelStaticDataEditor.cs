using Assets.Code.Gameplay.Markers;
using Assets.Code.StaticData;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Assets.Code.Editor
{
    [CustomEditor(typeof(LevelData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        private void OnEnable()
        {
            CollectData();
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginDisabledGroup(true);
            base.OnInspectorGUI();
            EditorGUI.EndDisabledGroup();
        }

        private void CollectData()
        {
            LevelData levelData = (LevelData)target;

            levelData.LevelName = SceneManager.GetActiveScene().name;
            levelData.PlayerSpawnPoint = FindObjectOfType<PlayerSpawnPoint>().transform.position;

            EditorUtility.SetDirty(target);
        }
    }
}
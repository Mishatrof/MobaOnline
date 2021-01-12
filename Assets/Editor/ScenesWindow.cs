
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

public class ScenesWindow : EditorWindow
{
    private Vector2 _scrollPos;

    [MenuItem("Window/Scenes")]
    public static void ShowWindow()
    {
        var Window = GetWindow<ScenesWindow>("Scenes");
        Window.minSize = new Vector2(0f, 0f);
    }

    private void OnGUI()
    {
        _scrollPos = GUILayout.BeginScrollView(_scrollPos, GUILayout.ExpandWidth(true));

        foreach (var editorBuildSettingsScene in EditorBuildSettings.scenes)
        {
            var splitedPath = editorBuildSettingsScene.path.Split('/');
            var sceneName = splitedPath[splitedPath.Length - 1];
            sceneName = sceneName.Remove(sceneName.Length - 6);
            
            if(GUILayout.Button(sceneName))
            {
                var currentScene = SceneManager.GetActiveScene();
                if (currentScene.isDirty)
                {
                    EditorSceneManager.SaveScene(currentScene);
                }

                EditorSceneManager.OpenScene(editorBuildSettingsScene.path);
            }
        }
        GUILayout.EndScrollView();

    }
}

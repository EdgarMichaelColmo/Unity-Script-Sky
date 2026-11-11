using UnityEditor;
using UnityEngine;


[Tooltip("Sky is a custom personal script by Edgar Michael Colmo")]
public class SkyEditor
{
    public class BuildNumberMenu
    {
        [MenuItem("File/[SKY] Increment Build Numbers")]
        public static void IncrementBuildNumbers()
        {
            // 1. Increment iOS Build Number
            if (int.TryParse(PlayerSettings.iOS.buildNumber, out int currentiOSBuild))
            {
                currentiOSBuild++;
                PlayerSettings.iOS.buildNumber = currentiOSBuild.ToString();
                Debug.Log($"[Build Menu] iOS Build Number incremented to: {currentiOSBuild}");
            }
            else
            {
                PlayerSettings.iOS.buildNumber = "1";
                Debug.Log("[Build Menu] iOS Build Number initialized to: 1");
            }

            // 2. Increment Android Bundle Version Code
            PlayerSettings.Android.bundleVersionCode++;
            Debug.Log($"[Build Menu] Android Bundle Version Code incremented to: {PlayerSettings.Android.bundleVersionCode}");

            // Ensure settings are saved to disk
            AssetDatabase.SaveAssets();
            EditorUtility.DisplayDialog("Build Numbers Updated",
                $"Successfully incremented:\n• iOS Build: {PlayerSettings.iOS.buildNumber}\n• Android Version Code: {PlayerSettings.Android.bundleVersionCode}",
                "OK");
        }
    }
}

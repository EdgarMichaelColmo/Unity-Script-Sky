using UnityEditor;
using UnityEngine;


[Tooltip("Sky is a custom personal script by Edgar Michael Colmo")]
public class SkyEditor
{
    public class BuildNumberMenu
    {
        [MenuItem("File/[SKY] Increment Build Numbers")]
        static void IncrementBuildNumbers()
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

        [MenuItem("File/[SKY] Increment Version")]
        private static void IncrementPatchVersion()
        {
            string currentVersion = PlayerSettings.bundleVersion;
            string[] parts = currentVersion.Split('.');

            if (parts.Length >= 3 && int.TryParse(parts[parts.Length - 1], out int patch))
            {
                patch++;
                string originalPatchString = parts[parts.Length - 1];
                parts[parts.Length - 1] = patch.ToString().PadLeft(originalPatchString.Length, '0');

                string newVersion = string.Join(".", parts);
                PlayerSettings.bundleVersion = newVersion;

                Debug.Log($"[Build Menu] Bundle Version patch incremented to: {newVersion}");
                AssetDatabase.SaveAssets();

                EditorUtility.DisplayDialog("Patch Version Updated",
                    $"Successfully updated bundle version to: {newVersion}",
                    "OK");
            }
            else
            {
                Debug.LogWarning($"[Build Menu] Could not parse patch version from '{currentVersion}'. Version left unchanged.");
                EditorUtility.DisplayDialog("Update Failed",
                    $"Could not parse patch version from '{currentVersion}'. Ensure format is Major.Minor.Patch (e.g. 0.1.05).",
                    "OK");
            }
        }
    }
}

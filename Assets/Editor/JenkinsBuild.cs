using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

using System.Collections.Generic;

public class JenkinsBuild : Editor
{
    [MenuItem("Blueberry Jam/BuildWindows")]
    public static void BuildWindows()
    {
        BuildPlayerOptions build_player_options = new BuildPlayerOptions();
        List<EditorBuildSettingsScene> scenes = new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes);

        string[] scenes_from_settings = new string[scenes.Count];
        for (int i = 0; i < scenes.Count; i++)
        {
            scenes_from_settings[i] = scenes[i].path;
            //Debug.Log("scene: " + scenes[i].path);
        }

        build_player_options.scenes = scenes_from_settings;
        build_player_options.locationPathName = "JenkinsBuild/Blueberry-Jam-Core.exe";
        build_player_options.target = BuildTarget.StandaloneWindows64;

        build_player_options.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(build_player_options);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed");
        }
    }
}

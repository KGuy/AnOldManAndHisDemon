#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

[InitializeOnLoad]
public class VersioningSystem
{
    static string[] versionString;

    static int MajorVersion;
    static int MinorVersion;
    static int Build;
    static string GREEK;

    static List<string> allowedGreek = new List<string> { "alpha", "beta", "sigma", "Halloween" };

    [PostProcessBuild(1)]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
        ReadVersionString();

        bool shouldIncrementBuild = EditorUtility.DisplayDialog(PlayerSettings.companyName + " Útgávu Skipan", "Skall útgávu talið økjast? Núverandi útgávan er: " + PlayerSettings.bundleVersion, "Ja", "Nei");

        Debug.Log("Build v" + PlayerSettings.bundleVersion);

        if (shouldIncrementBuild)
        {
            IncreaseBuild();
        }
    }

    static void MangleWarning()
    {
        throw new Exception("[File -> Build Settings -> Player Settings -> Player -> Version] Útgávu strongurin er skaddur! Syrg fyri at hann fylgir formatinum \"#.#.#.GREEK\"");
    }

    static void ReadVersionString()
    {
        versionString = PlayerSettings.bundleVersion.Split('.');

        if (versionString.Length != 4)
        {
            MangleWarning();
        }

        if (!int.TryParse(versionString[0], out MajorVersion))
        {
            MangleWarning();
        }

        if (!int.TryParse(versionString[1], out MinorVersion))
        {
            MangleWarning();
        }

        if (!int.TryParse(versionString[2], out Build))
        {
            MangleWarning();
        }

        if (!allowedGreek.Contains(versionString[3], StringComparer.OrdinalIgnoreCase))
        {
            MangleWarning();
        }
        else
        {
            GREEK = versionString[3].ToLower();
        }
    }

    static void SetVersionString(int major, int minor, int build)
    {
        if (versionString.Length == 4)
        {
            PlayerSettings.bundleVersion = major.ToString("0") + "." +
                                            minor.ToString("0") + "." +
                                            build.ToString("0") + "." +
                                            GREEK.ToLower();
        }
        else
        {
            MangleWarning();
        }
    }

    static void IncrementVersion(int majorIncr, int minorIncr, int buildIncr)
    {
        ReadVersionString();

        MajorVersion += majorIncr;
        MinorVersion += minorIncr;
        Build += buildIncr;

        SetVersionString(MajorVersion, MinorVersion, Build);
    }

    [MenuItem("Bumbu Toymið/Útgávu Skipan/Øk smærra útgávutalið")]
    private static void IncreaseMinor()
    {
        ReadVersionString();

        IncrementVersion(0, 1, 0);
    }

    [MenuItem("Bumbu Toymið/Útgávu Skipan/Øk stórra útgávutalið")]
    private static void IncreaseMajor()
    {
        bool shouldIncrementMajorVersion = EditorUtility.DisplayDialog(PlayerSettings.companyName + " Øk Stórra-útgávutalið", "Ert tú vísur í at stórra útgávutalið skal økjast? Smærra útgávutalið og byggitalið nullstillast.", "Ja", "Nei");

        if(shouldIncrementMajorVersion)
        {
            ReadVersionString();

            MajorVersion += 1;
            SetVersionString(MajorVersion, 0, 0);
        }
    }

    private static void IncreaseBuild()
    {
        IncrementVersion(0, 0, 1);
        Debug.Log("Eydnaðist! Byggitalið er nú " + Build.ToString());
    }
}

#endif
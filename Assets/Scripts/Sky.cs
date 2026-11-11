using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[Tooltip("Sky is a custom personal script by Edgar Michael Colmo")]
public class Sky : MonoBehaviour
{
    private static Dictionary<string, float> isPausedTime = new();

    public static void isPausedInit(string methodName)
    {
        isPausedTime.Remove(methodName);
    }

    [Tooltip("Used in while(true), stops While Loop after seconds (error checking)")]
    // SAMPLE CODE:
    // string uniqueID = ""; Sky.isPausedInit(uniqueID); while (Sky.isPaused(cond, 30f, uniqueID)) {
    //        yield return null; }
    public static bool isPaused(bool condition, float errorCatchInSeconds, string methodName)
    {
        if (!isPausedTime.ContainsKey(methodName))
            isPausedTime.Add(methodName, Time.time + errorCatchInSeconds);

        //print("error checking - Time: "  + Time.time + "/errorCatch: "  + isPausedTime[methodName] + " = " +  (Time.time < isPausedTime[methodName]));

        return condition && Time.time < isPausedTime[methodName];
    }

    // coroutineMoving = Sky.StartCoroutine_(this, coroutineMoving, cTweenToFlashcard());
    public static Coroutine StartCoroutine_(MonoBehaviour monoBehaviour_, Coroutine coroutine_, IEnumerator enumerator_)
    {
        if (coroutine_ == null)
            return monoBehaviour_.StartCoroutine(enumerator_);
        else return coroutine_;
    }


    // Sky.isEquals_(compare_here, new string[] { "OnSettingsClick", "OnLearnMore" })
    public static bool isEquals_(string CompareThis, string[] CompareToThese)
    {
        return CompareToThese.Where(x => x.Equals(CompareThis)).Count() > 0;
    }
    // Sky.doesContains_(compare_here, new string[] { "A", "B" })
    public static bool doesContains_(string CompareThis, string[] CompareToThese)
    {
        return CompareToThese.Where(x => CompareThis.Contains(x)).Count() > 0;
    }

}

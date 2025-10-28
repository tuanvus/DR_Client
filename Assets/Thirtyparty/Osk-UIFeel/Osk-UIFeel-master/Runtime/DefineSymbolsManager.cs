#if UNITY_EDITOR
using System.Linq;
using UnityEditor;

public class DefineSymbolsManager
{

    [MenuItem("OSK-Framework/Add Symbol Module ")]

    public static void AddModule()
    {
        AddDefineSymbol("DOTWEEN");
        AddDefineSymbol("ODIN_INSPECTOR");
        AddDefineSymbol("ODIN_INSPECTOR_3");
        AddDefineSymbol("ODIN_INSPECTOR_3_1");
    }
    
    /// <summary>
    /// Adds a scripting define symbol to the current build target group.
    /// </summary>
    /// <param name="symbol">The define symbol to add.</param>
    public static void AddDefineSymbol(string symbol)
    {
        BuildTargetGroup targetGroup = EditorUserBuildSettings.selectedBuildTargetGroup;

        if (targetGroup == BuildTargetGroup.Unknown)
        {
            UnityEngine.Debug.LogError("Unknown Build Target Group. Cannot modify define symbols.");
            return;
        }

        string currentSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(targetGroup);
        if (!currentSymbols.Contains(symbol))
        {
            currentSymbols = string.IsNullOrEmpty(currentSymbols) ? symbol : $"{currentSymbols};{symbol}";
            PlayerSettings.SetScriptingDefineSymbolsForGroup(targetGroup, currentSymbols);
            UnityEngine.Debug.Log($"Added define symbol: {symbol}");
        }
        else
        {
            UnityEngine.Debug.Log($"Define symbol '{symbol}' already exists.");
        }
    }

    /// <summary>
    /// Removes a scripting define symbol from the current build target group.
    /// </summary>
    /// <param name="symbol">The define symbol to remove.</param>
    public static void RemoveDefineSymbol(string symbol)
    {
        BuildTargetGroup targetGroup = EditorUserBuildSettings.selectedBuildTargetGroup;

        if (targetGroup == BuildTargetGroup.Unknown)
        {
            UnityEngine.Debug.LogError("Unknown Build Target Group. Cannot modify define symbols.");
            return;
        }

        string currentSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(targetGroup);
        if (currentSymbols.Contains(symbol))
        {
            string updatedSymbols = string.Join(";", currentSymbols.Split(';').Where(s => s != symbol));
            PlayerSettings.SetScriptingDefineSymbolsForGroup(targetGroup, updatedSymbols);
            UnityEngine.Debug.Log($"Removed define symbol: {symbol}");
        }
        else
        {
            UnityEngine.Debug.Log($"Define symbol '{symbol}' does not exist.");
        }
    }
}
#endif
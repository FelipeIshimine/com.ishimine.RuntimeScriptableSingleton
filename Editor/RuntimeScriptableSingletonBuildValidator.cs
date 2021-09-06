using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class RuntimeScriptableSingletonBuildValidator  : IPreprocessBuildWithReport
{
    public int callbackOrder => 0;

    public void OnPreprocessBuild(BuildReport report)
    {
        try
        {
            RuntimeScriptableSingletonInitializer.Clear();
            RuntimeScriptableSingletonInitializer.Initialize();
        }
        catch (System.Exception e) //Relanzamos el error
        {
            throw new UnityEditor.Build.BuildFailedException(e);
        }
    }
    
}
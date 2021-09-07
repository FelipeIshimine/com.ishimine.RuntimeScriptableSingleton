using UnityEditor.Build;
using UnityEditor.Build.Reporting;

public class RuntimeScriptableSingletonBuildValidator  : IPreprocessBuildWithReport
{
    public int callbackOrder => 0;

    public void OnPreprocessBuild(BuildReport report)
    {
        try
        {
            RuntimeScriptableSingletonInitializer.Clear();
            RuntimeScriptableSingletonInitializer.Initialize();
            RuntimeScriptableSingletonInitializer.PreBuildProcess();
        }
        catch (System.Exception e) //Relanzamos el error
        {
            throw new UnityEditor.Build.BuildFailedException(e);
        }
    }
    
}
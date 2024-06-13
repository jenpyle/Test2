#region Using directives

using FTOptix.NetLogic;

#endregion

public class DesignTime : BaseNetLogic
{
    [ExportMethod]
    public void CleanAndRun()
    {
        Start start = new();
        start.CleanAndRun();
    }

    [ExportMethod]
    public void CleanOnly()
    {
        Start start = new();
        start.CleanAll();
    }
}
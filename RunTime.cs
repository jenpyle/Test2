#region Using directives

using FTOptix.NetLogic;

#endregion

public class RunTime : BaseNetLogic
{
    public override void Start()
    {
        Start start = new();
        start.CleanAndRun();
    }

    public override void Stop()
    {
        Start start = new();
        start.CleanAll();
    }
}
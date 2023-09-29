using Peponi.SourceGenerators;

namespace asdasfasfasf;

[NotifyInterface]
public partial class rwqa325rar
{
    [Property(NotifyType = NotifyType.None)]
    //[RaiseCanExecuteChanged(nameof(TestFuncCommand))]
    [RaisePropertyChanged(nameof(Boolean))]
    private string _string = string.Empty;

    [Property]
    [MethodCall(nameof(CanTestFunc), Section = PropertyMethodSection.Setter, Args = "1")]
    [MethodCall(nameof(CanTestFunc), Section = PropertyMethodSection.Getter, Args = "0")]
    private bool _boolean = false;

    [Command(CanExecute = nameof(CanTestFunc))]
    private void TestFunc(int a)
    {
        return;
    }

    private bool CanTestFunc(int a)
    {
        return false;
    }
}
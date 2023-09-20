using Peponi.CodeGenerators;

namespace asdasfasfasf;

[NotifyInterface]
public partial class rwqa325rar
{
    [Property(NotifyType = NotifyType.None)]
    [RaiseCanExecuteChanged(nameof(TestFuncCommand))]
    [RaisePropertyChanged(nameof(Boolean))]
    private string _string = string.Empty;

    [Property]
    private bool _boolean = false;

    [Command(CanExecute = nameof(CanTestFunc))]
    private void TestFunc()
    {
        return;
    }

    private bool CanTestFunc()
    {
        return false;
    }
}
using System.Windows.Input;

namespace Peponi.SourceGenerators.Commands;

public interface ICommandBase : ICommand
{
    void RaiseCanExecuteChanged();
}

public interface ICommandBase<in T> : ICommandBase
{
    bool CanExecute(T parameter);

    void Execute(T parameter);
}
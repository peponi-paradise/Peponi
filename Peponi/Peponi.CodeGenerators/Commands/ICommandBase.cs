using System.Windows.Input;

namespace Peponi.CodeGenerators.Commands;

public interface ICommandBase : ICommand
{
    void RaiseCanExecuteChanged();
}

public interface ICommandBase<in T> : ICommandBase
{
    bool CanExecute(T parameter);

    void Execute(T parameter);
}

public interface ICommandBase<in T, in V> : ICommandBase
{
    bool CanExecute(V parameter);

    void Execute(T parameter);
}
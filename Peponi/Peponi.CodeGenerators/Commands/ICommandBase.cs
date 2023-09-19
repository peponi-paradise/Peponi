using System.Windows.Input;

namespace Peponi.CodeGenerators.Commands;

public interface ICommandBase<T> : ICommand
{
    void RaiseCanExecuteChanged();

    bool CanExecute(T? parameter);

    void Execute(T? parameter);
}
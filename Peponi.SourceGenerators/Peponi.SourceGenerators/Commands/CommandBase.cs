namespace Peponi.SourceGenerators.Commands;

public sealed class CommandBase : ICommandBase
{
    public event EventHandler? CanExecuteChanged;

    private readonly Action _execute;
    private readonly Func<bool>? _canExecute;

    public CommandBase(Action execute, Func<bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object parameter)
    {
        return _canExecute?.Invoke() != false;
    }

    public void Execute(object parameter)
    {
        _execute();
    }

    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}

public sealed class CommandBase<T> : ICommandBase<T>
{
    public event EventHandler? CanExecuteChanged;

    private readonly Action<T> _execute;
    private readonly Predicate<T>? _canExecute;

    public CommandBase(Action<T> execute, Predicate<T>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(T parameter)
    {
        return _canExecute?.Invoke(parameter) != false;
    }

    public void Execute(T parameter)
    {
        _execute(parameter);
    }

    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool CanExecute(object parameter)
    {
        // From MVVM toolkit
        if (parameter is null && default(T) is not null)
        {
            return false;
        }

        T arg = (T)parameter!;

        return CanExecute(arg);
    }

    public void Execute(object parameter)
    {
        T arg = (T)parameter!;

        Execute(arg);
    }
}
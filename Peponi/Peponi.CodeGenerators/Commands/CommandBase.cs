namespace Peponi.CodeGenerators.Commands;

public sealed class CommandBase : ICommandBase
{
    public event EventHandler? CanExecuteChanged;

    private readonly Action<object> _execute;
    private readonly Func<object, bool>? _canExecute;

    public CommandBase(Action<object> execute, Func<object, bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object parameter)
    {
        return _canExecute?.Invoke(parameter) != false;
    }

    public void Execute(object parameter)
    {
        _execute(parameter);
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
    private readonly Func<T, bool>? _canExecute;

    public CommandBase(Action<T> execute, Func<T, bool>? canExecute = null)
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
        T? param = default!;
        if (parameter is T arg) param = arg;
        return CanExecute(param);
    }

    public void Execute(object parameter)
    {
        T? param = default!;
        if (parameter is T arg) param = arg;
        Execute(param);
    }
}
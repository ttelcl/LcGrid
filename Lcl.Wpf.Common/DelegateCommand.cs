/*
 * (c) 2019   / TTELCL
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Input;

namespace Lcl.Wpf.Common
{
  /// <summary>
  /// Standard DelegateCommand implementation
  /// </summary>
  public class DelegateCommand: ICommand
  {
    private readonly Predicate<object?>? _canExecute;
    private readonly Action<object?> _execute;

    /// <summary>
    /// Create a DelegateCommand whose executability
    /// is variable
    /// </summary>
    /// <param name="execute">
    /// The Action delegate that is called to execute the command
    /// </param>
    /// <param name="canExecute">
    /// (optional) The Predicate delegate that is called to check if the command
    /// can be called. WPF uses the result to enable or disable the UI elemant bound
    /// to this command.
    /// When omitted, the command is always considered enabled for calling.
    /// </param>
    public DelegateCommand(
      Action<object?> execute,
      Predicate<object?>? canExecute = null)
    {
      _execute = execute;
      _canExecute = canExecute;
    }

    /// <summary>
    /// Test if the commend can be executed
    /// </summary>
    public bool CanExecute(object? parameter)
    {
      return _canExecute == null || _canExecute(parameter);
    }

    /// <summary>
    /// Execute the commend
    /// </summary>
    public void Execute(object? parameter)
    {
      _execute(parameter);
    }

    /// <summary>
    /// Attaches the event to CommandManager.RequerySuggested
    /// </summary>
    public event EventHandler? CanExecuteChanged {
      add {
        CommandManager.RequerySuggested += value;
      }
      remove {
        CommandManager.RequerySuggested -= value;
      }
    }

  }
}

/*
 * (c) 2022  ttelcl / ttelcl
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lcl.GridModel
{
  /// <summary>
  /// A cell that just carries a text string as value
  /// </summary>
  public class TextCell: Cell
  {
    /// <summary>
    /// Create a new TextCell
    /// </summary>
    public TextCell(CellRow row, CellColumn column, string initialValue="")
      : base(row, column)
    {
      Text = initialValue;
    }

    /// <summary>
    /// Get or set the text value of this cell.
    /// (changes in this property trigger a PropertyChanged event)
    /// </summary>
    public string Text {
      get => _text;
      set {
        if(SetInstanceProperty(ref _text, value ?? String.Empty))
        {
        }
      }
    }
    private string _text = String.Empty;

  }
}
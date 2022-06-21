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
  /// A Cell subclass that does not carry any value (it always has a 
  /// 'null' value, or in other words: it is 'empty')
  /// </summary>
  public sealed class NullCell: Cell
  {
    /// <summary>
    /// Create a new NullCell
    /// </summary>
    public NullCell(CellRow row, CellColumn column)
      : base(row, column)
    {
    }

  }
}

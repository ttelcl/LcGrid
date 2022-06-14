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
  /// Position of a Zone (ColumnZone or RowZone) inside its grid
  /// </summary>
  public enum ZonePosition
  {
    /// <summary>
    /// The zone is frozen to the left (ColumnZone) or top (RowZone)
    /// </summary>
    First = -1,

    /// <summary>
    /// The zone is in the middle and scrollable horizontally (ColumnZone)
    /// or vertically (RowZone)
    /// </summary>
    Middle = 0,

    /// <summary>
    /// The zone is frozen to the right (ColumnZone) or bottom (RowZone)
    /// </summary>
    Last = 1,
  }
}

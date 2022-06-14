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
  /// A collection of adjacent columns in an LcGrid with a shared scrolling
  /// behaviour (frozen or horizontally scrollable)
  /// </summary>
  public class ColumnZone: ZoneBase
  {
    /// <summary>
    /// Create a new ColumnZone
    /// </summary>
    internal ColumnZone(
      LcGrid grid,
      ZonePosition position)
      : base(grid, position)
    {
    }

  }
}

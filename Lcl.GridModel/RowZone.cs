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
  /// A collection of adjacent rows in an LcGrid with a shared scrolling
  /// behaviour (frozen or vertically scrollable)
  /// </summary>
  public class RowZone: ZoneBase
  {
    /// <summary>
    /// Create a new RowZone
    /// </summary>
    public RowZone(
      LcGrid grid,
      ZonePosition position)
      : base(grid, position)
    {
    }

  }
}

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
  /// Common base class of ColumnZone and RowZone
  /// </summary>
  public abstract class ZoneBase: IHasGrid
  {
    /// <summary>
    /// Create a new Zone
    /// </summary>
    protected ZoneBase(
      LcGrid grid,
      ZonePosition position)
    {
      Grid = grid;
      Position = position;
    }

    /// <summary>
    /// The LcGrid this zone is part of
    /// </summary>
    public LcGrid Grid { get; }

    /// <summary>
    /// The relative position of this zone
    /// </summary>
    public ZonePosition Position { get; }

    /// <summary>
    /// True if this zone is scrollable
    /// </summary>
    public bool IsScrollable { get => Position == ZonePosition.Middle; }

  }
}

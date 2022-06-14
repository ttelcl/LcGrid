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
  /// The central part of a grid data model
  /// </summary>
  public class LcGrid
  {
    /// <summary>
    /// Create a new LcGrid
    /// </summary>
    public LcGrid()
    {
      TopZone = new RowZone(this, ZonePosition.First);
      MidRowZone = new RowZone(this, ZonePosition.Middle);
      BottomZone = new RowZone(this, ZonePosition.Last);
      RowZones = new List<RowZone> { TopZone, MidRowZone, BottomZone }.AsReadOnly();

      LeftZone = new ColumnZone(this, ZonePosition.First);
      MidColumnZone = new ColumnZone(this, ZonePosition.Middle);
      RightZone = new ColumnZone(this, ZonePosition.Last);
      ColumnZones = new List<ColumnZone> { LeftZone, MidColumnZone, RightZone }.AsReadOnly();
    }

    /// <summary>
    /// The top RowZone (typically used for column headers)
    /// </summary>
    public RowZone TopZone { get; }

    /// <summary>
    /// The middle RowZone (displaying actual content rows)
    /// </summary>
    public RowZone MidRowZone { get; }

    /// <summary>
    /// The bottom RowZone (not commonly used, but useful if you want to display
    /// column totals or the like)
    /// </summary>
    public RowZone BottomZone { get; }

    /// <summary>
    /// (TopZone, MidRowZone, BottomZone) as an immutable indexable list
    /// </summary>
    public IReadOnlyList<RowZone> RowZones { get; }

    /// <summary>
    /// The left ColumnZone (typically used for row headers, if used at all)
    /// </summary>
    public ColumnZone LeftZone { get; }

    /// <summary>
    /// The middle ColumnZone (for the main content cells)
    /// </summary>
    public ColumnZone MidColumnZone { get; }

    /// <summary>
    /// The right ColumnZone (not commonly used, but suitable for things like
    /// row totals etc.)
    /// </summary>
    public ColumnZone RightZone { get; }

    /// <summary>
    /// (LeftZone, MidColumnZone, RightZone) as an immutable indexable list
    /// </summary>
    public IReadOnlyList<ColumnZone> ColumnZones { get; }

  }

}

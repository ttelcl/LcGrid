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
  /// The intersection of a single RowZone and a single ColumnZone,
  /// a logical container for the grid of all the cells in that intersection
  /// </summary>
  public class ZonePane: IHasGrid
  {
    /// <summary>
    /// Create a new ZonePane
    /// </summary>
    public ZonePane(
      RowZone rowZone,
      ColumnZone columnZone)
    {
      if(!Object.ReferenceEquals(rowZone.Grid, columnZone.Grid))
      {
        throw new InvalidOperationException(
          "Expecting the row and column to be part of the same grid");
      }
      RowZone = rowZone;
      ColumnZone = columnZone;
      Grid = RowZone.Grid;
    }

    /// <summary>
    /// The RowZone for this Pane
    /// </summary>
    public RowZone RowZone { get; }

    /// <summary>
    /// The column zone for this Pane
    /// </summary>
    public ColumnZone ColumnZone { get; }

    /// <summary>
    /// The grid this Pane is part of
    /// </summary>
    public LcGrid Grid { get; }
  }
}

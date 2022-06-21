/*
 * (c) 2022  ttelcl / ttelcl
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lcl.GridModel.MvvmSupport;

namespace Lcl.GridModel
{
  /// <summary>
  /// A cell, appearing on the crossing of a CellRow and a CellColumn.
  /// Cells are stored in their rows, but normally created by their columns.
  /// </summary>
  public abstract class Cell: ViewModelBase, ICell, IHasGrid
  {
    /// <summary>
    /// Create a new Cell
    /// </summary>
    public Cell(
      CellRow row,
      CellColumn column)
    {
      Row = row;
      Column = column;
      if(!Object.ReferenceEquals(Row.Grid, Column.Grid))
      {
        throw new InvalidOperationException(
          "Attempt to create a cell for a row and column that are part of different grids");
      }
    }

    /// <summary>
    /// The row this cell belongs to
    /// </summary>
    public CellRow Row { get; }

    /// <summary>
    /// The column this cell belongs to
    /// </summary>
    public CellColumn Column { get; }
    
    /// <summary>
    /// The grid associated with this cell
    /// </summary>
    public LcGrid Grid => Row.Grid;
  }
}

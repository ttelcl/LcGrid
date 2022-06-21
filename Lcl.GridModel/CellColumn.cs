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
  /// A single column inside a ColumnZone, logically stretching across all three RowZones.
  /// Unlike CellRows, CellColumns do not have direct access to Cells, but instead play
  /// an index-like role to retrieve a Cell from a row.
  /// CellColumns normally are define a "type" and behaviour for cells belonging to that column
  /// </summary>
  public abstract class CellColumn: ViewModelBase, IHasGrid
  {
    /// <summary>
    /// Create a new CellColumn.
    /// While this constructor associates the new column with a Zone, it does not insert
    /// it in it yet; that is done by LcGrid.NewColumn()
    /// </summary>
    protected CellColumn(
      ColumnZone zone,
      string id)
    {
      Zone = zone;
      Id = id;
    }

    /// <summary>
    /// The ColumnZone this CellColumn is part of
    /// </summary>
    public ColumnZone Zone { get; }

    /// <summary>
    /// Implements IHasGrid
    /// </summary>
    public LcGrid Grid => Zone.Grid;

    /// <summary>
    /// The identifier used to identify the column in the grid. It must be unique
    /// across all columns in all zones of the grid. Usually this can be equal
    /// to the column name.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Create a new cell to appear on the intersection of this column and the given row.
    /// Note that the returned object is likely polymorphic and cannot be typed stronger
    /// than "Cell". For example, the returned Cell for a header row is probably
    /// a different concrete type than the cell for a data row.
    /// </summary>
    public abstract Cell CreateCell(CellRow row);

    /// <summary>
    /// Get the cell at the intersection of this column and the given row.
    /// This is a redirection to the indexer of the row.
    /// </summary>
    /// <param name="row">
    /// The row for which to find this column's cell
    /// </param>
    /// <param name="create">
    /// (default false). When true: if the cell is missing, create it using this
    /// column's CreateCell() method.
    /// </param>
    /// <returns>
    /// The cell that was found or created, or null if the cell was not yet initialized
    /// and 'create' was false.
    /// </returns>
    public Cell? this[CellRow row, bool create = false] {
      get => row[this, create];
    }
  }
}

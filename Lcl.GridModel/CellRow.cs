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
  /// A single row in a RowZone, logically stretching across all ColumnZones.
  /// Instances of this class contain the cell instances for the cells in the row
  /// (unlike CellColumns, which are merely referenced by cells)
  /// </summary>
  public class CellRow: ViewModelBase, IHasGrid
  {
    private Dictionary<string, Cell> _cells;

    /// <summary>
    /// Create a new CellRow
    /// While this constructor associates the new rows with a Zone, it does not insert
    /// it in it yet; that is done by LcGrid.NewRow()
    /// </summary>
    protected internal CellRow(
      RowZone zone)
    {
      Zone = zone;
      _cells = new Dictionary<string, Cell>();
    }

    /// <summary>
    /// The RowZone this row is part of
    /// </summary>
    public RowZone Zone { get; }

    /// <summary>
    /// Implements IHasGrid
    /// </summary>
    public LcGrid Grid => Zone.Grid;

    /// <summary>
    /// Look up the cell in this row for the given column. This may return null, when
    /// no cell has been assigned yet.
    /// </summary>
    /// <param name="column">
    /// The column to find the cell for
    /// </param>
    /// <param name="create">
    /// (default false). When true and a missing cell is requested, it is created
    /// (via the column's CreateCell method)
    /// </param>
    /// <returns>
    /// The cell, if found, or null if not found
    /// </returns>
    public Cell? this[CellColumn column, bool create = false] {
      get {
        if(_cells.TryGetValue(column.Id, out Cell? cell))
        {
          return cell;
        }
        else
        {
          if(create)
          {
            var newcell = column.CreateCell(this);
            _cells[column.Id] = newcell;
            return newcell;
          }
          else
          {
            return null;
          }
        }
      }
      internal set {
        if(value == null)
        {
          _cells.Remove(column.Id);
        }
        else
        {
          _cells[column.Id] = value;
        }
      }
    }

  }
}

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
      LeftZone = new ColumnZone(this, ZonePosition.First);
      MidColumnZone = new ColumnZone(this, ZonePosition.Middle);
      RightZone = new ColumnZone(this, ZonePosition.Last);
      ColumnZones = new List<ColumnZone> { LeftZone, MidColumnZone, RightZone }.AsReadOnly();

      TopZone = new RowZone(this, ZonePosition.First);
      MidRowZone = new RowZone(this, ZonePosition.Middle);
      BottomZone = new RowZone(this, ZonePosition.Last);
      RowZones = new List<RowZone> { TopZone, MidRowZone, BottomZone }.AsReadOnly();
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

    /// <summary>
    /// Access a RowZone by its position code
    /// </summary>
    public RowZone GetRowZone(ZonePosition rowPosition)
    {
      return rowPosition switch {
        ZonePosition.First => TopZone,
        ZonePosition.Middle => MidRowZone,
        ZonePosition.Last => BottomZone,
        _ => throw new ArgumentException("Unknown zone position code")
      };
    }

    /// <summary>
    /// Access a ColumnZone by its position code
    /// </summary>
    public ColumnZone GetColumnZone(ZonePosition rowPosition)
    {
      return rowPosition switch {
        ZonePosition.First => LeftZone,
        ZonePosition.Middle => MidColumnZone,
        ZonePosition.Last => RightZone,
        _ => throw new ArgumentException("Unknown zone position code")
      };
    }

    /// <summary>
    /// Create a new column and insert it at the start or end of its zone
    /// </summary>
    /// <param name="columnFactory">
    /// The function that creates the desired CellColumn subclass
    /// </param>
    /// <param name="zone">
    /// The zone position  identifying the zone to create the column in
    /// </param>
    /// <param name="atStart">
    /// When true: insert at the left end of the zone.
    /// When false: insert at the right end of the zone.
    /// </param>
    public CellColumn NewColumn(
      Func<ColumnZone, CellColumn> columnFactory, ZonePosition zone, bool atStart)
    {
      var column = columnFactory(GetColumnZone(zone));
      column.Zone.Insert(column, atStart);
      return column;
    }

    /// <summary>
    /// Create a new row and insert it at the start or end of its zone
    /// </summary>
    /// <param name="rowFactory">
    /// The function that creates the desired RowColumn or a subclass
    /// </param>
    /// <param name="zone">
    /// The zone position  identifying the zone to create the row in
    /// </param>
    /// <param name="atStart">
    /// When true: insert at the top end of the zone.
    /// When false: insert at the bottom end of the zone.
    /// </param>
    public CellRow NewRow(
      Func<RowZone, CellRow> rowFactory, ZonePosition zone, bool atStart)
    {
      var row = rowFactory(GetRowZone(zone));
      row.Zone.Insert(row, atStart);
      return row;
    }

    /// <summary>
    /// Enumerate all rows in all row zones.
    /// </summary>
    public IEnumerable<CellRow> AllRows()
    {
      return TopZone.Rows.Concat(MidRowZone.Rows).Concat(BottomZone.Rows);
    }

    /// <summary>
    /// Enumerate all columns in all column zones.
    /// </summary>
    public IEnumerable<CellColumn> AllColumns()
    {
      return LeftZone.Columns.Concat(MidColumnZone.Columns).Concat(RightZone.Columns);
    }
  }

}

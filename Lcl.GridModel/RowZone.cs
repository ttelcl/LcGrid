/*
 * (c) 2022  ttelcl / ttelcl
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    internal RowZone(
      LcGrid grid,
      ZonePosition position)
      : base(grid, position)
    {
      if(grid.ColumnZones == null || grid.ColumnZones.Count!=3)
      {
        throw new InvalidOperationException(
          "Invalid instantiation order: when creating an LcGrid's Row Zones, the Column Zones must already exist");
      }
      Rows = new ObservableCollection<CellRow>();
      LeftPane = new ZonePane(this, Grid.LeftZone);
      MidPane = new ZonePane(this, Grid.MidColumnZone);
      RightPane = new ZonePane(this, Grid.RightZone);
      Panes = new List<ZonePane> { LeftPane, MidPane, RightPane }.AsReadOnly();
    }

    /// <summary>
    /// The left pane of the row
    /// </summary>
    public ZonePane LeftPane { get; }

    /// <summary>
    /// The centre pane of the row
    /// </summary>
    public ZonePane MidPane { get; }

    /// <summary>
    /// The right pane of the row
    /// </summary>
    public ZonePane RightPane { get; }

    /// <summary>
    /// All three panes of the row (in the order Left, Mid, Right)
    /// </summary>
    public IReadOnlyList<ZonePane> Panes { get; }

    /// <summary>
    /// Lookup a pane in this row by its column position code
    /// </summary>
    /// <param name="columnPosition">
    /// The column postion code for the pane
    /// </param>
    /// <returns>
    /// The requested pane
    /// </returns>
    public ZonePane GetPane(ZonePosition columnPosition)
    {
      return columnPosition switch {
        ZonePosition.First => LeftPane,
        ZonePosition.Middle => MidPane,
        ZonePosition.Last => RightPane,
        _ => throw new ArgumentException("Unknown zone position code"),
      };
    }

    /// <summary>
    /// The rows in this zone
    /// </summary>
    public ObservableCollection<CellRow> Rows { get; }

    internal void Insert(CellRow row, bool atStart)
    {
      if(!Object.ReferenceEquals(row.Zone, this))
      {
        throw new InvalidOperationException(
          "Attempt to insert row in wrong zone");
      }
      if(atStart)
      {
        Rows.Insert(0, row);
      }
      else
      {
        Rows.Add(row);
      }
    }

  }
}

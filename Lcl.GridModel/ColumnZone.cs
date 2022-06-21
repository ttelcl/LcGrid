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
      Columns = new ObservableCollection<CellColumn>();
    }

    /// <summary>
    /// Access a pane in this column by its logical row position
    /// </summary>
    public ZonePane GetPane(ZonePosition rowPosition)
    {
      return Grid.GetRowZone(rowPosition).GetPane(Position);
    }

    /// <summary>
    /// The top pane in this zone column
    /// </summary>
    public ZonePane TopPane => GetPane(ZonePosition.First);

    /// <summary>
    /// The middle pane in this zone column
    /// </summary>
    public ZonePane MidPane => GetPane(ZonePosition.Middle);

    /// <summary>
    /// The bottom pane in this zone column
    /// </summary>
    public ZonePane BottomPane => GetPane(ZonePosition.Last);

    /// <summary>
    /// The collection of columns in this zone
    /// </summary>
    public ObservableCollection<CellColumn> Columns { get; }

    internal void Insert(CellColumn column, bool atStart)
    {
      if(!Object.ReferenceEquals(column.Zone, this))
      {
        throw new InvalidOperationException(
          "Attempt to insert column in wrong zone");
      }
      if(atStart)
      {
        Columns.Insert(0, column);
      }
      else
      {
        Columns.Add(column);
      }
    }
  }
}

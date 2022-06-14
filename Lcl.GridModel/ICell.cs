/*
 * (c) 2022  ttelcl / ttelcl
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lcl.GridModel
{
  /// <summary>
  /// Implemented by object associated with both a row and a column 
  /// </summary>
  public interface ICell: IHasGrid
  {
    /// <summary>
    /// The cell's column
    /// </summary>
    CellColumn Column { get; }

    /// <summary>
    /// The cell's row
    /// </summary>
    CellRow Row { get; }
  }
}


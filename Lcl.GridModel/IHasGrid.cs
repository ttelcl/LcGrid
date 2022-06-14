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
  /// Implemented by objects associated with an LcGrid instance
  /// </summary>
  public interface IHasGrid
  {
    /// <summary>
    /// The LcGrid instance associated with this object
    /// </summary>
    LcGrid Grid { get; }
  }
}


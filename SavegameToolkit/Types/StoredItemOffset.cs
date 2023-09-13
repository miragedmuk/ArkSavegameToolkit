using System;
using System.Collections.Generic;
using System.Text;

namespace SavegameToolkit.Types
{
    internal class StoredItemOffset
    {
        public GameObject ParentObject { get; internal set; }
        public long ObjectOffset { get; internal set; }
    }
}

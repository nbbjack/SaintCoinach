﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintCoinach.Xiv {
    using Ex.Relational;

    public class GatheringPointName : XivRow {
        #region Properties

        public string Singular { get { return AsString("Singular"); } }
        public string Plural { get { return AsString("Plural"); } }

        #endregion

        #region Constructors

        public GatheringPointName(IXivSheet sheet, IRelationalRow sourceRow) : base(sheet, sourceRow) { }

        #endregion

        public override string ToString() {
            return Singular;
        }
    }
}

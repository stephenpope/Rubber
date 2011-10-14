using System;

namespace Rubber.DSL.Query
{
    public class SpanFirstQueryBuilder : ISpanQueryBuilder
    {
        public SpanFirstQueryBuilder(ISpanQueryBuilder match, int end)
        {
            throw new NotImplementedException();
        }

        #region ISpanQueryBuilder Members

        public object ToJsonObject()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
using System;

namespace Rubber.DSL.Query
{
    public class WrapperQueryBuilder : IQueryBuilder
    {
        public WrapperQueryBuilder(string source)
        {
            throw new NotImplementedException();
        }

        public WrapperQueryBuilder(byte[] source, int offset, int length)
        {
            throw new NotImplementedException();
        }

        #region IQueryBuilder Members

        public object ToJsonObject()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
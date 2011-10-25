using System;

namespace Rubber.DSL
{
    public class QueryBuilderException : Exception
    {
        public QueryBuilderException(string message) : base(message) { }
    }
}

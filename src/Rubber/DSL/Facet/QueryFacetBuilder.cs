using Rubber.DSL.Query;

namespace Rubber.DSL.Facet
{
    public class QueryFacetBuilder : AbstractFacetBuilder
    {
        public QueryFacetBuilder(string name) : base(name)
        {

        }

        public override object ToJsonObject()
        {
            throw new System.NotImplementedException();
        }

        public QueryFacetBuilder Query(IQueryBuilder query)
        {
            throw new System.NotImplementedException();
        }
    }
}
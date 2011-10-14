using Rubber.DSL.Filter;

namespace Rubber.DSL.Facet
{
    public class FilterFacetBuilder : AbstractFacetBuilder
    {
        public FilterFacetBuilder(string name) : base(name)
        {

        }

        public new FilterFacetBuilder Filter(IFilterBuilder filter)
        {
            _facetFilter = filter;
            return this;
        }

        public override object ToJsonObject()
        {
            throw new System.NotImplementedException();
        }
    }
}
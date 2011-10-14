namespace Rubber.DSL.Facet
{
    public class DateHistogramFacetBuilder : AbstractFacetBuilder
    {
        public DateHistogramFacetBuilder(string name) : base(name)
        {
        }

        public override object ToJsonObject()
        {
            throw new System.NotImplementedException();
        }
    }
}
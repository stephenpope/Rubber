namespace Rubber.DSL.Facet
{
    public class GeoDistanceFacetBuilder : AbstractFacetBuilder
    {
        public GeoDistanceFacetBuilder(string name) : base(name)
        {
        }

        public override object ToJsonObject()
        {
            throw new System.NotImplementedException();
        }
    }
}
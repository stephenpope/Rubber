namespace Rubber.Builders.Sort
{
    public interface ISortBuilder : IJsonSerializable
    {
        ISortBuilder Order(SortOrder order);
        ISortBuilder Missing(object missing);
    }
}
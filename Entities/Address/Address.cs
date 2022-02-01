using NetTopologySuite.Geometries;
using ZingGameApi.Entities.Base;

namespace ZingGameApi.Entities.Address;

public class AddressEntity: BaseEntity
{
    public string City { get; set; }
    public string Country { get; set; }
    public string Area { get; set; }
    public string Street { get; set; }
    public string PostCode { get; set; }
    public string Phone { get; set; }
    public string IsDefault { get; set; }
    // public Point Location { get; set; }
}
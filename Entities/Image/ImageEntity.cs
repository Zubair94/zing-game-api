using ZingGameApi.Entities.Base;

namespace ZingGameApi.Entities.Image;

public class ImageEntity: BaseEntity
{
    public string Url { get; set; }
    public string Key { get; set; }
}
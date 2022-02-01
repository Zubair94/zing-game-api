using System;
using System.Collections;
using System.Collections.Generic;
using ZingGameApi.Entities.Address;
using ZingGameApi.Entities.Base;
using ZingGameApi.Entities.Image;

namespace ZingGameApi.Entities.User;

public class UserEntity: BaseEntity
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public DateTime LastActive { get; set; }
    public string Gender { get; set; }
    public ICollection<AddressEntity> Addresses { get; set; }
    public ImageEntity Image { get; set; }
}
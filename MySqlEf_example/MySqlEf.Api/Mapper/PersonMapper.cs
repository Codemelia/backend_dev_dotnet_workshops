using System.Data.Common;
using System.Security.Cryptography;

using MySqlEf.Api.Models;
using MySqlEf.Api.DTO;

namespace MySqlEf.Api.Mapper;

public static class PersonMapper
{
    
    public static PersonRead ToPersonRead(this Person person)
    {
        return new PersonRead
        {
            Id = person.Id,
            Name = person.Name,
            Age = person.Age
        };
    }

    public static Person ToPerson(this PersonUpdate person)
    {
        return new Person
        {
            Id = person.Id,
            Name = person.Name,
            Age = person.Age
        };
    }

    public static Person ToPersonCreate(this PersonCreate personCreate)
    {
        return new Person
        {
            Name = personCreate.Name,
            Age = personCreate.Age  
        };
    }

}
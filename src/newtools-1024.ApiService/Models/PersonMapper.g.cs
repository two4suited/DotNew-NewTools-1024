using System;
using System.Linq.Expressions;
using newtools1024.ApiService.Data.Entities;

namespace newtools1024.ApiService.Data.Entities
{
    public static partial class PersonMapper
    {
        public static PersonDto AdaptToDto(this Person p1)
        {
            if (p1 == null)
            {
                return null;
            }
            PersonDto result = new PersonDto();
            
            result.Id = p1.Id;
            
            if (p1.FirstName != null)
            {
                result.FirstName = p1.FirstName;
            }
            
            if (p1.LastName != null)
            {
                result.LastName = p1.LastName;
            }
            
            if (p1.DateOfBirth != null)
            {
                result.DateOfBirth = p1.DateOfBirth;
            }
            return result;
            
        }
        public static PersonDto AdaptTo(this Person p2, PersonDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            PersonDto result = p3 ?? new PersonDto();
            
            result.Id = p2.Id;
            
            if (p2.FirstName != null)
            {
                result.FirstName = p2.FirstName;
            }
            
            if (p2.LastName != null)
            {
                result.LastName = p2.LastName;
            }
            
            if (p2.DateOfBirth != null)
            {
                result.DateOfBirth = p2.DateOfBirth;
            }
            return result;
            
        }
        public static Expression<Func<Person, PersonDto>> ProjectToDto => p4 => new PersonDto()
        {
            Id = p4.Id,
            FirstName = p4.FirstName,
            LastName = p4.LastName,
            DateOfBirth = p4.DateOfBirth
        };
        public static Person AdaptToPerson(this PersonAdd p5)
        {
            if (p5 == null)
            {
                return null;
            }
            Person result = new Person();
            
            if (p5.Id != null)
            {
                result.Id = (int)p5.Id;
            }
            
            if (p5.FirstName != null)
            {
                result.FirstName = p5.FirstName;
            }
            
            if (p5.LastName != null)
            {
                result.LastName = p5.LastName;
            }
            
            if (p5.DateOfBirth != null)
            {
                result.DateOfBirth = p5.DateOfBirth;
            }
            return result;
            
        }
        public static Person AdaptTo(this PersonUpdate p6, Person p7)
        {
            if (p6 == null)
            {
                return null;
            }
            Person result = p7 ?? new Person();
            
            if (p6.FirstName != null)
            {
                result.FirstName = p6.FirstName;
            }
            
            if (p6.LastName != null)
            {
                result.LastName = p6.LastName;
            }
            
            if (p6.DateOfBirth != null)
            {
                result.DateOfBirth = p6.DateOfBirth;
            }
            return result;
            
        }
        public static Person AdaptTo(this PersonMerge p8, Person p9)
        {
            if (p8 == null)
            {
                return null;
            }
            Person result = p9 ?? new Person();
            
            if (p8.FirstName != null)
            {
                result.FirstName = p8.FirstName;
            }
            
            if (p8.LastName != null)
            {
                result.LastName = p8.LastName;
            }
            
            if (p8.DateOfBirth != null)
            {
                result.DateOfBirth = p8.DateOfBirth;
            }
            return result;
            
        }
    }
}
using System;
using System.Linq.Expressions;
using Mapster.Utils;
using newtools1024.ApiService.Data.Entities;

namespace newtools1024.ApiService.Data.Entities
{
    public static partial class PetMapper
    {
        public static PetDto AdaptToDto(this Pet p1)
        {
            if (p1 == null)
            {
                return null;
            }
            PetDto result = new PetDto();
            
            result.Id = p1.Id;
            
            if (p1.Name != null)
            {
                result.Name = p1.Name;
            }
            result.Type = Enum<PetType>.ToString(p1.Type);
            result.Breed = Enum<Breed>.ToString(p1.Breed);
            
            if (p1.DateOfBirth != null)
            {
                result.DateOfBirth = p1.DateOfBirth;
            }
            return result;
            
        }
        public static PetDto AdaptTo(this Pet p2, PetDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            PetDto result = p3 ?? new PetDto();
            
            result.Id = p2.Id;
            
            if (p2.Name != null)
            {
                result.Name = p2.Name;
            }
            result.Type = Enum<PetType>.ToString(p2.Type);
            result.Breed = Enum<Breed>.ToString(p2.Breed);
            
            if (p2.DateOfBirth != null)
            {
                result.DateOfBirth = p2.DateOfBirth;
            }
            return result;
            
        }
        public static Expression<Func<Pet, PetDto>> ProjectToDto => p4 => new PetDto()
        {
            Id = p4.Id,
            Name = p4.Name,
            Type = Enum<PetType>.ToString(p4.Type),
            Breed = Enum<Breed>.ToString(p4.Breed),
            DateOfBirth = p4.DateOfBirth
        };
        public static Pet AdaptToPet(this PetAdd p5)
        {
            if (p5 == null)
            {
                return null;
            }
            Pet result = new Pet();
            
            if (p5.Id != null)
            {
                result.Id = (int)p5.Id;
            }
            
            if (p5.Name != null)
            {
                result.Name = p5.Name;
            }
            
            if (p5.Type != null)
            {
                result.Type = Enum<PetType>.Parse(p5.Type);
            }
            
            if (p5.Breed != null)
            {
                result.Breed = Enum<Breed>.Parse(p5.Breed);
            }
            
            if (p5.DateOfBirth != null)
            {
                result.DateOfBirth = p5.DateOfBirth;
            }
            return result;
            
        }
        public static Pet AdaptTo(this PetUpdate p6, Pet p7)
        {
            if (p6 == null)
            {
                return null;
            }
            Pet result = p7 ?? new Pet();
            
            if (p6.Name != null)
            {
                result.Name = p6.Name;
            }
            
            if (p6.Type != null)
            {
                result.Type = Enum<PetType>.Parse(p6.Type);
            }
            
            if (p6.Breed != null)
            {
                result.Breed = Enum<Breed>.Parse(p6.Breed);
            }
            
            if (p6.DateOfBirth != null)
            {
                result.DateOfBirth = p6.DateOfBirth;
            }
            return result;
            
        }
        public static Pet AdaptTo(this PetMerge p8, Pet p9)
        {
            if (p8 == null)
            {
                return null;
            }
            Pet result = p9 ?? new Pet();
            
            if (p8.Name != null)
            {
                result.Name = p8.Name;
            }
            
            if (p8.Type != null)
            {
                result.Type = Enum<PetType>.Parse(p8.Type);
            }
            
            if (p8.Breed != null)
            {
                result.Breed = Enum<Breed>.Parse(p8.Breed);
            }
            
            if (p8.DateOfBirth != null)
            {
                result.DateOfBirth = p8.DateOfBirth;
            }
            return result;
            
        }
    }
}
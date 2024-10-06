using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Mapster;

using newtools1024.ApiService.Data.Entities;


namespace newtools1024.ApiService;

public class MapsterConfiguration : ICodeGenerationRegister
{
    public void Register(CodeGenerationConfig config)
    {
        config.AdaptTo("[name]Dto")
            .ApplyDefaultRule();
           
    /*
        config.AdaptFrom("[name]Add", MapType.Map)
            .ApplyDefaultRule()
            .IgnoreNoModifyProperties();

        config.AdaptFrom("[name]Update", MapType.MapToTarget)
            .ApplyDefaultRule()
            .IgnoreAttributes(typeof(KeyAttribute))
            .IgnoreNoModifyProperties();

        config.AdaptFrom("[name]Merge", MapType.MapToTarget)
            .ApplyDefaultRule()
            .IgnoreAttributes(typeof(KeyAttribute))
            .IgnoreNoModifyProperties()
            .IgnoreNullValues(true);
      */  
        config.GenerateMapper("[name]Mapper").ForType<Person>().ForType<Pet>();
    }
}

static class RegisterExtensions
{
    public static AdaptAttributeBuilder ApplyDefaultRule(this AdaptAttributeBuilder builder)
    {
        return builder
            .ForAllTypesInNamespace(Assembly.GetExecutingAssembly(), "newtools1024.ApiService.Data.Entities")
            .ExcludeTypes(typeof(SampleDbContext))
            .ExcludeTypes(type => type.IsEnum)
            .AlterType(type => type.IsEnum || Nullable.GetUnderlyingType(type)?.IsEnum == true, typeof(string))
            .ShallowCopyForSameType(true)
            .ForType<Person>(cfg => cfg.Ignore(it => it.Pets));
    }
    
    public static AdaptAttributeBuilder IgnoreNoModifyProperties(this AdaptAttributeBuilder builder)
    {
        return builder
            .ForType<Person>(cfg => cfg.Ignore(it => it.Pets));
    }
    
}
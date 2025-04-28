using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class PolymorphismDocumentFilter<TBase> : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var derivedTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(t => typeof(TBase).IsAssignableFrom(t) && !t.IsAbstract);

        foreach (var type in derivedTypes)
        {
            context.SchemaGenerator.GenerateSchema(type, context.SchemaRepository);
        }
    }
}